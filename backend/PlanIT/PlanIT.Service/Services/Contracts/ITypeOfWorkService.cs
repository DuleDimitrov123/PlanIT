using PlanIT.Service.BusinessObjects;
using System;
using System.Collections.Generic;

namespace PlanIT.Service.Services.Contracts
{
    public interface ITypeOfWorkService
    {
        IList<TypeOfWorkBO> GetAllTypeOfWorkByStaffAndDate();

        IList<TypeOfWorkBO> GetStaffTypeOfWorkHistory(string staffUsername);

        string GetTypeOfWorkByStaffAndDate(string staffUsername, DateTime date);

        void AddTypeOfWorkByStaffAndDate(string staffUsername, DateTime date, string typeOfWork);

        void AddTypeOfWorkByStaffAndDates(string staffUsername, DateTime startDate, DateTime endDate, string typeOfWork);

        void ChangeTypeOfWorkByStaffAndDate(string staffUsername, DateTime date, string newTypeOfWork);

        IList<ExtendedTypeOfWorkBO> GetAllTypeOfWorkByCompany();

        IList<ExtendedTypeOfWorkBO> GetTypeOfWorkByCompany(string companyName);

        IList<ExtendedTypeOfWorkBO> GetTypeOfWorkByCompanyAndDate(string companyName, DateTime date);

        string GetTypeOfWorkByCompanyDateAndStaffUsername(string companyName, DateTime date, string staffUsername);

        void AddTypeOfWorkByCompany(ExtendedTypeOfWorkBO typeOfWorkBO);

        void AddTypesOfWorkByCompany(string companyName, DateTime startDate, DateTime endDate, string staffUsername, string typeOfWork);

        void ChangeTypeOfWorkByCompany(string companyName, DateTime date, string staffUsername, string newTypeOfWork);

        void AddTypeOfWork(ExtendedTypeOfWorkBO extendedTypeOfWorkBO);

        void AddTypesOfWork(string companyName, DateTime startDate, DateTime endDate, string staffUsername, string typeOfWork);
    }
}
