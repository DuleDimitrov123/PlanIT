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
        private readonly IStaffCanCreateByCompanyRepository _staffCanCreateByCompanyRepository;

        public StaffService(IStaffRepository staffRepository, IStaffCanCreateByCompanyRepository staffCanCreateByCompanyRepository)
        {
            _staffRepository = staffRepository;
            _staffCanCreateByCompanyRepository = staffCanCreateByCompanyRepository;
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

            if (staffBO.CanCreate == true)
            {
                AddRemoveCanCreateUsernamesToCompany(staffBO.Username, staffBO.CompanyName, true);
            }
        }

        public void UpdateStaff(string username, string firstName, string lastName, DateTime dateOfBirth, string companyName, string position)
        {
            StaffBO staffBO = GetStaffByUsername(username);
            if(!string.IsNullOrEmpty(firstName))
            {
                staffBO.FirstName = firstName;
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                staffBO.LastName = lastName;
            }

            if(!dateOfBirth.Equals(DateTime.MinValue))
            {
                staffBO.DateOfBirth = new Cassandra.LocalDate(dateOfBirth.Year, dateOfBirth.Month, dateOfBirth.Day);
            }

            if (!string.IsNullOrEmpty(companyName))
            {
                staffBO.CompanyName = companyName;
            }

            if (!string.IsNullOrEmpty(position))
            {
                staffBO.Position = position;
            }

            _staffRepository.UpdateStaff(
                StaffServiceHelpers.MakeStaffFromStaffBO(staffBO));
        }

        public void DeleteStaffByUsername(string username)
        {
            var staff = GetStaffByUsername(username);

            if (staff != null && staff.CanCreate == true)
            {
                AddRemoveCanCreateUsernamesToCompany(username, staff.CompanyName, false);
            }

            _staffRepository.DeleteStaffByUsername(username);
        }

        public IList<string> GetCanCreateUsernamesByCompany(string companyName)
        {
            return _staffCanCreateByCompanyRepository.GetCanCreateUsernamesByCompany(companyName);
        }

        public void AddRemoveCanCreateUsernamesToCompany(string staffUsername, string companyName, bool add)
        {
            var staff = _staffRepository.GetStaffByUsername(staffUsername);

            if (staff != null && !string.IsNullOrEmpty(staff.CompanyName) && companyName.Equals(staff.CompanyName))
            {
                _staffCanCreateByCompanyRepository.AddRemoveCanCreateUsernamesToCompany(staffUsername, companyName, add);
            }
            else
            {
                throw new Exception($"Staff {staffUsername} doesn't work for {companyName}!");
            }
        }

        public IList<StaffCanCreateByCompany> GetStaffCanCreateByCompany()
        {
            return _staffCanCreateByCompanyRepository.GetStaffCanCreateByCompany();
        }
    }
}
