using NFluent;
using PartsUnlimited.HRCost.Web.ViewModels;
using static PartsUnlimited.HRCost.Tests.AppBuilder;
using static PartsUnlimited.HRCost.Tests.EmployeeBuilder;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeCost3Tests
{
    [Fact]
    public void The_details_of_an_employee_can_be_viewed()
    {
        var employee = AnEmployee().Build(); // Desiderata: Readable
        var context = AnApp().With(employee).Build();
        
        var retrievedEmployee = context.EmployeeController.Edit(employee.Id).To<EmployeeViewModel>();

        Check.That(retrievedEmployee.LastName).Is(employee.LastName);
    }
    
    [Fact]
    public void The_yearly_gross_salary_cost_of_an_employee_is_12_times_the_monthly_gross_salary()
    {
        var employee = AnEmployee().WithMonthlyGrossSalary(3000m).Build();
        var app = AnApp().With(employee).Build();

        var retrievedEmployee = app.EmployeeController.Edit(employee.Id).To<EmployeeViewModel>();

        Check.That(retrievedEmployee.YearlyGrossSalaryCost).Is(36000m); // 12 * 3000
    }
}