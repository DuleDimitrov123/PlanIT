using Cassandra;

namespace PlanIT.DataAccess.Models
{
    public class TypeOfWorkByStaffAndDate
    {
        public string StaffUsername { get; set; }

        public LocalDate Date { get; set; }

        public string TypeOfWork { get; set; }
    }
}
