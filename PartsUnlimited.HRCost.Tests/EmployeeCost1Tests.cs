using NFluent;
using PartsUnlimited.HRCost.Application.Services;
using PartsUnlimited.HRCost.Domain.Entities;
using PartsUnlimited.HRCost.Web.Controllers;
using PartsUnlimited.HRCost.Web.ViewModels;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeCost1Tests
{
    [Fact]
    public void The_details_of_an_employee_can_be_viewed()
    {
        var employee = new Employee("Benoît", "Poelvoorde");
        var employeeRepositoryMock = new EmployeeRepositoryMock();
        employeeRepositoryMock.Add(new[] { employee });
        var controller = new EmployeeController(new EmployeeService(employeeRepositoryMock));
        
        var retrievedEmployee = controller.Edit(employee.Id).To<EmployeeViewModel>();

        Check.That(retrievedEmployee.LastName).Is(employee.LastName);
    }
}