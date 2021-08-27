using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanIT.Api.Models
{
    public class StaffModels
    {
        public record UpdateStaffRequest(string FirstName, string LastName, DateTime DateOfBirth, string Position);

        public record AddRemoveCanCreateUsernamesToCompanyRequest(string StaffUsername);

        public record StaffByCompanyRequestResponse(string StaffUsername, string Position);
    }
}
