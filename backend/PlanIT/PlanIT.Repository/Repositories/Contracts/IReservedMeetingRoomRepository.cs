using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface IReservedMeetingRoomRepository
    {
        IList<ReservedMeetingRoom> GetAllReservedMeetingRoom();

        IList<ReservedMeetingRoom> GetReservedMeetingRoomByMeetingRoomAndCompany(string meetingRoom, string companyName);

        void ReserveMeetingRoom(ReservedMeetingRoom reservedMeetingRoom);

        void UnReserveMeetingRoom(ReservedMeetingRoom reservedMeetingRoom);
    }
}
