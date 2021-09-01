using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanIT.DataAccess.Models;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PlanIT.Api.Models.BreakfastModels;

namespace PlanIT.Api.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class BreakfastsController : ControllerBase
    {
        private readonly IBreakfastService _breakfastService;

        public BreakfastsController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpGet]
        [Route("breakfasts/actions/all-available")]
        public ActionResult GetAllAvailableBreakfast()
        {
            try
            {
                var breakfasts = _breakfastService.GetAllAvailableBreakfast();

                return Ok(breakfasts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("breakfasts/actions/all-available-by-company/{companyName}")]
        public ActionResult GetAvailableBreakfastByCompany([FromRoute(Name = "companyName")] string companyName)
        {
            try
            {
                var breakfasts = _breakfastService.GetAvailableBreakfastByCompany(companyName);

                return Ok(breakfasts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("breakfasts/actions/all-available-by-company-and-date")]
        public ActionResult GetAvailableBreakfastByCompanyAndDate([FromBody] GetAvailableBreakfastByCompanyAndDateRequest request)
        {
            try
            {
                var breakfastItems = _breakfastService.GetAvailableBreakfastByCompanyAndDate(request.CompanyName, request.Date);

                return Ok(breakfastItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("breakfasts/actions/add-available-breakfast")]
        public ActionResult AddAvailableBreakfastByCompany([FromBody] AvailableBreakfastByCompany availableBreakfastByCompany)
        {
            try
            {
                _breakfastService.AddAvailableBreakfastByCompany(availableBreakfastByCompany);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("breakfasts/actions/add-available-breakfast-for-interval")]
        public ActionResult AddSameBreakfastForDateInterval(AddSameBreakfastForDateIntervalRequest request)
        {
            try
            {
                _breakfastService.AddSameBreakfastForDateInterval(request.CompanyName, request.BreakfastItems, request.StartDate, request.EndDate);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("breakfasts/actions/upgrade-available-breakfast")]
        public ActionResult UpgradeAvailableBreakfastByCompany([FromBody] UpgradeAvailableBreakfastByCompanyRequest request)
        {
            try
            {
                _breakfastService.UpdateAvailableBreakfastByCompany(request.CompanyName, request.Date, request.NewBreakfastItems, true);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("breakfasts/actions/downgrade-available-breakfast")]
        public ActionResult DowngradeAvailableBreakfastByCompany([FromBody] DowngradeAvailableBreakfastByCompanyRequest request)
        {
            try
            {
                _breakfastService.UpdateAvailableBreakfastByCompany(request.CompanyName, request.Date, request.RemovableBreakfastItems, false);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("breakfasts/actions/all-by-staff")]
        public ActionResult GettAllBreakfastByStaff()
        {
            try
            {
                var breakfasts = _breakfastService.GettAllBreakfastByStaff();

                return Ok(breakfasts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("breakfasts/actions/all-by-staff/{staffUsername}")]
        public ActionResult GetBreakfastByStaff([FromRoute(Name = "staffUsername")] string staffUsername)
        {
            try
            {
                var breakfasts = _breakfastService.GetBreakfastByStaff(staffUsername);

                return Ok(breakfasts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("breakfasts/actions/all-by-staff-and-date")]
        public ActionResult GetBreakfastByStaffAndDate([FromBody] GetBreakfastByStaffAndDateRequest request)
        {
            try
            {
                var breakfasts = _breakfastService.GetBreakfastByStaffAndDate(request.StaffUsername, request.Date);

                return Ok(breakfasts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("breakfasts/actions/all-by-company")]
        public ActionResult GetAllBreakfastByCompany()
        {
            try
            {
                var breakfasts = _breakfastService.GetAllBreakfastByCompany();

                return Ok(breakfasts); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("breakfasts/actions/all-by-company/{companyName}")]
        public ActionResult GetBreakfastByCompany([FromRoute(Name = "companyName")] string companyName)
        {
            try
            {
                var breakfasts = _breakfastService.GetBreakfastByCompany(companyName);

                return Ok(breakfasts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("breakfasts/actions/all-by-company-and-date")]
        public ActionResult GetBreakfastByCompanyAndDate([FromBody] GetBreakfastByCompanyAndDateRequest request)
        {
            try
            {
                var breakfasts = _breakfastService.GetBreakfastByCompanyAndDate(request.CompanyName, request.Date);

                return Ok(breakfasts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
