﻿using Cassandra;
using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Service.Services.Contracts
{
    public interface IBreakfastService
    {
        IList<AvailableBreakfastByCompany> GetAllAvailableBreakfast();

        IList<AvailableBreakfastByCompany> GetAvailableBreakfastByCompany(string companyName);

        IList<string> GetAvailableBreakfastByCompanyAndDate(string companyName, LocalDate date);

        void AddAvailableBreakfastByCompany(AvailableBreakfastByCompany availableBreakfastByCompany);

        void AddSameBreakfastForDateInterval(string companyName, IList<string> breakfastItems, LocalDate startDate, LocalDate endDate);

        void UpdateAvailableBreakfastByCompany(string companyName, LocalDate date, IList<string> newBreakfastItems, bool add);

        IList<BreakfastByStaff> GettAllBreakfastByStaff();

        IList<BreakfastByStaff> GetBreakfastByStaff(string staffUsername);

        IList<string> GetBreakfastByStaffAndDate(string staffUsername, LocalDate date);

        void AddBreakfastByStaff(BreakfastByStaff breakfastByStaff);

        void DeleteBreakfastByStaffAndDate(string staffUsername, LocalDate date);

        IList<BreakfastByCompany> GetAllBreakfastByCompany();

        IList<BreakfastByCompany> GetBreakfastByCompany(string companyName);

        IList<BreakfastByCompany> GetBreakfastByCompanyAndDate(string companyName, LocalDate date);

        void AddBreakfastByCompany(BreakfastByCompany breakfastByCompany);

        void DeleteBreakfastByCompany(string companyName, LocalDate date, string staffUsername);

        void AddBreakfastForDate(string staffUsername, LocalDate date, IList<string> breakfastItems);

        void DeleteBreakfastForDate(string staffUsername, LocalDate date);
    }
}