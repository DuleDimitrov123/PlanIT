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

        public static ExtendedTypeOfWorkBO MakeExtendedTypeOfWorkBOFromTypeOfWorkByCompany(TypeOfWorkByCompany typeOfWorkByCompany)
        {
            return new ExtendedTypeOfWorkBO
            {
                CompanyName = typeOfWorkByCompany.CompanyName,
                StaffUsername = typeOfWorkByCompany.StaffUsername,
                Date = typeOfWorkByCompany.Date,
                TypeOfWork = typeOfWorkByCompany.TypeOfWork
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

        public static TypeOfWorkByCompany MakeTypeOfWorkByCompanyFromExtendedTypeOfWorkBO(ExtendedTypeOfWorkBO typeOfWorkBO)
        {
            return new TypeOfWorkByCompany
            {
                CompanyName = typeOfWorkBO.CompanyName,
                StaffUsername = typeOfWorkBO.StaffUsername,
                Date = typeOfWorkBO.Date,
                TypeOfWork = typeOfWorkBO.TypeOfWork
            };
        }
    }
}
