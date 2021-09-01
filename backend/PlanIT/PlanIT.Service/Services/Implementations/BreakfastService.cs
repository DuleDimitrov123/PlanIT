using Cassandra;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Repositories.Contracts;
using PlanIT.Service.Services.Contracts;
using System.Collections.Generic;

namespace PlanIT.Service.Services.Implementations
{
    public class BreakfastService : IBreakfastService
    {
        private readonly IAvailableBreakfastByCompanyRepository _availableBreakfastByCompanyRepository;

        public BreakfastService(IAvailableBreakfastByCompanyRepository availableBreakfastByCompanyRepository)
        {
            _availableBreakfastByCompanyRepository = availableBreakfastByCompanyRepository;
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
    }
}
