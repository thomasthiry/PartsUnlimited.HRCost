using NFluent;
using PartsUnlimited.HRCost.Web.ViewModels;
using static PartsUnlimited.HRCost.Tests.AppBuilder;
using static PartsUnlimited.HRCost.Tests.EmployeeBuilder;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeCost4Tests
{
    [Fact]
    public void The_details_of_an_employee_can_be_viewed()
    {
        var employee = AnEmployee().Build();
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
    
    [Fact]
    public void The_double_holiday_premium_adds_92_percent_of_the_monthly_gross_salary_to_the_year_cost()
    {
        var employee = AnEmployee()
            .WithMonthlyGrossSalary(3000m)
            .WithDoubleHolidayPremium()
            .Build();
        var app = AnApp().With(employee).Build();

        var retrievedEmployee = app.EmployeeController.Edit(employee.Id).To<EmployeeViewModel>();

        Check.That(retrievedEmployee.YearlyGrossSalaryCost).Is(38760m);
    }

    [Fact]
    public void The_end_of_year_premium_adds_1_time_the_monthly_gross_salary_to_the_year_cost()
    {
        var employee = AnEmployee()
            .WithMonthlyGrossSalary(3000m)
            .WithEndOfYearPremium()
            .Build();
        var app = AnApp().With(employee).Build();

        var retrievedEmployee = app.EmployeeController.Edit(employee.Id).To<EmployeeViewModel>();

        Check.That(retrievedEmployee.YearlyGrossSalaryCost).Is(39000m);
    }

    [Fact]
    public void The_employer_tax_is_30_percent_of_the_gross_salary()
    {
        var employee = AnEmployee()
            .WithMonthlyGrossSalary(1000m)
            .Build();
        var app = AnApp().With(employee).Build();

        var retrievedEmployee = app.EmployeeController.Edit(employee.Id).To<EmployeeViewModel>();

        Check.That(retrievedEmployee.YearlyEmployerTax).Is(3600m); // 12 * 1000 * 30 %
    }

    [Fact]
    public void The_employer_tax_applies_to_premiums_as_well()
    {
        var employee = AnEmployee()
            .WithMonthlyGrossSalary(1000m)
            .WithEndOfYearPremium()
            .Build();
        var app = AnApp().With(employee).Build();

        var retrievedEmployee = app.EmployeeController.Edit(employee.Id).To<EmployeeViewModel>();

        Check.That(retrievedEmployee.YearlyEmployerTax).Is(3900m); // 13 * 1000 * 30 %
    }

    // bonus
    // chèques repas
    // assurance groupe
    // frais de représentation
    // abonnement gsm
    // voiture de société
    
    // total cost = sum of all other costs
    // monthly cost = 1/12 of the yearly cost
}