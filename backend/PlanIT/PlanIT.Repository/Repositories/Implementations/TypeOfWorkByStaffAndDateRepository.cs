using Cassandra;
using Cassandra.Mapping;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using PlanIT.Repository.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanIT.Repository.Repositories.Implementations
{
    public class TypeOfWorkByStaffAndDateRepository : ITypeOfWorkByStaffAndDateRepository
    {
        public IList<TypeOfWorkByStaffAndDate> GetAllTypeOfWorkByStaffAndDate()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<TypeOfWorkByStaffAndDate> typeOfWork = mapper.Fetch<TypeOfWorkByStaffAndDate>().ToList();

            return typeOfWork;
        }

        public IList<TypeOfWorkByStaffAndDate> GetStaffTypeOfWorkHistory(string staffUsername)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<TypeOfWorkByStaffAndDate> typeOfWork = mapper.Fetch<TypeOfWorkByStaffAndDate>($"WHERE \"{TypeOfWorkByStaffAndDateColumns.StaffUsername}\" = ?", staffUsername).ToList();

            return typeOfWork;
        }

        public string GetTypeOfWorkByStaffAndDate(string staffUsername, LocalDate date)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            var typeOfWork = mapper.Single<TypeOfWorkByStaffAndDate>($"WHERE \"{TypeOfWorkByStaffAndDateColumns.StaffUsername}\" = ? AND \"{TypeOfWorkByStaffAndDateColumns.Date}\" = ?", staffUsername, date);

            return typeOfWork?.TypeOfWork;
        }

        public void AddTypeOfWorkByStaffAndDate(TypeOfWorkByStaffAndDate typeOfWorkByStaffAndDate)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Insert(typeOfWorkByStaffAndDate);
        }

        public void ChangeTypeOfWorkByStaffAndDate(string staffUsername, LocalDate date, string newTypeOfWork)
        {
            throw new NotImplementedException();
        }
    }
}
