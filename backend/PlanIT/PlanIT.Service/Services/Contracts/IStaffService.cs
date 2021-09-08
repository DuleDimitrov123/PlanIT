using PlanIT.DataAccess.Models;
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

        void UpdateStaff(string username, string firstName, string lastName, DateTime dateOfBirth, string position, string companyName);

        void DeleteStaffByUsername(string username);

        IList<StaffCanCreateByCompany> GetStaffCanCreateByCompany();

        IList<string> GetCanCreateUsernamesByCompany(string companyName);

        void AddRemoveCanCreateUsernamesToCompany(string staffUsername, string companyName, bool add);

        IList<StaffByCompany> GetStaffByCompany(string companyName);

        void AddStaffByCompany(string companyName, string staffUsername, string position);

        void RemoveStaffByCompany(string companyName, string staffUsername, string position);

        void ChangeStaffPosition(string companyName, string staffUsername, string newPosition);
    }
}
