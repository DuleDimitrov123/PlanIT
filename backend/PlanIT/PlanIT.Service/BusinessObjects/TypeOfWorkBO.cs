using Cassandra;

namespace PlanIT.Service.BusinessObjects
{
    public class TypeOfWorkBO
    {
        public string StaffUsername { get; set; }

        public LocalDate Date { get; set; }

        public string TypeOfWork { get; set; }
    }
}
