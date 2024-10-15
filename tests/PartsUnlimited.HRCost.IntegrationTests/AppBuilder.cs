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

    public TestingAppContext Build(SqlConnectionFactory sqlConnectionFactory)
    {
        var employeeRepository = new EmployeeRepository(sqlConnectionFactory);
        foreach (var employee in _employees)
        {
            employeeRepository.Add(employee);
        }
        
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