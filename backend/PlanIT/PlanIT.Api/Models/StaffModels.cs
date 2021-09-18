using System;

namespace PlanIT.Api.Models
{
    public class StaffModels
    {
        public record UpdateStaffRequest(string FirstName, string LastName, DateTime DateOfBirth, string Position, string CompanyName);

        public record AddRemoveCanCreateUsernamesToCompanyRequest(string StaffUsername);

        public record StaffByCompanyRequestResponse(string StaffUsername, string Position);

        public record GetProfilePictureResponse(string Content);

        public record AddProfilePictureRequest(string StaffUsername, string Content);
    }
}
