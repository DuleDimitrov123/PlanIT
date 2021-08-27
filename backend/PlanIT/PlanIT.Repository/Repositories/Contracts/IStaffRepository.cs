using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface IStaffRepository
    {
        IList<Staff> GetStaff();

        Staff GetStaffByUsername(string username);

        void CreateStaff(Staff staff);

        void UpdateStaff(Staff staff);

        void DeleteStaffByUsername(string username);
    }
}
