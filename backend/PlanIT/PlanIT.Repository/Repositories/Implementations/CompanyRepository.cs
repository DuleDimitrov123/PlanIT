using Cassandra;
using Cassandra.Mapping;
using Cassandra.Data.Linq;
using PlanIT.DataAccess.Constants;
using PlanIT.DataAccess.Helpers;
using PlanIT.Repository.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;

namespace PlanIT.Repository.Repositories.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        public IList<Company> GetCompanies()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            var companyRowSet = session.Execute($"SELECT * FROM \"{DatabaseNames.Company}\"");
            IList<Company> companies = CompanyHelper.CreateCompanyFromRowSet(companyRowSet);

            return companies;
        }

        public Company GetCompanyByName(string companyName)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            Company company = mapper.
                Fetch<Company>($"SELECT * FROM \"{DatabaseNames.Company}\" where \"{CompanyColumns.CompanyName}\" = ?", companyName)
                .FirstOrDefault();

            return company;
        }

        public void CreateCompany(Company company)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Insert(company);
        }

        public void UpdateCompany(Company company)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Update<Company>(company);
        }

        public void DeleteCompanyByName(string companyName)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.DeleteIf<Company>($"WHERE \"{CompanyColumns.CompanyName}\" = ?", companyName);
        }
    }
}
