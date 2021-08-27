using Cassandra;
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

        void ChangeTypeOfWorkByStaffAndDate(string staffUsername, DateTime date, string newTypeOfWork);
    }
}
