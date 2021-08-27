using System;

namespace PlanIT.Api.Models
{
    public class TypeOfWorkModels
    {
        public record GetTypeOfWorkByStaffAndDateRequest(DateTime Date);

        public record GetTypeOfWorkByStaffAndDateResponse(string TypeOfWork);
    }
}
