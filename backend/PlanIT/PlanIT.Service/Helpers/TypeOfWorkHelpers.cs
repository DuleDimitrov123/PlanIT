using PlanIT.DataAccess.Models;
using PlanIT.Service.BusinessObjects;

namespace PlanIT.Service.Helpers
{
    public static class TypeOfWorkHelpers
    {
        public static TypeOfWorkBO MakeTypeOfWorkBOFromTypeOfWorkByStaffAndDate(TypeOfWorkByStaffAndDate typeOfWorkByStaffAndDate)
        {
            return new TypeOfWorkBO
            {
                StaffUsername = typeOfWorkByStaffAndDate.StaffUsername,
                Date = typeOfWorkByStaffAndDate.Date,
                TypeOfWork = typeOfWorkByStaffAndDate.TypeOfWork
            };
        }

        public static TypeOfWorkByStaffAndDate MakeTypeOfWorkByStaffAndDateFromTypeOfWorkBO(TypeOfWorkBO typeOfWorkBO)
        {
            return new TypeOfWorkByStaffAndDate
            {
                StaffUsername = typeOfWorkBO.StaffUsername,
                Date = typeOfWorkBO.Date,
                TypeOfWork = typeOfWorkBO.TypeOfWork
            };
        }
    }
}
