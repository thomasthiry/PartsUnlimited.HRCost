using PartsUnlimited.HRCost.Web.Controllers;

namespace PartsUnlimited.HRCost.Tests;

public class TestingAppContext
{
    public EmployeeController EmployeeController { get; set; }
    public EmployeeRepositoryMock EmployeeRepositoryMock { get; set; }
}