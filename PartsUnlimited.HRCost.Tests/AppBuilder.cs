using PartsUnlimited.HRCost.Application.Services;
using PartsUnlimited.HRCost.Web.Controllers;

namespace PartsUnlimited.HRCost.Tests;

public class AppBuilder
{
    public static AppBuilder AnApp()
    {
        return new AppBuilder();
    }

    public TestingAppContext Build()
    {
        var employeeRepositoryMock = new EmployeeRepositoryMock();
        return new TestingAppContext
        {
            EmployeeController = new EmployeeController(new EmployeeService(employeeRepositoryMock)),
            EmployeeRepositoryMock = employeeRepositoryMock
        };
    }
}