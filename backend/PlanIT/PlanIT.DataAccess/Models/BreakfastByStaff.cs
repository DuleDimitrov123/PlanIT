using Cassandra;
using System.Collections.Generic;

namespace PlanIT.DataAccess.Models
{
    public class BreakfastByStaff
    {
        public string StaffUsername { get; set; }

        public LocalDate Date { get; set; }

        public IList<string> BreakfastItems { get; set; }
    }
}
