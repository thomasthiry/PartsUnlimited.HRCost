using NFluent;
using PartsUnlimited.HRCost.Domain.Entities;
using PartsUnlimited.HRCost.Web.ViewModels;
using static PartsUnlimited.HRCost.Tests.AppBuilder;
using static PartsUnlimited.HRCost.Tests.EmployeeBuilder;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeCostTests
{
    [Fact]
    public void The_details_of_an_employee_can_be_viewed()
    {
        var employee = AnEmployee().Build();
        var context = AnApp().With(employee).Build();

        var retrievedEmployee = context.EmployeeController.Edit(employee.Id).ConvertTo<EmployeeViewModel>();

        Check.That(retrievedEmployee.LastName).Is(employee.LastName);
    }
}