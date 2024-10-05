using NFluent;
using PartsUnlimited.HRCost.Application.Interfaces.SecondaryPorts;
using PartsUnlimited.HRCost.Domain.Entities;
using PartsUnlimited.HRCost.Infrastructure.Repositories;
using PartsUnlimited.HRCost.Web;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeRepositoryIntegrationTests
{
    [Theory, MemberData(nameof(RepositoryUnderTest))]
    public void Create_and_get_employee(IEmployeeRepository employeeRepository)
    {
        var employee = new Employee("Jean", "Reno")
        {
            Reference = 1001,
            DateOfBirth = new DateTime(1990, 1, 1),
            AddressNumber = "123",
            AddressStreet = "Main Street",
            AddressCity = "Sample City",
            AddressPostalCode = "12345",
            AddressCountry = "Sample Country",
            JoinedCompanyDate = new DateTime(2020, 6, 15),
            MonthlyGrossSalary = 5000.00m,
            IsGrantedCar = true,
            NbDaysYearlyHolidays = 25
        };

        var employeeId = employeeRepository.Add(employee);
        
        var fetchedEmployee = employeeRepository.GetEmployee(employeeId);

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

    [Theory, MemberData(nameof(RepositoryUnderTest))]
    public void Update_employee(IEmployeeRepository employeeRepository)
    {
        var employee = new Employee("Jean", "Reno")
        {
            Reference = 1001,
            DateOfBirth = new DateTime(1990, 1, 1),
            AddressNumber = "123",
            AddressStreet = "Main Street",
            AddressCity = "Sample City",
            AddressPostalCode = "12345",
            AddressCountry = "Sample Country",
            JoinedCompanyDate = new DateTime(2020, 6, 15),
            MonthlyGrossSalary = 5000.00m,
            IsGrantedCar = true,
            NbDaysYearlyHolidays = 25
        };

        var employeeId = employeeRepository.Add(employee);

        employee.AddressCountry = "Wonderland";
        
        employeeRepository.Update(employee);
        
        var fetchedEmployee = employeeRepository.GetEmployee(employeeId);

        Check.That(fetchedEmployee.AddressCountry).Is("Wonderland");
    }

    public static IEnumerable<object[]> RepositoryUnderTest()
    {
        return new[] { 
            new object[] { new EmployeeRepositoryMock() }, 
            new object[] { new EmployeeRepository(new SqlConnectionFactory("Server=localhost;Database=PARTS_UNLIMITED_HR_COSTS;User Id=sa;Password=Evolve11!;")) } };
    }
}