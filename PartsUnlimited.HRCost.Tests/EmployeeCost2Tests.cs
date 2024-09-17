using NFluent;
using PartsUnlimited.HRCost.Application.Services;
using PartsUnlimited.HRCost.Domain.Entities;
using PartsUnlimited.HRCost.Web.Controllers;
using PartsUnlimited.HRCost.Web.ViewModels;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeCost2Tests
{
    [Fact]
    public void The_details_of_an_employee_can_be_viewed()
    {
        var employee = new Employee("Benoît", "Poelvoorde");
        var employeeRepositoryMock = new EmployeeRepositoryMock();
        employeeRepositoryMock.Add(new[] { employee });
        var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock));
        
        var retrievedEmployee = controller.Edit(employee.Id).To<EmployeeViewModel>();

        Check.That(retrievedEmployee.LastName).Is(employee.LastName);
    }
    
    [Fact]
    public void The_yearly_gross_salary_of_an_employee_is_12_times_the_monthly_gross_salary()
    {
        var employee = new Employee("Benoît", "Poelvoorde");
        employee.MonthlyGrossSalary = 3000m;
        var employeeRepositoryMock = new EmployeeRepositoryMock();
        employeeRepositoryMock.Add(new[] { employee });
        var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock));

        var retrievedEmployee = controller.Edit(employee.Id).To<EmployeeViewModel>();

        Check.That(retrievedEmployee.YearlyGrossSalaryCost).Is(36000); // 12 * 3000
    }
}