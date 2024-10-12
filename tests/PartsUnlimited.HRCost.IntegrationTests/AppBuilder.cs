using PartsUnlimited.HRCost.Application.Services;
using PartsUnlimited.HRCost.Domain.Entities;
using PartsUnlimited.HRCost.Infrastructure.Repositories;
using PartsUnlimited.HRCost.Tests;
using PartsUnlimited.HRCost.Web;
using PartsUnlimited.HRCost.Web.Controllers;

namespace PartsUnlimited.HRCost.IntegrationTests;

public class IntegrationAppBuilder
{
    private List<Employee> _employees = new();

    public static IntegrationAppBuilder AnApp()
    {
        return new IntegrationAppBuilder();
    }

    public TestingAppContext Build()
    {
        var employeeRepository = new EmployeeRepository(new SqlConnectionFactory("Server=localhost;Database=PARTS_UNLIMITED_HR_COSTS;User Id=sa;Password=Evolve11!;"));
        
        return new TestingAppContext
        {
            EmployeeController = new EmployeeController(new EmployeeService(employeeRepository)),
        };
    }

    public IntegrationAppBuilder With(Employee employee)
    {
        _employees.Add(employee);
        return this;
    }
}