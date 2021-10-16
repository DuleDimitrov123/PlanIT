using Cassandra;
using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface IBreakfastByCompanyRepository
    {
        IList<BreakfastByCompany> GetAllBreakfastByCompany();

        IList<BreakfastByCompany> GetBreakfastByCompany(string companyName);

        IList<BreakfastByCompany> GetBreakfastByCompanyAndDate(string companyName, LocalDate date);

        void AddBreakfastByCompany(BreakfastByCompany breakfastByCompany);

        void DeleteBreakfastByCompany(string companyName, LocalDate date, string staffUsername);
    }
}
