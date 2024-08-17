using System.Collections.Generic;
using PartsUnlimited.HRCost.Application.Interfaces.PrimaryPorts;
using PartsUnlimited.HRCost.Application.Interfaces.SecondaryPorts;
using PartsUnlimited.HRCost.Domain.Entities;

namespace PartsUnlimited.HRCost.Application.Services
{
    public class EmployeeService : IManageEmployees
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }
    }
}
