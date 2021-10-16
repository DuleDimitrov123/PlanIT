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

        public bool IsAllowed(int numberOfPeopleForTheMeeting, ReservedMeetingRoom reservedMeetingRoom)
        {
            double allowedPercentage = double.Parse(_configuration["ApplicationConstants:AllowedPercentageInMeetingRoom"]);
            double reservedPercentage = 100.0 * ((double)reservedMeetingRoom.NumberOfSeatsUsed / (double)numberOfPeopleForTheMeeting);

            return allowedPercentage >= reservedPercentage;
        }
    }
}
