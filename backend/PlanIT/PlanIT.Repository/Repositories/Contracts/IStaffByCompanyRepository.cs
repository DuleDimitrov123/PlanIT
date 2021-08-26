using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface IStaffByCompanyRepository
    {
        IList<StaffByCompany> GetStaffByCompany(string companyName);

        void AddStaffByCompany(StaffByCompany staffByCompany);

        void RemoveStaffByCompany(StaffByCompany staffByCompany);

        void ChangeStaffPosition(string companyName, string staffUsername, string newPosition);
    }
}
