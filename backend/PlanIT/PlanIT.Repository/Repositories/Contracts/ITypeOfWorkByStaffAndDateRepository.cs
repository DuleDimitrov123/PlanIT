using Cassandra;
using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface ITypeOfWorkByStaffAndDateRepository
    {
        IList<TypeOfWorkByStaffAndDate> GetAllTypeOfWorkByStaffAndDate();

        IList<TypeOfWorkByStaffAndDate> GetStaffTypeOfWorkHistory(string staffUsername);

        string GetTypeOfWorkByStaffAndDate(string staffUsername, LocalDate date);

        void AddTypeOfWorkByStaffAndDate(TypeOfWorkByStaffAndDate typeOfWorkByStaffAndDate);

        void AddTypeOfWorkByStaffAndDates(IList<TypeOfWorkByStaffAndDate> typeOfWorkByStaffAndDates);

        void ChangeTypeOfWorkByStaffAndDate(string staffUsername, LocalDate date, string newTypeOfWork);
    }
}
