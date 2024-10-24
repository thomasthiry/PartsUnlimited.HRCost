using PartsUnlimited.HRCost.Domain.Entities;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeBuilder
{
    private int _id = 1;
    private int _reference = 1001;
    private string _firstName = "Nicolas";
    private string _lastName = "Cage";
    private DateTime _dateOfBirth = new DateTime(1990, 5, 22);
    private string _addressNumber = "123";
    private string _addressStreet = "Main Street";
    private string _addressCity = "Wellington";
    private string _addressPostalCode = "12345";
    private string _addressCountry = "New Zealand";
    private DateTime _joinedCompanyDate = new DateTime(2020, 6, 15);
    private decimal _monthlyGrossSalary = 5000.00m;
    private int _nbDaysYearlyHolidays = 25;
    private bool _hasDoubleHolidayPremium = false;
    private bool _hasEndOfYearPremium = false;
    private bool _hasCellPhonePlan = false;


    public static EmployeeBuilder AnEmployee()
    {
        return new EmployeeBuilder();
    }

    public Employee Build()
    {
        return new Employee(_firstName, _lastName) 
        {
            Id = _id,
            Reference = _reference,
            DateOfBirth = _dateOfBirth,
            AddressNumber = _addressNumber,
            AddressStreet = _addressStreet,
            AddressCity = _addressCity,
            AddressPostalCode = _addressPostalCode,
            AddressCountry = _addressCountry,
            JoinedCompanyDate = _joinedCompanyDate,
            MonthlyGrossSalary = _monthlyGrossSalary,
            NbDaysYearlyHolidays = _nbDaysYearlyHolidays,
            HasDoubleHolidayPremium = _hasDoubleHolidayPremium,
            HasEndOfYearPremium = _hasEndOfYearPremium,
            HasCellPhonePlan = _hasCellPhonePlan
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

    public EmployeeBuilder WithCellPhonePlan()
    {
        _hasCellPhonePlan = true;
        return this;
    }

    public EmployeeBuilder WithoutCellPhonePlan()
    {
        _hasCellPhonePlan = false;
        return this;
    }
}