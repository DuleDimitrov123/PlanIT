using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanIT.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("staff/{username}")]
        public ActionResult<StaffBO> GetStaffByUsername([FromRoute(Name ="username")] string username)
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
        [Route("staff")]
        public ActionResult UpdateStaff([FromBody] StaffBO staffBO)
        {
            try
            {
                _staffService.UpdateStaff(staffBO);

                return Ok();
            }
            catch(Exception ex)
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
    }
}
