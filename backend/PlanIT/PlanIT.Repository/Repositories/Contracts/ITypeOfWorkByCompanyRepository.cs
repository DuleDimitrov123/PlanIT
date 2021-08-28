using Cassandra;
using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface ITypeOfWorkByCompanyRepository
    {
        IList<TypeOfWorkByCompany> GetAllTypeOfWorkByCompany();

        IList<TypeOfWorkByCompany> GetTypeOfWorkByCompany(string companyName);

        IList<TypeOfWorkByCompany> GetTypeOfWorkByCompanyAndDate(string companyName, LocalDate date);

        string GetTypeOfWorkByCompanyDateAndStaffUsername(string companyName, LocalDate date, string staffUsername);

        void AddTypeOfWorkByCompany(TypeOfWorkByCompany typeOfWorkByCompany);

        void AddTypesOfWorkByCompany(IList<TypeOfWorkByCompany> typesOfWorkByCompany);

        void UpdateTypeOfWorkByCompany(TypeOfWorkByCompany typeOfWorkByCompany);
    }
}
