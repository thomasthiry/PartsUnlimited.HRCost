using NFluent;
using PartsUnlimited.HRCost.Web.ViewModels;
using static PartsUnlimited.HRCost.Tests.AppBuilder;
using static PartsUnlimited.HRCost.Tests.EmployeeBuilder;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeCostTests
{
    [Fact]
    public void The_details_of_an_employee_can_be_viewed()
    {
        var employee = AnEmployee().Build();
        var context = AnApp().With(employee).Build();

        var retrievedEmployee = context.EmployeeController.Edit(employee.Id).ConvertTo<EmployeeViewModel>();

        Check.That(retrievedEmployee.LastName).Is(employee.LastName);
    }
    
    [Fact]
    public void The_yearly_gross_salary_of_an_employee_is_12_times_the_monthly_gross_salary()
    {
        var employee = AnEmployee().WithMonthlyGrossSalary(3000m).Build();
        var app = AnApp().With(employee).Build();

        var retrievedEmployee = app.EmployeeController.Edit(employee.Id).ConvertTo<EmployeeViewModel>();

        Check.That(retrievedEmployee.YearlyGrossSalaryCost).Is(36000m);
    }
    
    [Fact]
    // public void The_yearly_gross_salary_includes_double_premiums_and_end_of_year_premium()
    public void The_double_holiday_premium_adds_92_percent_of_the_monthly_gross_salary_to_the_year()
    {
        var employee = AnEmployee()
            .WithMonthlyGrossSalary(3000m)
            .WithDoubleHolidayPremium()
            .Build();
        var app = AnApp().With(employee).Build();

        var retrievedEmployee = app.EmployeeController.Edit(employee.Id).ConvertTo<EmployeeViewModel>();

        Check.That(retrievedEmployee.YearlyGrossSalaryCost).Is(38760m);
    }

    // [Fact]
    // public void The_yearly_cost_of_an_employee_includes_the_yearly_gross_salary()
    // {
    //     var employee = AnEmployee().WithMonthlyGrossSalary(3000).Build();
    //     var app = AnApp().With(employee).Build();
    //
    //     var retrievedEmployee = app.EmployeeController.Edit(employee.Id).ConvertTo<EmployeeViewModel>();
    //
    //     Check.That(retrievedEmployee.TotalYearlyCost).Is(employee.YearlyGrossSalaryCost);
    // }
    
    
    // The_minimum_cost_of_an_employee_is_gross_salary_plus_13th_month_and_vacation_double_premium
    
    // The_yearly_gross_salary_includes_double_premiums_and_end_of_year_premium
    // The_employer_tax_is_30_percent_of_the_gross_salary
    
    

    // bonus
    // chèques repas
    // assurance groupe
    // frais de représentation
    // abonnement gsm
    // voiture de société
    
    // total cost = sum of all other costs
    // monthly cost = 1/12 of the yearly cost
}