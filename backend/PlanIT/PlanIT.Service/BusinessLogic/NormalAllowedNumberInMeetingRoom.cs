using PlanIT.DataAccess.Models;
using PlanIT.Service.Services.Contracts;
using System;

namespace PlanIT.Service.BusinessLogic
{
    public class NormalAllowedNumberInMeetingRoom : IAllowedNumberInMeetingRoom
    {
        public bool IsAllowed(IMeetingRoomService meetingRoomService, ReservedMeetingRoom reservedMeetingRoom)
        {
            var meetingRoom = meetingRoomService.GetMeetingRoomByCompanyAndMeetingRoom(reservedMeetingRoom.CompanyName, reservedMeetingRoom.MeetingRoom);

            if (meetingRoom == null)
            {
                throw new Exception($"Meeting room {reservedMeetingRoom.MeetingRoom} doesn't exist in {reservedMeetingRoom.CompanyName}");
            }

            return meetingRoom.NumberOfSeats >= reservedMeetingRoom.NumberOfSeatsUsed;
        }
    }
}
