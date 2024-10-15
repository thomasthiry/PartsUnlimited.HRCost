using PartsUnlimited.HRCost.Application.Services;
using PartsUnlimited.HRCost.Domain.Entities;
using PartsUnlimited.HRCost.Infrastructure.Repositories;
using PartsUnlimited.HRCost.Tests;
using PartsUnlimited.HRCost.Web;
using PartsUnlimited.HRCost.Web.Controllers;

namespace PartsUnlimited.HRCost.IntegrationTests;

public class IntegrationAppBuilder
{
    private readonly SqlConnectionFactory _sqlConnectionFactory;
    private List<Employee> _employees = new();

    public IntegrationAppBuilder(SqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public TestingAppContext Build()
    {
        var employeeRepository = new EmployeeRepository(_sqlConnectionFactory);
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