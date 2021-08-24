using PlanIT.DataAccess;
using PlanIT.Repository.Repositories.Contracts;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Helpers;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;

namespace PlanIT.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IList<CompanyBO> GetCompanies()
        {
            IList<Company> companies = _companyRepository.GetCompanies();

            IList<CompanyBO> companyBOs = new List<CompanyBO>();
            foreach (var company in companies)
            {
                companyBOs.Add(CompanyServiceHelpers.MakeCompanyBOFromCompany(company));
            }

            return companyBOs;
        }

        public CompanyBO GetCompanyByName(string companyName)
        {
            Company company = _companyRepository.GetCompanyByName(companyName);

            CompanyBO companyBO = null;
            if (company != null)
            {
                companyBO = CompanyServiceHelpers.MakeCompanyBOFromCompany(company);
            }

            return companyBO;
        }

        public void CreateCompany(CompanyBO companyBO)
        {
            _companyRepository.CreateCompany(
                CompanyServiceHelpers.MakeCompanyFromCompanyBO(companyBO));
        }

        public void UpdateCompany(CompanyBO companyBO)
        {
            _companyRepository.UpdateCompany(
                CompanyServiceHelpers.MakeCompanyFromCompanyBO(companyBO));
        }

        public void DeleteCompanyByName(string companyName)
        {
            _companyRepository.DeleteCompanyByName(companyName);
            //TODO:Delete in all conected tables
        }
    }
}
