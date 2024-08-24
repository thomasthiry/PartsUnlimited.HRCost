using PartsUnlimited.HRCost.Domain.Entities;

namespace PartsUnlimited.HRCost.Tests;

public class EmployeeBuilder
{
    private int _id = 1;
    private string _lastName = "Cage";

    public static EmployeeBuilder AnEmployee()
    {
        return new EmployeeBuilder();
    }

    public Employee Build()
    {
        return new Employee { Id = _id, LastName = _lastName };
    }

    public EmployeeBuilder WithId(int id)
    {
        _id = id;
        return this;
    }

    public EmployeeBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }
}