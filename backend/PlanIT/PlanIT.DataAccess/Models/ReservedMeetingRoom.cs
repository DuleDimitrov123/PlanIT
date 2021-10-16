using System;

namespace PlanIT.DataAccess.Models
{
    public class ReservedMeetingRoom
    {
        public string MeetingRoom { get; set; }

        public string CompanyName { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string StaffUsernameWhoReserved { get; set; }

        public int NumberOfSeatsUsed { get; set; }
    }
}
