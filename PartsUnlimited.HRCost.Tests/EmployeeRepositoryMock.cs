using PartsUnlimited.HRCost.Application.Interfaces.SecondaryPorts;
using PartsUnlimited.HRCost.Domain.Entities;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeRepositoryMock : IEmployeeRepository
{
    private List<Employee> _employees = new();

    public IEnumerable<Employee> GetEmployees()
    {
        throw new NotImplementedException();
    }

    public Employee GetEmployee(int id)
    {
        return _employees.First(e => e.Id == id);
    }

    public void Update(Employee employee)
    {
        throw new NotImplementedException();
    }

    public void Add(Employee employee)
    {
        _employees.Add(employee);
    }
}