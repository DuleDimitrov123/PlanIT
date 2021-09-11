using Cassandra;
using System;

namespace PlanIT.Service.BusinessObjects
{
    public class StaffBO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public bool CanCreate { get; set; }
    }
}
