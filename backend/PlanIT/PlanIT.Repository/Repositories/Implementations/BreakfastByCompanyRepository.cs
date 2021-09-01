using Cassandra;
using Cassandra.Mapping;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using PlanIT.Repository.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanIT.Repository.Repositories.Implementations
{
    public class BreakfastByCompanyRepository : IBreakfastByCompanyRepository
    {
        public IList<BreakfastByCompany> GetAllBreakfastByCompany()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<BreakfastByCompany> breakfastByCompany = mapper.Fetch<BreakfastByCompany>().ToList();

            return breakfastByCompany;
        }

        public IList<BreakfastByCompany> GetBreakfastByCompany(string companyName)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<BreakfastByCompany> breakfastByCompany = mapper.Fetch<BreakfastByCompany>(
                $"WHERE \"{BreakfastByCompanyColumns.CompanyName}\" = ?", companyName).ToList();

            return breakfastByCompany;
        }

        public IList<BreakfastByCompany> GetBreakfastByCompanyAndDate(string companyName, LocalDate date)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<BreakfastByCompany> breakfastByCompany = mapper.Fetch<BreakfastByCompany>(
                $"WHERE \"{BreakfastByCompanyColumns.CompanyName}\" = ? " +
                $"AND \"{BreakfastByCompanyColumns.Date}\" = ?", companyName, date).ToList();

            return breakfastByCompany;
        }

        public void AddBreakfastByCompany(BreakfastByCompany breakfastByCompany)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Insert(breakfastByCompany);
        }

        public void DeleteBreakfastByCompany(string companyName, LocalDate date, string staffUsername)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            string query = $"WHERE \"{BreakfastByCompanyColumns.CompanyName}\" = ?";
            IList<object> args = new List<object>();
            if(date != null)
            {
                query += $" AND \"{BreakfastByCompanyColumns.Date}\" = ?";
                args.Add(date);
            }
            if(!string.IsNullOrEmpty(staffUsername))
            {
                query += $" AND \"{BreakfastByCompanyColumns.StaffUsername}\" = ?";
                args.Add(staffUsername);
            }

            mapper.Delete<BreakfastByCompany>(query, args.ToArray());
        }
    }
}
