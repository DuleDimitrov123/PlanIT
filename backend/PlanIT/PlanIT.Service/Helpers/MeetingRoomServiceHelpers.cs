using PlanIT.DataAccess.Models;
using PlanIT.Service.BusinessObjects;

namespace PlanIT.Service.Helpers
{
    public static class MeetingRoomServiceHelpers
    {
        public static MeetingRoomBO MakeMeetingRoomBOFromMeetingRoomByCompany(MeetingRoomByCompany meetingRoomByCompany)
        {
            if (meetingRoomByCompany == null)
            {
                return null;
            }
            else
            {
                return new MeetingRoomBO
                {
                    CompanyName = meetingRoomByCompany?.CompanyName,
                    MeetingRoom = meetingRoomByCompany?.MeetingRoom,
                    NumberOfSeats = meetingRoomByCompany.NumberOfSeats
                };
            }
        }

        public static MeetingRoomByCompany MakeMeetingRoomByCompanyFromMeetingRoomBO(MeetingRoomBO meetingRoomBO)
        {
            if (meetingRoomBO == null)
            {
                return null;
            }
            else
            {
                return new MeetingRoomByCompany
                {
                    CompanyName = meetingRoomBO?.CompanyName,
                    MeetingRoom = meetingRoomBO?.MeetingRoom,
                    NumberOfSeats = meetingRoomBO.NumberOfSeats
                };
            }
        }
    }
}
