using System.Collections.Generic;
using Dapper;
using PartsUnlimited.HRCost.Application.Interfaces.SecondaryPorts;
using PartsUnlimited.HRCost.Domain.Entities;

namespace PartsUnlimited.HRCost.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public EmployeeRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public IEnumerable<Employee> GetEmployees()
    {
        using (var connection = _connectionFactory.Create())
        {
            const string sql = "SELECT * FROM EMPLOYEE";
            return Map(connection.Query<EmployeeRecord>(sql));
        }
    }


    public Employee GetEmployee(int id)
    {
        using (var connection = _connectionFactory.Create())
        {
            const string sql = "SELECT * FROM EMPLOYEE WHERE ID = @Id";
            return Map(connection.QuerySingleOrDefault<EmployeeRecord>(sql, new { Id = id }));
        }
    }

    public int Add(Employee employee)
    {
        using (var connection = _connectionFactory.Create())
        {
            const string sql = @"
                INSERT INTO EMPLOYEE 
                (REFERENCE, LASTNAME, FIRSTNAME, DATEOFBIRTH, ADDRESSNUMBER, ADDRESSSTREET, ADDRESSCITY, 
                 ADDRESSPOSTALCODE, ADDRESSCOUNTRY, JOINEDCOMPANYDATE, GROSSMONTHLYSALARY, HASCELLPHONEPLAN, NBDAYSYEARLYHOLIDAYS, HASDOUBLEHOLIDAYPREMIUM, HASENDOFYEARPREMIUM)
                VALUES 
                (@Reference, @LastName, @FirstName, @DateOfBirth, @AddressNumber, @AddressStreet, @AddressCity, 
                 @AddressPostalCode, @AddressCountry, @JoinedCompanyDate, @GrossMonthlySalary, @HasCellPhonePlan, @NbDaysYearlyHolidays, @HasDoubleHolidayPremium, @HasEndOfYearPremium);

                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var newIdentifier = connection.QuerySingle<int>(sql, Map(employee));
            employee.Id = newIdentifier;
            return newIdentifier;
        }
    }

    public void Update(Employee employee)
    {
        using (var connection = _connectionFactory.Create())
        {
            const string sql = @"
                UPDATE EMPLOYEE SET
                    REFERENCE = @Reference,
                    LASTNAME = @LastName,
                    FIRSTNAME = @FirstName,
                    DATEOFBIRTH = @DateOfBirth,
                    ADDRESSNUMBER = @AddressNumber,
                    ADDRESSSTREET = @AddressStreet,
                    ADDRESSCITY = @AddressCity,
                    ADDRESSPOSTALCODE = @AddressPostalCode,
                    ADDRESSCOUNTRY = @AddressCountry,
                    JOINEDCOMPANYDATE = @JoinedCompanyDate,
                    GROSSMONTHLYSALARY = @GrossMonthlySalary,
                    HASCELLPHONEPLAN = @HasCellPhonePlan,
                    NBDAYSYEARLYHOLIDAYS = @NbDaysYearlyHolidays
                WHERE ID = @Id";
            
            connection.Execute(sql, Map(employee));
        }
    }

    public void Delete(int id)
    {
        using (var connection = _connectionFactory.Create())
        {
            const string sql = "DELETE FROM EMPLOYEE WHERE ID = @Id";
            connection.Execute(sql, new { Id = id });
        }
    }

    private IEnumerable<Employee> Map(IEnumerable<EmployeeRecord> employeeRecords)
    {
        foreach (var employeeRecord in employeeRecords)
        {
            yield return Map(employeeRecord);
        }
    }

    private Employee Map(EmployeeRecord employeeRecord)
    {
        return new Employee(employeeRecord.FirstName, employeeRecord.LastName)
        {
            Id = employeeRecord.Id,
            Reference = employeeRecord.Reference,
            DateOfBirth = employeeRecord.DateOfBirth,
            AddressNumber = employeeRecord.AddressNumber,
            AddressStreet = employeeRecord.AddressStreet,
            AddressCity = employeeRecord.AddressCity,
            AddressPostalCode = employeeRecord.AddressPostalCode,
            AddressCountry = employeeRecord.AddressCountry,
            JoinedCompanyDate = employeeRecord.JoinedCompanyDate,
            MonthlyGrossSalary = employeeRecord.GrossMonthlySalary.GetValueOrDefault(),
            HasCellPhonePlan = employeeRecord.HasCellPhonePlan,
            NbDaysYearlyHolidays = employeeRecord.NbDaysYearlyHolidays.GetValueOrDefault(),
            HasDoubleHolidayPremium = employeeRecord.HasDoubleHolidayPremium,
            HasEndOfYearPremium = employeeRecord.HasEndOfYearPremium
        };
    }

    private EmployeeRecord Map(Employee employee)
    {
        return new EmployeeRecord
        {
            Id = employee.Id,
            Reference = employee.Reference,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            DateOfBirth = employee.DateOfBirth,
            AddressNumber = employee.AddressNumber,
            AddressStreet = employee.AddressStreet,
            AddressCity = employee.AddressCity,
            AddressPostalCode = employee.AddressPostalCode,
            AddressCountry = employee.AddressCountry,
            JoinedCompanyDate = employee.JoinedCompanyDate,
            GrossMonthlySalary = employee.MonthlyGrossSalary,
            HasCellPhonePlan = employee.HasCellPhonePlan,
            NbDaysYearlyHolidays = employee.NbDaysYearlyHolidays,
            HasDoubleHolidayPremium = employee.HasDoubleHolidayPremium,
            HasEndOfYearPremium = employee.HasEndOfYearPremium
        };
    }
}