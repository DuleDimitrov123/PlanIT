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
    public class BreakfastByStaffRepository : IBreakfastByStaffRepository
    {
        public IList<BreakfastByStaff> GettAllBreakfastByStaff()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<BreakfastByStaff> breakfastByStaffs = mapper.Fetch<BreakfastByStaff>().ToList();

            return breakfastByStaffs;
        }

        public IList<BreakfastByStaff> GetBreakfastByStaff(string staffUsername)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<BreakfastByStaff> breakfastByStaffs = mapper.Fetch<BreakfastByStaff>(
                $"WHERE \"{BreakfastByStaffColumns.StaffUsername}\" = ?", staffUsername).ToList();

            return breakfastByStaffs;
        }

        public IList<string> GetBreakfastByStaffAndDate(string staffUsername, LocalDate date)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            /*BreakfastByStaff breakfastByStaffs = mapper.Single<BreakfastByStaff>(
                $"WHERE \"{BreakfastByStaffColumns.StaffUsername}\" = ? "+
                $"AND \"{BreakfastByStaffColumns.Date}\" = ?", staffUsername, date);*/

            BreakfastByStaff breakfastByStaff = mapper.Fetch<BreakfastByStaff>(
                $"WHERE \"{BreakfastByStaffColumns.StaffUsername}\" = ? " +
                $"AND \"{BreakfastByStaffColumns.Date}\" = ?", staffUsername, date).FirstOrDefault();

            if(breakfastByStaff == null)
            {
                return new List<string>();
            }

            return breakfastByStaff.BreakfastItems;
        }
        public void AddBreakfastByStaff(BreakfastByStaff breakfastByStaff)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Insert(breakfastByStaff);
        }

        public void DeleteBreakfastByStaffAndDate(string staffUsername, LocalDate date)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Delete<BreakfastByStaff>($"WHERE \"{BreakfastByStaffColumns.StaffUsername}\" = ? AND " +
                $"\"{BreakfastByStaffColumns.Date}\" = ?", staffUsername, date);
        }
    }
}
