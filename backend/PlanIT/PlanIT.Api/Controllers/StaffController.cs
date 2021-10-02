using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PlanIT.Api.Models.StaffModels;

namespace PlanIT.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        [Route("staff")]
        public ActionResult<IList<StaffBO>> GetStaff()
        {
            try
            {
                var staff = _staffService.GetStaff();

                return Ok(staff);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("staff/{username}")]
        public ActionResult<StaffBO> GetStaffByUsername([FromRoute(Name = "username")] string username)
        {
            try
            {
                var staff = _staffService.GetStaffByUsername(username);

                return Ok(staff);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("staff")]
        [AllowAnonymous]
        public ActionResult CreateStaff([FromBody] StaffBO staffBO)
        {
            try
            {
                _staffService.CreateStaff(staffBO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("staff/{username}")]
        public ActionResult UpdateStaff([FromRoute(Name = "username")] string username, [FromBody] UpdateStaffRequest request)
        {
            try
            {
                _staffService.UpdateStaff(
                    username,
                    request.FirstName,
                    request.LastName,
                    request.DateOfBirth,
                    request.Position,
                    request.CompanyName);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("staff/{username}")]
        public ActionResult DeleteStaffByUsername([FromRoute] string username)
        {
            try
            {
                _staffService.DeleteStaffByUsername(username);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("staff/actions/staff-can-create-by-company")]
        public ActionResult GetStaffCanCreateByCompany()
        {
            try
            {
                var staffCanCreateByService = _staffService.GetStaffCanCreateByCompany();

                return Ok(staffCanCreateByService);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("staff/actions/can-create-usernames-by-company/{companyName}")]
        public ActionResult<IList<string>> GetCanCreateUsernamesByCompany([FromRoute(Name = "companyName")] string companyName)
        {
            try
            {
                var staffsCanCreate = _staffService.GetCanCreateUsernamesByCompany(companyName);

                return Ok(staffsCanCreate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("staff/actions/add-can-create-usernames-by-company/{companyName}")]
        public ActionResult AddCanCreateUsernamesToCompany([FromRoute(Name = "companyName")] string companyName,
            [FromBody] AddRemoveCanCreateUsernamesToCompanyRequest request)
        {
            try
            {
                _staffService.AddRemoveCanCreateUsernamesToCompany(request.StaffUsername, companyName, true);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("staff/actions/remove-can-create-usernames-by-company/{companyName}")]
        public ActionResult RemoveCanCreateUsernamesToCompany([FromRoute(Name = "companyName")] string companyName,
            [FromBody] AddRemoveCanCreateUsernamesToCompanyRequest request)
        {
            try
            {
                _staffService.AddRemoveCanCreateUsernamesToCompany(request.StaffUsername, companyName, false);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("staff/actions/staff-by-company/{companyName}")]
        [AllowAnonymous]
        public ActionResult<List<StaffByCompanyRequestResponse>> GetStaffByCompany([FromRoute(Name = "companyName")] string companyName)
        {
            try
            {
                var staff = _staffService.GetStaffByCompany(companyName);

                var response = new List<StaffByCompanyRequestResponse>();
                foreach (var s in staff)
                {
                    response.Add(new StaffByCompanyRequestResponse(s.StaffUsername, s.Position));
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("staff/actions/add-staff-by-company/{companyName}")]
        public ActionResult AddStaffByCompany([FromRoute(Name = "companyName")] string companyName, [FromBody] StaffByCompanyRequestResponse request)
        {
            try
            {
                _staffService.AddStaffByCompany(
                    companyName,
                    request.StaffUsername,
                    request.Position);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("staff/actions/remove-staff-by-company/{companyName}")]
        public ActionResult RemoveStaffByCompany([FromRoute(Name = "companyName")] string companyName, [FromBody] StaffByCompanyRequestResponse request)
        {
            try
            {
                _staffService.RemoveStaffByCompany(
                    companyName,
                    request.StaffUsername,
                    request.Position);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("staff/actions/change-staff-position/{companyName}")]
        public ActionResult ChangeStaffPosition([FromRoute(Name = "companyName")] string companyName, [FromBody] StaffByCompanyRequestResponse request)
        {
            try
            {
                _staffService.ChangeStaffPosition(
                    companyName,
                    request.StaffUsername,
                    request.Position);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("staff/actions/get-profile-picture/{staffUsername}")]
        public ActionResult<GetProfilePictureResponse> GetProfilePicture([FromRoute(Name = "staffUsername")] string staffUsername)
        {
            try
            {
                var content = _staffService.GetProfilePicture(staffUsername);

                var response = new GetProfilePictureResponse(content);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("staff/actions/add-profile-picture")]
        public ActionResult AddProfilePicture([FromBody] AddProfilePictureRequest request)
        {
            try
            {
                _staffService.AddProfilePicture(request.StaffUsername, request.Content);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("staff/actions/delete-profile-picture/{staffUsername}")]
        public ActionResult DeleteProfilePicture([FromRoute(Name = "staffUsername")] string staffUsername)
        {
            try
            {
                _staffService.DeleteProfilePicture(staffUsername);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
