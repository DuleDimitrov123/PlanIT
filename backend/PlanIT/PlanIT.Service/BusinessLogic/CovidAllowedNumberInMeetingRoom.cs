using Microsoft.Extensions.Configuration;
using PlanIT.DataAccess.Models;
using PlanIT.Service.Services.Contracts;
using System;

namespace PlanIT.Service.BusinessLogic
{
    public class CovidAllowedNumberInMeetingRoom : IAllowedNumberInMeetingRoom
    {
        private readonly IConfiguration _configuration;

        public CovidAllowedNumberInMeetingRoom(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsAllowed(IMeetingRoomService meetingRoomService, ReservedMeetingRoom reservedMeetingRoom)
        {
            var meetingRoom = meetingRoomService.GetMeetingRoomByCompanyAndMeetingRoom(reservedMeetingRoom.CompanyName, reservedMeetingRoom.MeetingRoom);

            if (meetingRoom == null)
            {
                throw new Exception($"Meeting room {reservedMeetingRoom.MeetingRoom} doesn't exist in {reservedMeetingRoom.CompanyName}");
            }

            double allowedPercentage = double.Parse(_configuration["ApplicationConstants:AllowedPercentageInMeetingRoom"]);
            double reservedPercentage = 100.0 * ((double)reservedMeetingRoom.NumberOfSeatsUsed / (double)meetingRoom.NumberOfSeats);

            return allowedPercentage >= reservedPercentage;
        }
    }
}
