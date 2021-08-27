using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface IStaffCanCreateByCompanyRepository
    {
        IList<StaffCanCreateByCompany> GetStaffCanCreateByCompany();

        IList<string> GetCanCreateUsernamesByCompany(string companyName);

        void AddRemoveCanCreateUsernamesToCompany(string staffUsername, string companyName, bool add);
    }
}
