using System;

namespace PartsUnlimited.HRCost.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int Reference { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressNumber { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressCountry { get; set; }
        public DateTime JoinedCompanyDate { get; set; }
        public decimal MonthlyGrossSalary { get; set; }
        public bool IsGrantedCar { get; set; }
        public int NbDaysYearlyHolidays { get; set; }
        public decimal YearlyGrossSalaryCost => 
            12 * MonthlyGrossSalary 
            + (HasDoubleHolidayPremium ? 0.92m * MonthlyGrossSalary : 0m )
            + (HasEndOfYearPremium ? MonthlyGrossSalary : 0m );
        public bool HasDoubleHolidayPremium { get; set; }
        public bool HasEndOfYearPremium { get; set; }
    }
}