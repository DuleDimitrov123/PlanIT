using PlanIT.DataAccess.Models;
using PlanIT.Repository.Helpers;
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
                Date = GeneralHelpers.ConvertLocalDateToDateTime(typeOfWorkByStaffAndDate.Date),
                TypeOfWork = typeOfWorkByStaffAndDate.TypeOfWork
            };
        }

        public static ExtendedTypeOfWorkBO MakeExtendedTypeOfWorkBOFromTypeOfWorkByCompany(TypeOfWorkByCompany typeOfWorkByCompany)
        {
            return new ExtendedTypeOfWorkBO
            {
                CompanyName = typeOfWorkByCompany.CompanyName,
                StaffUsername = typeOfWorkByCompany.StaffUsername,
                Date =GeneralHelpers.ConvertLocalDateToDateTime(typeOfWorkByCompany.Date),
                TypeOfWork = typeOfWorkByCompany.TypeOfWork
            };
        }

        public static TypeOfWorkByStaffAndDate MakeTypeOfWorkByStaffAndDateFromTypeOfWorkBO(TypeOfWorkBO typeOfWorkBO)
        {
            return new TypeOfWorkByStaffAndDate
            {
                StaffUsername = typeOfWorkBO.StaffUsername,
                Date =GeneralHelpers.ConvertDateTimeToLocalDate(typeOfWorkBO.Date),
                TypeOfWork = typeOfWorkBO.TypeOfWork
            };
        }

        public static TypeOfWorkByCompany MakeTypeOfWorkByCompanyFromExtendedTypeOfWorkBO(ExtendedTypeOfWorkBO typeOfWorkBO)
        {
            return new TypeOfWorkByCompany
            {
                CompanyName = typeOfWorkBO.CompanyName,
                StaffUsername = typeOfWorkBO.StaffUsername,
                Date = GeneralHelpers.ConvertDateTimeToLocalDate(typeOfWorkBO.Date),
                TypeOfWork = typeOfWorkBO.TypeOfWork
            };
        }
    }
}
