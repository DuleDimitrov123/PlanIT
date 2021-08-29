using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class TypeOfWorkController : ControllerBase
    {
        private readonly ITypeOfWorkService _typeOfWorkService;

        public TypeOfWorkController(ITypeOfWorkService typeOfWorkService)
        {
            _typeOfWorkService = typeOfWorkService;
        }

        [HttpGet]
        [Route("type-of-work/actions/get-by-staff")]
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
        [Route("type-of-work/actions/get-by-staff/{staffUsername}")]
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

        [HttpGet]
        [Route("type-of-work/actions/get-all-type-of-work-by-company")]
        public ActionResult<IList<ExtendedTypeOfWorkBO>> GetAllTypeOfWorkByCompany()
        {
            try
            {
                var typeOfWork = _typeOfWorkService.GetAllTypeOfWorkByCompany();

                return Ok(typeOfWork);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("type-of-work/actions/get-by-company/{companyName}")]
        public ActionResult<IList<ExtendedTypeOfWorkBO>> GetTypeOfWorkByCompany([FromRoute(Name = "companyName")] string companyName)
        {
            try
            {
                var typeOfWork = _typeOfWorkService.GetTypeOfWorkByCompany(companyName);

                return Ok(typeOfWork);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("type-of-work/actions/get-by-company-and-date/{companyName}")]
        public ActionResult<IList<ExtendedTypeOfWorkBO>> GetTypeOfWorkByCompanyAndDate(
            [FromRoute(Name = "companyName")] string companyName,
            [FromBody] GetTypeOfWorkByCompanyAndDateRequest request)
        {
            try
            {
                var typeOfWork = _typeOfWorkService.GetTypeOfWorkByCompanyAndDate(companyName, request.Date);

                return Ok(typeOfWork);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("type-of-work/actions/get-by-company-date-and-staff/{companyName}")]
        public ActionResult<GetTypeOfWorkByCompanyDateAndStaffUsernameResponse> GetTypeOfWorkByCompanyDateAndStaffUsername(
            [FromRoute(Name = "companyName")] string companyName,
            [FromBody] GetTypeOfWorkByCompanyDateAndStaffUsernameRequest request)
        {
            try
            {
                var typeOfWork = _typeOfWorkService.GetTypeOfWorkByCompanyDateAndStaffUsername(companyName, request.Date, request.StaffUsername);

                var response = new GetTypeOfWorkByCompanyDateAndStaffUsernameResponse(typeOfWork);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("type-of-work")]
        public ActionResult AddTypeOfWork([FromBody] ExtendedTypeOfWorkBO extendedTypeOfWorkBO)
        {
            try
            {
                _typeOfWorkService.AddTypeOfWork(extendedTypeOfWorkBO);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("type-of-work/actions/add-for-multiple-days")]
        public ActionResult AddTypesOfWork([FromBody] AddTypesOfWorkByCompanyRequest request)
        {
            try
            {
                _typeOfWorkService.AddTypesOfWork(request.CompanyName, request.StartDate, request.EndDate, request.StaffUsername, request.TypeOfWork);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #region UsedOnlyForTesting
        //Used only for testing:
        /*
         [HttpPost]
        [Route("type-of-work/actions/add-by-staff-and-date")]
        public ActionResult AddTypeOfWorkByStaffAndDate([FromBody] AddTypeOfWorkByStaffAndDateRequest request)
        {
            try
            {
                _typeOfWorkService.AddTypeOfWorkByStaffAndDate(request.StaffUsername, request.Date, request.TypeOfWork);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("type-of-work/actions/add-by-staff-and-dates")]
        public ActionResult AddTypeOfWorkByStaffAndDates([FromBody] AddTypeOfWorkByStaffAndDatesRequest request)
        {
            try
            {
                _typeOfWorkService.AddTypeOfWorkByStaffAndDates(request.StaffUsername, request.StartDate, request.EndDate, request.TypeOfWork);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("type-of-work/actions/change-by-staff-and-date")]
        public ActionResult ChangeTypeOfWorkByStaffAndDate([FromBody] ChangeTypeOfWorkByStaffAndDateRequest request)
        {
            try
            {
                _typeOfWorkService.ChangeTypeOfWorkByStaffAndDate(request.StaffUsername, request.Date, request.NewTypeOfWork);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("type-of-work/actions/add-by-company")]
        public ActionResult AddTypeOfWorkByCompany([FromBody] ExtendedTypeOfWorkBO extendedTypeOfWorkBO)
        {
            try
            {
                _typeOfWorkService.AddTypeOfWorkByCompany(extendedTypeOfWorkBO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("type-of-work/actions/add-multiple-by-company")]
        public ActionResult AddTypesOfWorkByCompany([FromBody] AddTypesOfWorkByCompanyRequest request)
        {
            try
            {
                _typeOfWorkService.AddTypesOfWorkByCompany(
                    request.CompanyName, request.StartDate, request.EndDate, request.StaffUsername, request.TypeOfWork);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("type-of-work/actions/change-by-company")]
        public ActionResult ChangeTypeOfWorkByCompany([FromBody] ChangeTypeOfWorkByCompanyRequest request)
        {
            try
            {
                _typeOfWorkService.ChangeTypeOfWorkByCompany(
                    request.CompanyName, request.Date, request.StaffUsername, request.NewTypeOfWork);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
         */
        #endregion
    }
}
