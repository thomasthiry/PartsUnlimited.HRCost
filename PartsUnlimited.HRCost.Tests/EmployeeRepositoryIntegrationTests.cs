using NFluent;
using PartsUnlimited.HRCost.Application.Interfaces.SecondaryPorts;
using PartsUnlimited.HRCost.Infrastructure.Repositories;
using PartsUnlimited.HRCost.Web;
using static PartsUnlimited.HRCost.Tests.EmployeeBuilder;

namespace PartsUnlimited.HRCost.Tests;

public abstract class EmployeeRepositoryIntegrationTests
{
    private readonly IEmployeeRepository _employeeRepository;

    protected EmployeeRepositoryIntegrationTests()
    {
        _employeeRepository = GetEmployeeRepository(); // A new instance is created for each TEST
    }

    protected abstract IEmployeeRepository GetEmployeeRepository();

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
    protected override IEmployeeRepository GetEmployeeRepository()
    {
        return new EmployeeRepositoryMock();
    }
}

public class EmployeeRepositoryDbIntegrationTests : EmployeeRepositoryIntegrationTests, IClassFixture<DatabaseFixture>
{
    protected override IEmployeeRepository GetEmployeeRepository()
    {
        return new EmployeeRepository(new SqlConnectionFactory("Server=localhost;Database=PARTS_UNLIMITED_HR_COSTS;User Id=sa;Password=Evolve11!;"));
    }
}