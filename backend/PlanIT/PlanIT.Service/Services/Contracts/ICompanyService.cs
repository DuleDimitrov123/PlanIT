using PlanIT.Service.BusinessObjects;
using System.Collections.Generic;

namespace PlanIT.Service.Services.Contracts
{
    public interface ICompanyService
    {
        IList<CompanyBO> GetCompanies();

        CompanyBO GetCompanyByName(string companyName);

        void CreateCompany(CompanyBO companyBO);

        void UpdateCompany(CompanyBO companyBO);

        void DeleteCompanyByName(string companyName);
    }
}
