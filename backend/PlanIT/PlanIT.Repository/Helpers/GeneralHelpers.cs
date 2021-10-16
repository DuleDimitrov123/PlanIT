using Cassandra;
using System;

namespace PlanIT.Repository.Helpers
{
    public static class GeneralHelpers
    {
        public static LocalDate ConvertDateTimeToLocalDate(DateTime dateTime)
        {
            return new LocalDate(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public static DateTime ConvertLocalDateToDateTime(LocalDate localDate)
        {
            return new DateTime(localDate.Year, localDate.Month, localDate.Day);
        }
    }
}
