﻿using Microsoft.AspNetCore.Mvc;
using PlanIT.Service.BusinessObjects;
using PlanIT.Service.Services.Contracts;
using System;
using System.Collections.Generic;

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
        public ActionResult<IList<CompanyBO>> GetCompanies()
        {
            try
            {
                var companies = _companyService.GetCompanies();

                return Ok(companies);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("company/{companyName}")]
        public ActionResult<CompanyBO> GetCompanyByName([FromRoute(Name = "companyName")] string companyName)
        {
            try
            {
                var company = _companyService.GetCompanyByName(companyName);

                return Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("companies")]
        public ActionResult CreateCompany([FromBody] CompanyBO companyBO)
        {
            try
            {
                _companyService.CreateCompany(companyBO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("companies/{companyName}")]
        public ActionResult UpdateCompany([FromRoute(Name = "companyName")] string companyName, [FromBody] CompanyBO companyBO)
        {
            try
            {
                companyBO.CompanyName = companyName;

                _companyService.UpdateCompany(companyBO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("companies/{companyName}")]
        public ActionResult DeleteCompanyByName([FromRoute] string companyName)
        {
            try
            {
                _companyService.DeleteCompanyByName(companyName);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
