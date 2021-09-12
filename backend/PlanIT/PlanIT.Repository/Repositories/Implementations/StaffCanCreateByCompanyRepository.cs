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
    public class StaffCanCreateByCompanyRepository : IStaffCanCreateByCompanyRepository
    {
        public IList<StaffCanCreateByCompany> GetStaffCanCreateByCompany()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            var rowSet = session.Execute($"SELECT * FROM \"{DatabaseNames.StaffCanCreateByCompany}\"");
            IList<StaffCanCreateByCompany> staffCanCreateByCompanies = StaffHelpers.CreateStaffCanCreateByCompanyFromRowSet(rowSet);

            return staffCanCreateByCompanies;
        }

        public IList<string> GetCanCreateUsernamesByCompany(string companyName)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }
            IMapper mapper = new Mapper(session);
            /*var staffCanCreateByCompany = mapper.Single<StaffCanCreateByCompany>(
                $"WHERE \"{StaffCanCreateByCompanyColumns.CompanyName}\" = ?", companyName);*/

            var staffCanCreateByCompany = mapper.Fetch<StaffCanCreateByCompany>(
                $"WHERE \"{StaffCanCreateByCompanyColumns.CompanyName}\" = ?", companyName).FirstOrDefault();

            if(staffCanCreateByCompany == null)
            {
                return new List<string>();
            }

            return staffCanCreateByCompany.StaffUsernames;
        }

        public void AddRemoveCanCreateUsernamesToCompany(string staffUsername, string companyName, bool add)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            //+ is for adding element in the list, and - is for removing in CQL
            string sign = add ? "+" : "-";

            string query = $"UPDATE \"{DatabaseNames.StaffCanCreateByCompany}\" SET \"{StaffCanCreateByCompanyColumns.StaffUsernames}\" = "
                + $"\"{StaffCanCreateByCompanyColumns.StaffUsernames}\" {sign} ['{staffUsername}'] WHERE \"{StaffCanCreateByCompanyColumns.CompanyName}\""
                + $" = '{companyName}';";
            session.Execute(query);
        }
    }
}
