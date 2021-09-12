using Cassandra;
using System;
using System.Collections.Generic;

namespace PlanIT.Api.Models
{
    public class BreakfastModels
    {
        public record GetAvailableBreakfastByCompanyAndDateRequest(string CompanyName, DateTime Date);

        public record UpgradeAvailableBreakfastByCompanyRequest(string CompanyName, LocalDate Date, IList<string> NewBreakfastItems);

        public record DowngradeAvailableBreakfastByCompanyRequest(string CompanyName, LocalDate Date, IList<string> RemovableBreakfastItems);

        public record AddAvailableBreakfastByCompanyRequest(string CompanyName, IList<string> BreakfastItems, DateTime Date);

        public record AddSameBreakfastForDateIntervalRequest(string CompanyName, IList<string> BreakfastItems, DateTime StartDate, DateTime EndDate);

        public record GetBreakfastByStaffAndDateRequest(string StaffUsername, DateTime Date);

        public record GetBreakfastByCompanyAndDateRequest(string CompanyName, DateTime Date);

        public record AddBreakfastForDateRequest(string StaffUsername, DateTime Date, IList<string> BreakfastItems);

        public record DeleteBreakfastForDateRequest(string StaffUsername, LocalDate Date);
    }
}
