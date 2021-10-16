using System;

namespace PlanIT.Api.Models
{
    public class TypeOfWorkModels
    {
        public record GetTypeOfWorkByStaffAndDateRequest(DateTime Date);

        public record GetTypeOfWorkByStaffAndDateResponse(string TypeOfWork);

        public record AddTypeOfWorkByStaffAndDateRequest(string StaffUsername, DateTime Date, string TypeOfWork);

        public record AddTypeOfWorkByStaffAndDatesRequest(string StaffUsername, DateTime StartDate, DateTime EndDate, string TypeOfWork);

        public record ChangeTypeOfWorkByStaffAndDateRequest(string StaffUsername, DateTime Date, string NewTypeOfWork);

        public record GetTypeOfWorkByCompanyAndDateRequest(DateTime Date);

        public record GetTypeOfWorkByCompanyDateAndStaffUsernameRequest(DateTime Date, string StaffUsername);

        public record GetTypeOfWorkByCompanyDateAndStaffUsernameResponse(string TypeOfWork);

        public record AddTypesOfWorkByCompanyRequest(string CompanyName, DateTime StartDate, DateTime EndDate, string StaffUsername, string TypeOfWork);

        public record ChangeTypeOfWorkByCompanyRequest(string CompanyName, DateTime Date, string StaffUsername, string NewTypeOfWork);
    }
}
