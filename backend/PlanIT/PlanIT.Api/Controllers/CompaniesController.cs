using Microsoft.AspNetCore.Mvc;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Services.Contracts;

namespace PlanIT.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("companies")]
        public ActionResult<CompanyBO> GetCompanies()
        {
            var companies = _companyService.GetCompanies();

            return Ok(companies);
        }
    }
}
