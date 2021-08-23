using PlanIT.DataAccess;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface ICompanyRepository
    {
        IList<Company> GetCompanies();

        Company GetCompanyByName(string companyName);

        Company CreateCompany(Company company);

        Company UpdateCompany(Company company);

        void DeleteCompanyByName(string companyName);
    }
}
