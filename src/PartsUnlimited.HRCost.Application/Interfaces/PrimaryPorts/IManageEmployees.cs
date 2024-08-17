using System.Collections.Generic;
using PartsUnlimited.HRCost.Domain.Entities;

namespace PartsUnlimited.HRCost.Application.Interfaces.PrimaryPorts
{
    public interface IManageEmployees
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void Update(Employee employee);
    }
}