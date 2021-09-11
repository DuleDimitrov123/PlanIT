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
    public class MeetingRoomByCompanyRepository : IMeetingRoomByCompanyRepository
    {
        public IList<MeetingRoomByCompany> GetAllMeetingRoomByCompany()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<MeetingRoomByCompany> meetingRooms = mapper.Fetch<MeetingRoomByCompany>().ToList();

            return meetingRooms;
        }

        public IList<MeetingRoomByCompany> GetMeetingRoomsByCompany(string companyName)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<MeetingRoomByCompany> meetingRooms = mapper.Fetch<MeetingRoomByCompany>(
                $"WHERE \"{MeetingRoomByCompanyColumns.CompanyName}\" = ?", companyName).ToList();

            return meetingRooms;
        }

        public MeetingRoomByCompany GetMeetingRoomByCompanyAndMeetingRoom(string companyName, string meetingRoom)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            /*MeetingRoomByCompany mr = mapper.Single<MeetingRoomByCompany>(
                $"WHERE \"{MeetingRoomByCompanyColumns.CompanyName}\" = ? AND \"{MeetingRoomByCompanyColumns.MeetingRoom}\" = ?",
                companyName, meetingRoom);*/

            MeetingRoomByCompany mr = mapper.Fetch<MeetingRoomByCompany>(
                $"WHERE \"{MeetingRoomByCompanyColumns.CompanyName}\" = ? AND \"{MeetingRoomByCompanyColumns.MeetingRoom}\" = ?",
                companyName, meetingRoom).FirstOrDefault();

            return mr;
        }

        public void AddMeetingRoomByCompany(MeetingRoomByCompany meetingRoomByCompany)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Insert(meetingRoomByCompany);
        }

        public void UpdateMeetingRoomByCompany(MeetingRoomByCompany meetingRoomByCompany)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Update(meetingRoomByCompany);
        }
    }
}
