using PlanIT.DataAccess.Models;
using PlanIT.Repository.Repositories.Contracts;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Helpers;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;

namespace PlanIT.Service.Services.Implementations
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public IList<StaffBO> GetStaff()
        {
            IList<Staff> staff = _staffRepository.GetStaff();

            IList<StaffBO> staffBOs = new List<StaffBO>();
            foreach (var s in staff)
            {
                staffBOs.Add(StaffServiceHelpers.MakeStaffBOFromStaff(s));
            }

            return staffBOs;
        }

        public StaffBO GetStaffByUsername(string username)
        {
            var staff = _staffRepository.GetStaffByUsername(username);
            var staffBO = StaffServiceHelpers.MakeStaffBOFromStaff(staff);
            return staffBO;
        }

        public void CreateStaff(StaffBO staffBO)
        {
            if (_staffRepository.GetStaffByUsername(staffBO.Username) != null)
            {
                throw new Exception("User with this username already exists!");
            }

                _staffRepository.CreateStaff(
                    StaffServiceHelpers.MakeStaffFromStaffBO(staffBO));
        }

        public void UpdateStaff(StaffBO staffBO)
        {
            _staffRepository.UpdateStaff(
                StaffServiceHelpers.MakeStaffFromStaffBO(staffBO));
        }

        public void DeleteStaffByUsername(string username)
        {
            _staffRepository.DeleteStaffByUsername(username);
        }
    }
}
