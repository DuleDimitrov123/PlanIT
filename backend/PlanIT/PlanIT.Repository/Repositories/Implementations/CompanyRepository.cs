using Cassandra;
using PlanIT.DataAccess;
using PlanIT.DataAccess.Constants;
using PlanIT.DataAccess.Helpers;
using PlanIT.Repository.Repositories.Contracts;
using System;
using System.Collections.Generic;

namespace PlanIT.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        public IList<Company> GetCompanies()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later");
            }

            var companyRowSet = session.Execute($"SELECT * FROM {DatabaseNames.Company}");
            IList<Company> companies = CompanyHelper.CreateCompanyFromRowSet(companyRowSet);

            return companies;
        }

        public Company GetCompanyByName(string companyName)
        {
            throw new NotImplementedException();
        }

        public Company CreateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Company UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompanyByName(string companyName)
        {
            throw new NotImplementedException();
        }
    }
}
