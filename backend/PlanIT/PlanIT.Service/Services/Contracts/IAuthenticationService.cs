using PlanIT.Service.BusinessObjects;

namespace PlanIT.Service.Services.Contracts
{
    public interface IAuthenticationService
    {
        string LogIn(string username, string password);

        string Register(StaffBO staffBO);
    }
}
