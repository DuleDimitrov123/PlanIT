using PlanIT.Service.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanIT.Service.Services.Contracts
{
    public interface IStaffService
    {
        IList<StaffBO> GetStaff();

        StaffBO GetStaffByUsername(string username);

        void CreateStaff(StaffBO staffBO);

        void UpdateStaff(StaffBO staffBO);

        void DeleteStaffByUsername(string username);
    }
}
