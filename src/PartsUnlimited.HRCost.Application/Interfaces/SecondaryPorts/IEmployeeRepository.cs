using System.Collections.Generic;
using PartsUnlimited.HRCost.Domain.Entities;

namespace PartsUnlimited.HRCost.Application.Interfaces.SecondaryPorts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void Update(Employee employee);
        int Add(Employee employee);
    }
}