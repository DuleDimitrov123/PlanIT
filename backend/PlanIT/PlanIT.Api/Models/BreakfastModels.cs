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

        public record GetBreakfastByStaffAndDateRequest(string StaffUsername, LocalDate Date);

        public record GetBreakfastByCompanyAndDateRequest(string CompanyName, LocalDate Date);

        public record AddBreakfastForDateRequest(string StaffUsername, LocalDate Date, IList<string> BreakfastItems);

        public record DeleteBreakfastForDateRequest(string StaffUsername, LocalDate Date);
    }
}
