namespace PlanIT.Api.Models
{
    public class LoginModels
    {
        public record LogInRequest(string Username, string Password);

        public record LogInResponse(string Token);
    }
}
