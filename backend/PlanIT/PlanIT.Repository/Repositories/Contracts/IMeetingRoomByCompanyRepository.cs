using PlanIT.DataAccess.Models;
using System.Collections.Generic;

namespace PlanIT.Repository.Repositories.Contracts
{
    public interface IMeetingRoomByCompanyRepository
    {
        IList<MeetingRoomByCompany> GetAllMeetingRoomByCompany();

        IList<MeetingRoomByCompany> GetMeetingRoomsByCompany(string companyName);

        MeetingRoomByCompany GetMeetingRoomByCompanyAndMeetingRoom(string companyName, string meetingRoom);

        void AddMeetingRoomByCompany(MeetingRoomByCompany meetingRoomByCompany);

        void UpdateMeetingRoomByCompany(MeetingRoomByCompany meetingRoomByCompany);
    }
}
