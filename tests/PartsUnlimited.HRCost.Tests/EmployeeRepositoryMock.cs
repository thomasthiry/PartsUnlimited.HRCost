using System.Text.Json;
using PartsUnlimited.HRCost.Application.Interfaces.SecondaryPorts;
using PartsUnlimited.HRCost.Domain.Entities;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeRepositoryMock : IEmployeeRepository
{
    // TODO Handle errors like the actual repository would
    
    private List<Employee> _employees = new();

    public IEnumerable<Employee> GetEmployees()
    {
        throw new NotImplementedException();
    }

    public Employee GetEmployee(int id)
    {
        return DeepCopy(_employees.First(e => e.Id == id));
    }

    public void Update(Employee employee)
    {
        _employees.Remove(employee);
        _employees.Add(DeepCopy(employee));
    }

    public int Add(Employee employee)
    {
        var newIdentifier = _employees.Any() ? _employees.Max(e => e.Id) : 1;
        employee.Id = newIdentifier; // Update entity provided with new Id
        var employeeCopy = DeepCopy(employee);
        _employees.Add(employeeCopy);
        return newIdentifier;
    }

    public void Add(IEnumerable<Employee> employees)
    {
        _employees.AddRange(employees);
    }
    
    private static T DeepCopy<T>(T obj)
    {
        if (obj == null) return default;

        var json = JsonSerializer.Serialize(obj);
        
        return JsonSerializer.Deserialize<T>(json);
    }
}