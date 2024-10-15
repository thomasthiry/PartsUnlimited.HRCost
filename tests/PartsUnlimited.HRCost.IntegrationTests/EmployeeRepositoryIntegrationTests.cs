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

        var employeeId = _employeeRepository.Add(employee);
        
        var fetchedEmployee = _employeeRepository.GetEmployee(employeeId);

        Check.That(fetchedEmployee.Reference).Is(employee.Reference);
        Check.That(fetchedEmployee.LastName).Is(employee.LastName);
        Check.That(fetchedEmployee.FirstName).Is(employee.FirstName);
        Check.That(fetchedEmployee.DateOfBirth).Is(employee.DateOfBirth);
        Check.That(fetchedEmployee.AddressNumber).Is(employee.AddressNumber);
        Check.That(fetchedEmployee.AddressStreet).Is(employee.AddressStreet);
        Check.That(fetchedEmployee.AddressCity).Is(employee.AddressCity);
        Check.That(fetchedEmployee.AddressPostalCode).Is(employee.AddressPostalCode);
        Check.That(fetchedEmployee.AddressCountry).Is(employee.AddressCountry);
        Check.That(fetchedEmployee.JoinedCompanyDate).Is(employee.JoinedCompanyDate);
        Check.That(fetchedEmployee.MonthlyGrossSalary).Is(employee.MonthlyGrossSalary);
        Check.That(fetchedEmployee.IsGrantedCar).Is(employee.IsGrantedCar);
        Check.That(fetchedEmployee.NbDaysYearlyHolidays).Is(employee.NbDaysYearlyHolidays);
    }

    [Fact]
    public void Update_employee()
    {
        var employee = AnEmployee().Build();

        var employeeId = _employeeRepository.Add(employee);

        employee.AddressCountry = "Wonderland";
        
        _employeeRepository.Update(employee);
        
        var fetchedEmployee = _employeeRepository.GetEmployee(employeeId);

        Check.That(fetchedEmployee.AddressCountry).Is("Wonderland");
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