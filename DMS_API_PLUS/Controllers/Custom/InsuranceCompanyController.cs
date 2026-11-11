using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.Custom
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceCompanyController : ControllerBase
    {

         #region Private properties
        private readonly IInsuranceCompanyRepository _repo;
        #endregion
        #region Constructor        
        public InsuranceCompanyController(IInsuranceCompanyRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), TabIndex));
        }
        #endregion
        [HttpPost("Create")]
        public async Task<IActionResult> Create(InsuranceCompany model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, model));
        }
        [HttpGet("GetInsuranceCompanyDetails")]
        public async Task<IActionResult> GetInsuranceCompanyDetails(int InsComCode, string mode)
        {
            return Ok(await _repo.GetInsuranceCompanyDetails(UserHelper.GetUser(User), InsComCode, mode));
        }
        [HttpPost("InsuranceCompanyDelete")]
        public async Task<IActionResult> InsuranceCompanyDelete(InsuranceCompany model)
        {
            return Ok(await _repo.InsuranceCompanyDelete(UserHelper.GetUser(User),model));
        }
    }
}
