using Cassandra;
using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface IAvailableBreakfastByCompanyRepository
    {
        IList<AvailableBreakfastByCompany> GetAllAvailableBreakfast();

        IList<AvailableBreakfastByCompany> GetAvailableBreakfastByCompany(string companyName);

        IList<string> GetAvailableBreakfastByCompanyAndDate(string companyName, LocalDate date);

        void AddAvailableBreakfastByCompany(AvailableBreakfastByCompany availableBreakfastByCompany);

        void AddSameBreakfastForDateInterval(string companyName, IList<string> breakfastItems, LocalDate startDate, LocalDate endDate);

        void UpdateAvailableBreakfastByCompany(string companyName, LocalDate date, IList<string> breakfastItems, bool add);
    }
}
