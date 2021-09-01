using Cassandra;
using System.Collections.Generic;

namespace PlanIT.DataAccess.Models
{
    public class BreakfastByCompany
    {
        public string CompanyName { get; set; }

        public LocalDate Date { get; set; }

        public string StaffUsername { get; set; }

        public IList<string> BreakfastItems { get; set; }
    }
}
