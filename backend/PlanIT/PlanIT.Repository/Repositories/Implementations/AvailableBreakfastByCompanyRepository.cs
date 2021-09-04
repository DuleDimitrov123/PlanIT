using Cassandra;
using Cassandra.Mapping;
using PlanIT.DataAccess.Constants;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using PlanIT.Repository.Helpers;
using PlanIT.Repository.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanIT.Repository.Repositories.Implementations
{
    public class AvailableBreakfastByCompanyRepository : IAvailableBreakfastByCompanyRepository
    {
        public IList<AvailableBreakfastByCompany> GetAllAvailableBreakfast()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<AvailableBreakfastByCompany> availableBreakfastByCompanies = mapper.Fetch<AvailableBreakfastByCompany>().ToList();

            return availableBreakfastByCompanies;
        }

        public IList<AvailableBreakfastByCompany> GetAvailableBreakfastByCompany(string companyName)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<AvailableBreakfastByCompany> availableBreakfastByCompanies = mapper.Fetch<AvailableBreakfastByCompany>(
                $"WHERE \"{AvailableBreakfastByCompanyColumns.CompanyName}\" = ?", companyName).ToList();

            return availableBreakfastByCompanies;
        }

        public IList<string> GetAvailableBreakfastByCompanyAndDate(string companyName, LocalDate date)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            var availableBreakfastByCompany = mapper.Single<AvailableBreakfastByCompany>(
                $"WHERE \"{AvailableBreakfastByCompanyColumns.CompanyName}\" = ? " +
                $"AND \"{AvailableBreakfastByCompanyColumns.Date}\" = ?", companyName, date);

            return availableBreakfastByCompany.BreakfastItems;
        }

        public void AddAvailableBreakfastByCompany(AvailableBreakfastByCompany availableBreakfastByCompany)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Insert(availableBreakfastByCompany);
        }

        public void UpdateAvailableBreakfastByCompany(string companyName, LocalDate date, IList<string> breakfastItems, bool add)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            string items = "";
            foreach (var item in breakfastItems)
            {
                items += $"'{item}', ";
            }
            items = items.Substring(0, items.Length - 2);

            string sign = add ? "+" : "-";

            string query = $"UPDATE \"{DatabaseNames.AvailableBreakfastByCompany}\" SET \"{AvailableBreakfastByCompanyColumns.BreakfastItems}\" = " +
                $"\"{AvailableBreakfastByCompanyColumns.BreakfastItems}\" {sign} [{items}] " +
                $"WHERE \"{AvailableBreakfastByCompanyColumns.CompanyName}\" = '{companyName}' AND \"{AvailableBreakfastByCompanyColumns.Date}\" = '{date}';";

            session.Execute(query);
        }

        public void AddSameBreakfastForDateInterval(string companyName, IList<string> breakfastItems, LocalDate startDate, LocalDate endDate)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);

            DateTime startDateTime = GeneralHelpers.ConvertLocalDateToDateTime(startDate);
            DateTime endDateTime = GeneralHelpers.ConvertLocalDateToDateTime(endDate);

            AvailableBreakfastByCompany availableBreakfastByCompany;
            for (DateTime date = startDateTime; date <= endDateTime; date = date.AddDays(1))
            {
                availableBreakfastByCompany = new AvailableBreakfastByCompany
                {
                    CompanyName = companyName,
                    Date = GeneralHelpers.ConvertDateTimeToLocalDate(date),
                    BreakfastItems = breakfastItems
                };

                mapper.Insert(availableBreakfastByCompany);
            }
        }
    }
}
