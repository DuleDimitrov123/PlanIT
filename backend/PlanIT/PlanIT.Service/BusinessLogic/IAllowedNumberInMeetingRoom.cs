using PlanIT.DataAccess.Models;
using PlanIT.Service.Services.Contracts;

namespace PlanIT.Service.BusinessLogic
{
    public interface IAllowedNumberInMeetingRoom
    {
        bool IsAllowed(int numberOfPeopleForTheMeeting, ReservedMeetingRoom reservedMeetingRoom);
    }
}
