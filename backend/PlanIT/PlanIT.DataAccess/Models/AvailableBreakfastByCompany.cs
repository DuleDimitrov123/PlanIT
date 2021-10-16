using Cassandra;
using System.Collections.Generic;

namespace PlanIT.DataAccess.Models
{
    public class AvailableBreakfastByCompany
    {
        public string CompanyName { get; set; }

        public LocalDate Date { get; set; }

        public IList<string> BreakfastItems { get; set; }
    }
}
