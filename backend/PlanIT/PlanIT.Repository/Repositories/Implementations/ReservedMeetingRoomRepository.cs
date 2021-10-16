using Cassandra;
using Cassandra.Mapping;
using PlanIT.DataAccess.Constants;
using PlanIT.DataAccess.Models;
using PlanIT.Repository.Constants;
using PlanIT.Repository.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanIT.Repository.Repositories.Implementations
{
    public class ReservedMeetingRoomRepository : IReservedMeetingRoomRepository
    {
        public IList<ReservedMeetingRoom> GetAllReservedMeetingRoom()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<ReservedMeetingRoom> reservedMeetingRooms = mapper.Fetch<ReservedMeetingRoom>().ToList();

            return reservedMeetingRooms;
        }

        public IList<ReservedMeetingRoom> GetReservedMeetingRoomByMeetingRoomAndCompany(string meetingRoom, string companyName)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            IList<ReservedMeetingRoom> reservedMeetingRooms = mapper.Fetch<ReservedMeetingRoom>(
                $"WHERE \"{ReservedMeetingRoomColumns.MeetingRoom}\" = ? AND \"{ReservedMeetingRoomColumns.CompanyName}\" = ?",
                meetingRoom, companyName).ToList();

            return reservedMeetingRooms;
        }

        public void ReserveMeetingRoom(ReservedMeetingRoom reservedMeetingRoom)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            mapper.Insert(reservedMeetingRoom);
        }

        public void UnReserveMeetingRoom(ReservedMeetingRoom reservedMeetingRoom)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
            {
                throw new Exception("Database isn't available at the moment, please try again later.");
            }

            IMapper mapper = new Mapper(session);
            var query = $"WHERE \"{ReservedMeetingRoomColumns.MeetingRoom}\" = ? AND " +
                $"\"{ReservedMeetingRoomColumns.CompanyName}\" = ? AND \"{ReservedMeetingRoomColumns.StartDateTime}\" = ? AND \"{ReservedMeetingRoomColumns.EndDateTime}\" = ?;";
            mapper.DeleteIf<ReservedMeetingRoom>(query,reservedMeetingRoom.MeetingRoom, reservedMeetingRoom.CompanyName, reservedMeetingRoom.StartDateTime, reservedMeetingRoom.EndDateTime);
        }
    }
}
