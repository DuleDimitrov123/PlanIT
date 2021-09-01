﻿using Cassandra;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Repositories.Contracts;
using PlanIT.Service.Services.Contracts;
using System.Collections.Generic;

namespace PlanIT.Service.Services.Implementations
{
    public class BreakfastService : IBreakfastService
    {
        private readonly IAvailableBreakfastByCompanyRepository _availableBreakfastByCompanyRepository;
        private readonly IBreakfastByStaffRepository _breakfastByStaffRepository;

        public BreakfastService(IAvailableBreakfastByCompanyRepository availableBreakfastByCompanyRepository,
            IBreakfastByStaffRepository breakfastByStaffRepository)
        {
            _availableBreakfastByCompanyRepository = availableBreakfastByCompanyRepository;
            _breakfastByStaffRepository = breakfastByStaffRepository;
        }

        public IList<AvailableBreakfastByCompany> GetAllAvailableBreakfast()
        {
            return _availableBreakfastByCompanyRepository.GetAllAvailableBreakfast();
        }

        public IList<AvailableBreakfastByCompany> GetAvailableBreakfastByCompany(string companyName)
        {
            return _availableBreakfastByCompanyRepository.GetAvailableBreakfastByCompany(companyName);
        }

        public IList<string> GetAvailableBreakfastByCompanyAndDate(string companyName, LocalDate date)
        {
            return _availableBreakfastByCompanyRepository.GetAvailableBreakfastByCompanyAndDate(companyName, date);
        }

        public void AddAvailableBreakfastByCompany(AvailableBreakfastByCompany availableBreakfastByCompany)
        {
            _availableBreakfastByCompanyRepository.AddAvailableBreakfastByCompany(availableBreakfastByCompany);
        }

        public void UpdateAvailableBreakfastByCompany(string companyName, LocalDate date, IList<string> newBreakfastItems, bool add)
        {
            _availableBreakfastByCompanyRepository.UpdateAvailableBreakfastByCompany(companyName, date, newBreakfastItems, add);
        }

        public void AddSameBreakfastForDateInterval(string companyName, IList<string> breakfastItems, LocalDate startDate, LocalDate endDate)
        {
            _availableBreakfastByCompanyRepository.AddSameBreakfastForDateInterval(companyName, breakfastItems, startDate, endDate);
        }

        public IList<BreakfastByStaff> GettAllBreakfastByStaff()
        {
            return _breakfastByStaffRepository.GettAllBreakfastByStaff();
        }

        public IList<BreakfastByStaff> GetBreakfastByStaff(string staffUsername)
        {
            return _breakfastByStaffRepository.GetBreakfastByStaff(staffUsername);
        }

        public IList<string> GetBreakfastByStaffAndDate(string staffUsername, LocalDate date)
        {
            return _breakfastByStaffRepository.GetBreakfastByStaffAndDate(staffUsername, date);
        }

        public void AddBreakfastByStaff(BreakfastByStaff breakfastByStaff)
        {
            _breakfastByStaffRepository.AddBreakfastByStaff(breakfastByStaff);
        }

        public void DeleteBreakfastByStaffAndDate(string staffUsername, LocalDate date)
        {
            _breakfastByStaffRepository.DeleteBreakfastByStaffAndDate(staffUsername, date);
        }
    }
}
