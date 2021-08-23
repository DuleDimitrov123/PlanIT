using PlanIT.Service.BusinessObjects;
using System.Collections.Generic;

namespace PlanIT.Service.Services.Contracts
{
    public interface ICompanyService
    {
        IList<CompanyBO> GetCompanies();

        CompanyBO GetCompanyByName(string companyName);

        CompanyBO CreateCompany(CompanyBO company);

        CompanyBO UpdateCompany(CompanyBO company);

        void DeleteCompanyByName(string companyName);
    }
}
