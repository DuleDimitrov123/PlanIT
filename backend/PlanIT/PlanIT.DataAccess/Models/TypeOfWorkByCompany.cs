using Cassandra;

namespace PlanIT.DataAccess.Models
{
    public class TypeOfWorkByCompany
    {
        public string CompanyName { get; set; }

        public LocalDate Date { get; set; }

        public string StaffUsername { get; set; }

        public string TypeOfWork { get; set; }
    }
}
