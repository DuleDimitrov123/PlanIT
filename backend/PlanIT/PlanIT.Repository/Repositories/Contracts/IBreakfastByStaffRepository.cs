using Cassandra;
using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface IBreakfastByStaffRepository
    {
        IList<BreakfastByStaff> GettAllBreakfastByStaff();

        IList<BreakfastByStaff> GetBreakfastByStaff(string staffUsername);

        IList<string> GetBreakfastByStaffAndDate(string staffUsername, LocalDate date);

        void AddBreakfastByStaff(BreakfastByStaff breakfastByStaff);

        void DeleteBreakfastByStaffAndDate(string staffUsername, LocalDate date);
    }
}
