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
            throw new NotImplementedException();
        }

        public CompanyBO CreateCompany(CompanyBO company)
        {
            throw new NotImplementedException();
        }

        public CompanyBO UpdateCompany(CompanyBO company)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompanyByName(string companyName)
        {
            throw new NotImplementedException();
        }
    }
}
