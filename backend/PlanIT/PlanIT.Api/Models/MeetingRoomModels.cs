using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanIT.Api.Models
{
    public class MeetingRoomModels
    {
        public record GetMeetingRoomByCompanyAndMeetingRoomRequest(string CompanyName, string MeetingRoom);

        public record UpdateMeetingRoomNumberOfSeatsRequest(string CompanyName, string MeetingRoom, int NewNumberOfSeats);

        public record GetReservedMeetingRoomByMeetingRoomAndCompanyRequest(string MeetingRoom, string CompanyName);

        public record UnReserveMeetingRoomRequest(string MeetingRoom, string CompanyName, DateTime StartDateTime, DateTime EndDateTime, string StaffUsernameWhoReserved, int NumberOfSeatsUsed);
    }
}
