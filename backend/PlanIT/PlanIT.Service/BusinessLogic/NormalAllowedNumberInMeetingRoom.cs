using PlanIT.DataAccess.Models;
using PlanIT.Service.Services.Contracts;
using System;

namespace PlanIT.Service.BusinessLogic
{
    public class NormalAllowedNumberInMeetingRoom : IAllowedNumberInMeetingRoom
    {
        public bool IsAllowed(int numberOfPeopleForTheMeeting, ReservedMeetingRoom reservedMeetingRoom)
        {
            return numberOfPeopleForTheMeeting >= reservedMeetingRoom.NumberOfSeatsUsed;
        }
    }
}
