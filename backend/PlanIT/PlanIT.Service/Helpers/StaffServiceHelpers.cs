using PlanIT.DataAccess.Models;
using PlanIT.Service.BusinessObjects;

namespace PlanIT.Service.Helpers
{
    public static class StaffServiceHelpers
    {
        public static Staff MakeStaffFromStaffBO(StaffBO staffBO)
        {
            return new Staff
            {
                Username = staffBO.Username,
                Password = staffBO.Password,
                FirstName = staffBO.FirstName,
                LastName = staffBO.LastName,
                DateOfBirth = staffBO.DateOfBirth,
                CompanyName = staffBO.CompanyName,
                Position = staffBO.Position,
                CanCreate = staffBO.CanCreate
            };
        }

        public static StaffBO MakeStaffBOFromStaff(Staff staff)
        {
            return new StaffBO
            {
                Username = staff.Username,
                Password = staff.Password,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                DateOfBirth = staff.DateOfBirth,
                CompanyName = staff.CompanyName,
                Position = staff.Position,
                CanCreate = staff.CanCreate
            };
        }
    }
}
