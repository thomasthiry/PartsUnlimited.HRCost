using System;

namespace PartsUnlimited.HRCost.Domain.Entities
{
    public class Employee
    {
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public int Reference { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AddressNumber { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressCountry { get; set; }
        public DateTime? JoinedCompanyDate { get; set; }
        public decimal MonthlyGrossSalary { get; set; }
        public int NbDaysYearlyHolidays { get; set; }
        public decimal YearlyGrossSalaryCost => 
            12 * MonthlyGrossSalary 
            + (HasDoubleHolidayPremium ? 0.92m * MonthlyGrossSalary : 0m )
            + (HasEndOfYearPremium ? MonthlyGrossSalary : 0m );
        public bool HasDoubleHolidayPremium { get; set; }
        public bool HasEndOfYearPremium { get; set; }
        public decimal YearlyEmployerTax => YearlyGrossSalaryCost * 0.3m;
        public bool HasCellPhonePlan { get; set; }
        public decimal CellPhonePlanCost => HasCellPhonePlan ? 12 * 50m : 0m;

        protected bool Equals(Employee other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Employee)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Employee left, Employee right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Employee left, Employee right)
        {
            return !Equals(left, right);
        }
    }
}