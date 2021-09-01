using PlanIT.DataAccess.Models;
using PlanIT.Service.BusinessObjects;
using System.Collections.Generic;

namespace PlanIT.Service.Services.Contracts
{
    public interface IMeetingRoomService
    {
        IList<MeetingRoomBO> GetAllMeetingRooms();

        IList<MeetingRoomBO> GetMeetingRoomsByCompany(string companyName);

        MeetingRoomBO GetMeetingRoomByCompanyAndMeetingRoom(string companyName, string meetingRoom);

        void AddMeetingRoom(MeetingRoomBO meetingRoomBO);

        void UpdateMeetingRoomNumberOfSeats(string companyName, string meetingRoom, int newNumberOfSeats);

        IList<ReservedMeetingRoom> GetAllReservedMeetingRoom();

        IList<ReservedMeetingRoom> GetReservedMeetingRoomByMeetingRoomAndCompany(string meetingRoom, string companyName);

        void ReserveMeetingRoom(ReservedMeetingRoom reservedMeetingRoom);

        void UnReserveMeetingRoom(ReservedMeetingRoom reservedMeetingRoom);
    }
}
