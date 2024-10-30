using NFluent;
using PartsUnlimited.HRCost.Application.Interfaces.SecondaryPorts;
using PartsUnlimited.HRCost.Domain.Entities;
using PartsUnlimited.HRCost.Infrastructure.Repositories;
using PartsUnlimited.HRCost.Tests;
using PartsUnlimited.HRCost.Web;

namespace PartsUnlimited.HRCost.IntegrationTests;

public abstract class EmployeeRepositoryIntegrationTests
{
    protected IEmployeeRepository _employeeRepository;

    [Fact]
    public void Create_and_get_employee()
    {
        var employee = new Employee("Simon", "Gruber")
        {
            Reference = 12345,
            DateOfBirth = new DateTime(1990, 12, 13),
            AddressNumber = "888",
            AddressStreet = "Main Street",
            AddressCity = "Metropolis",
            AddressPostalCode = "9654",
            AddressCountry = "Wonderland",
            JoinedCompanyDate = new DateTime(2020, 4, 3),
            MonthlyGrossSalary = 3000.00m,
            NbDaysYearlyHolidays = 25,
            HasDoubleHolidayPremium = true,
            HasEndOfYearPremium = true,
            HasCellPhonePlan = true
        };

        var employeeId = _employeeRepository.Add(employee);
        
        var fetchedEmployee = _employeeRepository.GetEmployee(employeeId);

        Check.That(fetchedEmployee.Reference).Is(12345);
        Check.That(fetchedEmployee.FirstName).Is("Simon");
        Check.That(fetchedEmployee.LastName).Is("Gruber");
        Check.That(fetchedEmployee.DateOfBirth).Is(new DateTime(1990, 12, 13));
        Check.That(fetchedEmployee.AddressNumber).Is("888");
        Check.That(fetchedEmployee.AddressStreet).Is("Main Street");
        Check.That(fetchedEmployee.AddressCity).Is("Metropolis");
        Check.That(fetchedEmployee.AddressPostalCode).Is("9654");
        Check.That(fetchedEmployee.AddressCountry).Is("Wonderland");
        Check.That(fetchedEmployee.JoinedCompanyDate).Is(new DateTime(2020, 4, 3));
        Check.That(fetchedEmployee.MonthlyGrossSalary).Is(3000.00m);
        Check.That(fetchedEmployee.NbDaysYearlyHolidays).Is(25);
        Check.That(fetchedEmployee.HasDoubleHolidayPremium).Is(true);
        Check.That(fetchedEmployee.HasEndOfYearPremium).Is(true);
        Check.That(fetchedEmployee.HasCellPhonePlan).Is(true);
    }

    [Fact]
    public void Update_employee()
    {
        var employee = new Employee("Jake", "Gyllenhaal")
        {
            Reference = 1,
            DateOfBirth = new DateTime(1980, 1, 1),
            AddressNumber = "1",
            AddressStreet = "1",
            AddressCity = "1",
            AddressPostalCode = "1",
            AddressCountry = "1",
            JoinedCompanyDate = new DateTime(2020, 1, 1),
            MonthlyGrossSalary = 1.00m,
            NbDaysYearlyHolidays = 1,
            HasDoubleHolidayPremium = false,
            HasEndOfYearPremium = false,
            HasCellPhonePlan = false
        };

        var employeeId = _employeeRepository.Add(employee);

        employee.Reference = 12345;
        employee.FirstName = "Simon";
        employee.LastName = "Gruber";
        employee.DateOfBirth = new DateTime(1990, 12, 13);
        employee.AddressNumber = "888";
        employee.AddressStreet = "Main Street";
        employee.AddressCity = "Metropolis";
        employee.AddressPostalCode = "9654";
        employee.AddressCountry = "Wonderland";
        employee.JoinedCompanyDate = new DateTime(2020, 4, 3);
        employee.MonthlyGrossSalary = 3000.00m;
        employee.NbDaysYearlyHolidays = 25;
        employee.HasDoubleHolidayPremium = true;
        employee.HasEndOfYearPremium = true;
        employee.HasCellPhonePlan = true;
        
        _employeeRepository.Update(employee);
        
        var fetchedEmployee = _employeeRepository.GetEmployee(employeeId);

        Check.That(fetchedEmployee.Reference).Is(12345);
        Check.That(fetchedEmployee.FirstName).Is("Simon");
        Check.That(fetchedEmployee.LastName).Is("Gruber");
        Check.That(fetchedEmployee.DateOfBirth).Is(new DateTime(1990, 12, 13));
        Check.That(fetchedEmployee.AddressNumber).Is("888");
        Check.That(fetchedEmployee.AddressStreet).Is("Main Street");
        Check.That(fetchedEmployee.AddressCity).Is("Metropolis");
        Check.That(fetchedEmployee.AddressPostalCode).Is("9654");
        Check.That(fetchedEmployee.AddressCountry).Is("Wonderland");
        Check.That(fetchedEmployee.JoinedCompanyDate).Is(new DateTime(2020, 4, 3));
        Check.That(fetchedEmployee.MonthlyGrossSalary).Is(3000.00m);
        Check.That(fetchedEmployee.NbDaysYearlyHolidays).Is(25);
        Check.That(fetchedEmployee.HasDoubleHolidayPremium).Is(true);
        Check.That(fetchedEmployee.HasEndOfYearPremium).Is(true);
        Check.That(fetchedEmployee.HasCellPhonePlan).Is(true);
    }
}

public class EmployeeRepositoryMockIntegrationTests : EmployeeRepositoryIntegrationTests
{
    public EmployeeRepositoryMockIntegrationTests()
    {
        _employeeRepository = new EmployeeRepositoryMock(); // A new instance is created for each TEST
    }
}

public class EmployeeRepositoryDbIntegrationTests : EmployeeRepositoryIntegrationTests, IClassFixture<DatabaseFixture>
{
    public EmployeeRepositoryDbIntegrationTests(DatabaseFixture databaseFixture) : base()
    {
        _employeeRepository = new EmployeeRepository(new SqlConnectionFactory(databaseFixture.ConnectionString));
    }
}