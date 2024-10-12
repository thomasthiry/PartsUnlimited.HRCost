using PartsUnlimited.HRCost.Application.Services;
using PartsUnlimited.HRCost.Domain.Entities;
using PartsUnlimited.HRCost.Web.Controllers;

namespace PartsUnlimited.HRCost.Tests;

public class AppBuilder
{
    private List<Employee> _employees = new();

    public static AppBuilder AnApp()
    {
        return new AppBuilder();
    }

    public TestingAppContext Build()
    {
        var employeeRepositoryMock = new EmployeeRepositoryMock();
        employeeRepositoryMock.Add(_employees);
        return new TestingAppContext
        {
            EmployeeController = new EmployeeController(new EmployeeService(employeeRepositoryMock)),
            EmployeeRepositoryMock = employeeRepositoryMock
        };
    }

    public AppBuilder With(Employee employee)
    {
        _employees.Add(employee);
        return this;
    }
}