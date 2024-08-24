using NFluent;
using PartsUnlimited.HRCost.Domain.Entities;
using PartsUnlimited.HRCost.Web.ViewModels;
using static PartsUnlimited.HRCost.Tests.AppBuilder;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeCostTests
{
    [Fact]
    public void The_details_of_an_employee_can_be_viewed()
    {
        var context = AnApp().With(new Employee { Id = 1, LastName = "Poelvoorde" }).Build();

        var employee = context.EmployeeController.Edit(1).ConvertTo<EmployeeViewModel>();

        Check.That(employee.Id).Is(1);
        Check.That(employee.LastName).Is("Poelvoorde");
    }
}