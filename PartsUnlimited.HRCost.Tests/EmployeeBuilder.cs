using PartsUnlimited.HRCost.Domain.Entities;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeBuilder
{
    private int _id = 1;
    private string _firstName = "Nicolas";
    private string _lastName = "Cage";
    private decimal _monthlyGrossSalary;
    private bool _hasDoubleHolidayPremium;
    private bool _hasEndOfYearPremium;

    public static EmployeeBuilder AnEmployee()
    {
        return new EmployeeBuilder();
    }

    public Employee Build()
    {
        return new Employee(_firstName, _lastName) { 
            Id = _id, 
            MonthlyGrossSalary = _monthlyGrossSalary,
            HasDoubleHolidayPremium = _hasDoubleHolidayPremium,
            HasEndOfYearPremium = _hasEndOfYearPremium
        };
    }

    public EmployeeBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public EmployeeBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }


    public EmployeeBuilder WithMonthlyGrossSalary(decimal salary)
    {
        _monthlyGrossSalary = salary;
        return this;
    }

    public EmployeeBuilder WithDoubleHolidayPremium()
    {
        _hasDoubleHolidayPremium = true;
        return this;
    }

    public EmployeeBuilder WithEndOfYearPremium()
    {
        _hasEndOfYearPremium = true;
        return this;
    }
}