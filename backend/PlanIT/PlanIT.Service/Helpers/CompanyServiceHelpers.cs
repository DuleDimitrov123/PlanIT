using PlanIT.DataAccess.Models;
using PlanIT.Service.BusinessObjects;

namespace PlanIT.Service.Helpers
{
    public static class CompanyServiceHelpers
    {
        public static Company MakeCompanyFromCompanyBO(CompanyBO companyBO)
        {
            Company company = new Company()
            {
                CompanyName = companyBO.CompanyName,
                Country = companyBO.Country,
                City = companyBO.City,
                Address = companyBO.Address,
                Description = companyBO.Description,
                NumberOfWorkplaces = companyBO.NumberOfWorkplaces
            };

            return company;
        }

        public static CompanyBO MakeCompanyBOFromCompany(Company company)
        {
            CompanyBO companyBO = new CompanyBO()
            {
                CompanyName = company?.CompanyName,
                Country = company?.Country,
                City = company?.City,
                Address = company?.Address,
                Description = company?.Description,
                NumberOfWorkplaces = company.NumberOfWorkplaces
            };

            return companyBO;
        }
    }
}
