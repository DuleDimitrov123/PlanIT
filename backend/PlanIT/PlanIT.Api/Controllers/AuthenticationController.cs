using Microsoft.AspNetCore.Mvc;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Services.Contracts;
using System;
using static PlanIT.Api.Models.LoginModels;

namespace PlanIT.Api.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("log-in")]
        public ActionResult<LogInResponse> LogIn([FromBody] LogInRequest request)
        {
            try
            {
                var token = _authenticationService.LogIn(request.Username, request.Password);

                var response = new LogInResponse(token);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<LogInResponse> Register([FromBody] StaffBO staffBO)
        {
            try
            {
                var token = _authenticationService.Register(staffBO);

                var response = new LogInResponse(token);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
