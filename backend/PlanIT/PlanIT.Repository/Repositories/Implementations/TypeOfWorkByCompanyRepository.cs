using Cassandra;
using Cassandra.Mapping;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using PlanIT.Repository.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanIT.Repository.Repositories.Implementations
{
    public class TypeOfWorkByCompanyRepository : ITypeOfWorkByCompanyRepository
    {
        public IList<TypeOfWorkByCompany> GetAllTypeOfWorkByCompany()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<TypeOfWorkByCompany> typeOfWork = mapper.Fetch<TypeOfWorkByCompany>().ToList();

            return typeOfWork;
        }

        public IList<TypeOfWorkByCompany> GetTypeOfWorkByCompany(string companyName)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<TypeOfWorkByCompany> typeOfWork = mapper.Fetch<TypeOfWorkByCompany>($"WHERE \"{TypeOfWorkByCompanyColumns.CompanyName}\" = ?", companyName).ToList();

            return typeOfWork;
        }

        public IList<TypeOfWorkByCompany> GetTypeOfWorkByCompanyAndDate(string companyName, LocalDate date)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<TypeOfWorkByCompany> typeOfWork = mapper.Fetch<TypeOfWorkByCompany>($"WHERE \"{TypeOfWorkByCompanyColumns.CompanyName}\" = ? "
                + $"AND \"{TypeOfWorkByCompanyColumns.Date}\" = ?", companyName, date).ToList();

            return typeOfWork;
        }

        public string GetTypeOfWorkByCompanyDateAndStaffUsername(string companyName, LocalDate date, string staffUsername)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            var typeOfWork = mapper.Single<TypeOfWorkByCompany>($"WHERE \"{TypeOfWorkByCompanyColumns.CompanyName}\" = ? "
                + $"AND \"{TypeOfWorkByCompanyColumns.Date}\" = ? AND \"{TypeOfWorkByCompanyColumns.StaffUsername}\" = ?",
                companyName, date, staffUsername);

            return typeOfWork?.TypeOfWork;
        }

        public void AddTypeOfWorkByCompany(TypeOfWorkByCompany typeOfWorkByCompany)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Insert(typeOfWorkByCompany);
        }

        public void AddTypesOfWorkByCompany(IList<TypeOfWorkByCompany> typesOfWorkByCompany)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            foreach(var typeOfWorkByCompany in typesOfWorkByCompany)
            {
                mapper.Insert(typeOfWorkByCompany);
            }
        }

        public void UpdateTypeOfWorkByCompany(TypeOfWorkByCompany typeOfWorkByCompany)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Update(typeOfWorkByCompany);
        }
    }
}
