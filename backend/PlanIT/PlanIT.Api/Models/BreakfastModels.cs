using Cassandra;
using System.Collections.Generic;

namespace PlanIT.Api.Models
{
    public class BreakfastModels
    {
        public record GetAvailableBreakfastByCompanyAndDateRequest(string CompanyName, LocalDate Date);

        public record UpgradeAvailableBreakfastByCompanyRequest(string CompanyName, LocalDate Date, IList<string> NewBreakfastItems);

        public record DowngradeAvailableBreakfastByCompanyRequest(string CompanyName, LocalDate Date, IList<string> RemovableBreakfastItems);

        public record AddSameBreakfastForDateIntervalRequest(string CompanyName, IList<string> BreakfastItems, LocalDate StartDate, LocalDate EndDate);
    }
}
