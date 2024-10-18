using NFluent;
using PartsUnlimited.HRCost.Application.Interfaces.SecondaryPorts;
using PartsUnlimited.HRCost.Infrastructure.Repositories;
using PartsUnlimited.HRCost.Tests;
using PartsUnlimited.HRCost.Web;
using static PartsUnlimited.HRCost.Tests.EmployeeBuilder;

namespace PartsUnlimited.HRCost.IntegrationTests;

public abstract class EmployeeRepositoryIntegrationTests
{
    protected IEmployeeRepository _employeeRepository;

    [Fact]
    public void Create_and_get_employee()
    {
        var employee = AnEmployee().Build();
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
        var employee = AnEmployee().Build();
        employee.Reference = 1;
        employee.FirstName = "Jake";
        employee.LastName = "Gyllenhaal";
        employee.DateOfBirth = new DateTime(1980, 1, 1);
        employee.AddressNumber = "1";
        employee.AddressStreet = "1";
        employee.AddressCity = "1";
        employee.AddressPostalCode = "1";
        employee.AddressCountry = "1";
        employee.JoinedCompanyDate = new DateTime(2020, 1, 1);
        employee.MonthlyGrossSalary = 1.00m;
        employee.NbDaysYearlyHolidays = 1;
        employee.HasDoubleHolidayPremium = false;
        employee.HasEndOfYearPremium = false;
        employee.HasCellPhonePlan = false;

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