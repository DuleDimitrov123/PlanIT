using PlanIT.DataAccess.Models;
using PlanIT.Repository.Helpers;
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
        private readonly IStaffByCompanyRepository _staffByCompanyRepository;
        private readonly IProfilePictureByStaffRepository _profilePictureByStaffRepository;

        public StaffService(IStaffRepository staffRepository,
            IStaffCanCreateByCompanyRepository staffCanCreateByCompanyRepository,
            IStaffByCompanyRepository staffByCompanyRepository,
            IProfilePictureByStaffRepository profilePictureByStaffRepository)
        {
            _staffRepository = staffRepository;
            _staffCanCreateByCompanyRepository = staffCanCreateByCompanyRepository;
            _staffByCompanyRepository = staffByCompanyRepository;
            _profilePictureByStaffRepository = profilePictureByStaffRepository;
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

            if (staff == null)
            {
                return null;
            }

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

            if (staffBO.CanCreate == true && !string.IsNullOrEmpty(staffBO.CompanyName))
            {
                AddRemoveCanCreateUsernamesToCompany(staffBO.Username, staffBO.CompanyName, true);
            }

            if (!string.IsNullOrEmpty(staffBO.Position) && !string.IsNullOrEmpty(staffBO.CompanyName))
            {
                AddStaffByCompany(staffBO.CompanyName, staffBO.Username, staffBO.Position);
            }
        }

        public void UpdateStaff(string username, string firstName, string lastName, DateTime dateOfBirth, string position, string companyName)
        {
            StaffBO staffBO = GetStaffByUsername(username);
            if (!string.IsNullOrEmpty(firstName))
            {
                staffBO.FirstName = firstName;
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                staffBO.LastName = lastName;
            }

            if (!dateOfBirth.Equals(DateTime.MinValue))
            {
                staffBO.DateOfBirth = dateOfBirth;
            }

            if (!string.IsNullOrEmpty(position))
            {
                staffBO.Position = position;
                ChangeStaffPosition(staffBO.CompanyName, staffBO.Username, position);
            }

            //You can only change companyName if it is not entered at the beginning and if you try to enter something valid
            if(string.IsNullOrEmpty(staffBO.CompanyName) && !string.IsNullOrEmpty(companyName))
            {
                staffBO.CompanyName = companyName;
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

            if (staff != null && !string.IsNullOrEmpty(staff.CompanyName) && !string.IsNullOrEmpty(staff.Position))
            {
                RemoveStaffByCompany(staff.CompanyName, staff.Username, staff.Position);
            }

            _staffRepository.DeleteStaffByUsername(username);

            _profilePictureByStaffRepository.DeleteProfilePicture(username);
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

        public IList<StaffByCompany> GetStaffByCompany(string companyName)
        {
            return _staffByCompanyRepository.GetStaffByCompany(companyName);
        }

        public void AddStaffByCompany(string companyName, string staffUsername, string position)
        {
            _staffByCompanyRepository.AddStaffByCompany(
                new StaffByCompany
                {
                    CompanyName = companyName,
                    StaffUsername = staffUsername,
                    Position = position
                });
        }

        public void RemoveStaffByCompany(string companyName, string staffUsername, string position)
        {
            _staffByCompanyRepository.RemoveStaffByCompany(
                new StaffByCompany
                {
                    CompanyName = companyName,
                    StaffUsername = staffUsername,
                    Position = position
                });
        }

        public void ChangeStaffPosition(string companyName, string staffUsername, string newPosition)
        {
            _staffByCompanyRepository.ChangeStaffPosition(companyName, staffUsername, newPosition);
        }

        public string GetProfilePicture(string staffUsername)
        {
            return _profilePictureByStaffRepository.GetProfilePicture(staffUsername);
        }

        public void AddProfilePicture(string staffUsername, string content)
        {
            var staff = _staffRepository.GetStaffByUsername(staffUsername);

            if(staff == null)
            {
                throw new Exception($"Staff with username {staffUsername} doesn't exist!");
            }

            _profilePictureByStaffRepository.AddProfilePicture(
                new ProfilePictureByStaff
                {
                    StaffUsername = staffUsername,
                    Content = content
                });
        }

        public void DeleteProfilePicture(string staffUsername)
        {
            _profilePictureByStaffRepository.DeleteProfilePicture(staffUsername);
        }
    }
}
