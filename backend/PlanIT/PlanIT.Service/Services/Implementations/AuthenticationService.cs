using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Constants;
using PlanIT.Service.Services.Contracts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlanIT.Service.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IStaffService _staffService;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IStaffService staffService, IConfiguration configuration)
        {
            _staffService = staffService;
            _configuration = configuration;
        }

        public string LogIn(string username, string password)
        {
            //check if staff exists
            var staff = _staffService.GetStaffByUsername(username);

            if (staff == null || staff.Password != password)
            {
                throw new Exception("Username or password are incorrect");
            }

            var token = GenerateJWTToken(staff);

            return token;
        }

        public string Register(StaffBO staffBO)
        {
            throw new System.NotImplementedException();
        }

        private string GenerateJWTToken(StaffBO staffBO)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var role = "NormalStaff";
            if (staffBO.CanCreate == true)
            {
                role = "StaffCanCreate";
            }

            var claims = new[]
            {
                new Claim("Username", staffBO.Username),
                new Claim("Staff", role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Audience"], claims: claims,
                expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
