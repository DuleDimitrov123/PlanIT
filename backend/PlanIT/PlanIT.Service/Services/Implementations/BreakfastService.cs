using Cassandra;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Helpers;
using PlanIT.Repository.Repositories.Contracts;
using PlanIT.Service.BusinessLogic;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanIT.Service.Services.Implementations
{
    public class BreakfastService : IBreakfastService
    {
        private readonly IAvailableBreakfastByCompanyRepository _availableBreakfastByCompanyRepository;
        private readonly IBreakfastByStaffRepository _breakfastByStaffRepository;
        private readonly IBreakfastByCompanyRepository _breakfastByCompanyRepository;

        private readonly IStaffService _staffService;

        public BreakfastService(IAvailableBreakfastByCompanyRepository availableBreakfastByCompanyRepository,
            IBreakfastByStaffRepository breakfastByStaffRepository,
            IBreakfastByCompanyRepository breakfastByCompanyRepository,
            IStaffService staffService)
        {
            _availableBreakfastByCompanyRepository = availableBreakfastByCompanyRepository;
            _breakfastByStaffRepository = breakfastByStaffRepository;
            _breakfastByCompanyRepository = breakfastByCompanyRepository;
            _staffService = staffService;
        }

        public IList<AvailableBreakfastByCompany> GetAllAvailableBreakfast()
        {
            return _availableBreakfastByCompanyRepository.GetAllAvailableBreakfast();
        }

        public IList<AvailableBreakfastByCompany> GetAvailableBreakfastByCompany(string companyName)
        {
            return _availableBreakfastByCompanyRepository.GetAvailableBreakfastByCompany(companyName);
        }

        public IList<string> GetAvailableBreakfastByCompanyAndDate(string companyName, DateTime date)
        {
            return _availableBreakfastByCompanyRepository.GetAvailableBreakfastByCompanyAndDate(
                companyName, 
                GeneralHelpers.ConvertDateTimeToLocalDate(date));
        }

        public void AddAvailableBreakfastByCompany(string companyName, IList<string> breakfastItems, DateTime date)
        {
            _availableBreakfastByCompanyRepository.AddAvailableBreakfastByCompany(
                new AvailableBreakfastByCompany
                {
                    CompanyName = companyName,
                    Date = GeneralHelpers.ConvertDateTimeToLocalDate(date),
                    BreakfastItems = breakfastItems
                });
        }

        public void UpdateAvailableBreakfastByCompany(string companyName, LocalDate date, IList<string> newBreakfastItems, bool add)
        {
            _availableBreakfastByCompanyRepository.UpdateAvailableBreakfastByCompany(companyName, date, newBreakfastItems, add);
        }

        public void AddSameBreakfastForDateInterval(string companyName, IList<string> breakfastItems, DateTime startDate, DateTime endDate)
        {
            _availableBreakfastByCompanyRepository.AddSameBreakfastForDateInterval(
                companyName, 
                breakfastItems, 
                GeneralHelpers.ConvertDateTimeToLocalDate(startDate), 
                GeneralHelpers.ConvertDateTimeToLocalDate(endDate));
        }

        public IList<BreakfastByStaff> GettAllBreakfastByStaff()
        {
            return _breakfastByStaffRepository.GettAllBreakfastByStaff();
        }

        public IList<BreakfastByStaff> GetBreakfastByStaff(string staffUsername)
        {
            return _breakfastByStaffRepository.GetBreakfastByStaff(staffUsername);
        }

        public IList<string> GetBreakfastByStaffAndDate(string staffUsername, DateTime date)
        {
            return _breakfastByStaffRepository.GetBreakfastByStaffAndDate(
                staffUsername, 
                GeneralHelpers.ConvertDateTimeToLocalDate(date));
        }

        public void AddBreakfastByStaff(BreakfastByStaff breakfastByStaff)
        {
            _breakfastByStaffRepository.AddBreakfastByStaff(breakfastByStaff);
        }

        public void DeleteBreakfastByStaffAndDate(string staffUsername, LocalDate date)
        {
            _breakfastByStaffRepository.DeleteBreakfastByStaffAndDate(staffUsername, date);
        }

        public IList<BreakfastByCompany> GetAllBreakfastByCompany()
        {
            return _breakfastByCompanyRepository.GetAllBreakfastByCompany();
        }

        public IList<BreakfastByCompany> GetBreakfastByCompany(string companyName)
        {
            return _breakfastByCompanyRepository.GetBreakfastByCompany(companyName);
        }

        public IList<BreakfastByCompany> GetBreakfastByCompanyAndDate(string companyName, DateTime date)
        {
            return _breakfastByCompanyRepository.GetBreakfastByCompanyAndDate(
                companyName,
                GeneralHelpers.ConvertDateTimeToLocalDate(date));
        }

        public void AddBreakfastByCompany(BreakfastByCompany breakfastByCompany)
        {
            _breakfastByCompanyRepository.AddBreakfastByCompany(breakfastByCompany);
        }

        public void DeleteBreakfastByCompany(string companyName, LocalDate date, string staffUsername)
        {
            _breakfastByCompanyRepository.DeleteBreakfastByCompany(companyName, date, staffUsername);
        }

        public void AddBreakfastForDate(string staffUsername, DateTime date, IList<string> breakfastItems)
        {
            //get my company
            var company = _staffService.GetStaffByUsername(staffUsername).CompanyName;

            if (string.IsNullOrEmpty(company))
            {
                throw new Exception($"{staffUsername} doesn't have company!");
            }

            //check if that breakfast exists in company for date
            var allBreakfasts = GetAvailableBreakfastByCompanyAndDate(
                company,
                date);

            if (allBreakfasts.Count() == 0)
            {
                throw new Exception($"Your company doesn't provide breakfasts!");
            }

            var notAvailable = new List<string>();
            var available = new List<string>();
            foreach (var item in breakfastItems)
            {
                if (!allBreakfasts.Contains(item))
                {
                    notAvailable.Add(item);
                }
                else
                {
                    available.Add(item);
                }
            }

            if (available.Count() != 0)
            {
                AddBreakfastByCompany(new BreakfastByCompany
                {
                    CompanyName = company,
                    Date = GeneralHelpers.ConvertDateTimeToLocalDate(date),
                    StaffUsername = staffUsername,
                    BreakfastItems = available
                });

                AddBreakfastByStaff(new BreakfastByStaff
                {
                    StaffUsername = staffUsername,
                    Date = GeneralHelpers.ConvertDateTimeToLocalDate(date),
                    BreakfastItems = available
                });
            }

            if (notAvailable.Count() != 0)
            {
                throw new NotAvailableBreakfastItemsException(notAvailable);
            }
        }

        public void DeleteBreakfastForDate(string staffUsername, LocalDate date)
        {
            //get my company
            var company = _staffService.GetStaffByUsername(staffUsername).CompanyName;

            if (string.IsNullOrEmpty(company))
            {
                throw new Exception($"{staffUsername} doesn't have company!");
            }

            //delete breakfast by staff
            DeleteBreakfastByStaffAndDate(staffUsername, date);

            //delete breakfast by company
            DeleteBreakfastByCompany(company, date, staffUsername);
        }
    }
}
