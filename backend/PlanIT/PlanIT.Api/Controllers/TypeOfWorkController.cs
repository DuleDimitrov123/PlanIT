using Microsoft.AspNetCore.Mvc;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;
using static PlanIT.Api.Models.TypeOfWorkModels;

namespace PlanIT.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeOfWorkController : ControllerBase
    {
        private readonly ITypeOfWorkService _typeOfWorkService;

        public TypeOfWorkController(ITypeOfWorkService typeOfWorkService)
        {
            _typeOfWorkService = typeOfWorkService;
        }

        [HttpGet]
        [Route("type-of-work")]
        public ActionResult<IList<TypeOfWorkBO>> GetAllTypeOfWorkByStaffAndDate()
        {
            try
            {
                var typeOfWork = _typeOfWorkService.GetAllTypeOfWorkByStaffAndDate();

                return Ok(typeOfWork);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("type-of-work/{staffUsername}")]
        public ActionResult<IList<TypeOfWorkBO>> GetStaffTypeOfWorkHistory([FromRoute(Name = "staffUsername")] string staffUsername)
        {
            try
            {
                var typeOfWork = _typeOfWorkService.GetStaffTypeOfWorkHistory(staffUsername);

                return Ok(typeOfWork);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("type-of-work/actions/get-by-staff-and-date/{staffUsername}")]
        public ActionResult<GetTypeOfWorkByStaffAndDateResponse> GetTypeOfWorkByStaffAndDate([FromRoute(Name = "staffUsername")] string staffUsername,
            [FromBody] GetTypeOfWorkByStaffAndDateRequest request)
        {
            try
            {
                var typeOfWork = _typeOfWorkService.GetTypeOfWorkByStaffAndDate(staffUsername, request.Date);

                var response = new GetTypeOfWorkByStaffAndDateResponse(typeOfWork);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /*[HttpPost]
        [Route("type-of-work/actions/add-by-staff-and-date")]*/
    }
}
