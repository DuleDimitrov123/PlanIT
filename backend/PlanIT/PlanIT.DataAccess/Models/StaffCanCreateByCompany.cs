using System.Collections.Generic;

namespace PlanIT.DataAccess.Models
{
    public class StaffCanCreateByCompany
    {
        public string CompanyName { get; set; }

        public IList<string> StaffUsernames { get; set; }
    }
}
