using Cassandra;
using Cassandra.Mapping;
using PlanIT.DataAccess.Constants;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using PlanIT.Repository.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanIT.Repository.Repositories.Implementations
{
    public class StaffByCompanyRepository : IStaffByCompanyRepository
    {
        public IList<StaffByCompany> GetStaffByCompany(string companyName)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            var staff = mapper.Fetch<StaffByCompany>($"WHERE \"{StaffByCompanyColumns.CompanyName}\" = ?", companyName).ToList();

            return staff;
        }

        public void AddStaffByCompany(StaffByCompany staffByCompany)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }
            IMapper mapper = new Mapper(session);
            mapper.Insert<StaffByCompany>(staffByCompany);
        }

        public void RemoveStaffByCompany(StaffByCompany staffByCompany)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }
            IMapper mapper = new Mapper(session);
            mapper.Delete<StaffByCompany>(staffByCompany);
        }

        public void ChangeStaffPosition(string companyName, string staffUsername, string newPosition)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            string query = $"UPDATE \"{DatabaseNames.StaffByCompany}\" SET \"{StaffByCompanyColumns.Position}\" "
                + $"= '{newPosition}' WHERE \"{StaffByCompanyColumns.CompanyName}\" = '{companyName}' AND \"{StaffByCompanyColumns.StaffUsername}\" = '{staffUsername}';";
            session.Execute(query);
        }
    }
}
