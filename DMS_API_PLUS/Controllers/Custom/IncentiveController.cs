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
    public class IncentiveController : ControllerBase
    {
        #region Private properties
        private readonly IIncentiveRepository _repo;
        #endregion
        #region Constructor        
        public IncentiveController(IIncentiveRepository repo)
        {
            _repo = repo;
        }
        #endregion
        [HttpGet("List")]
        public async Task<IActionResult> List(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), TabIndex));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Incentive model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, model));
        }
        [HttpGet("GetIncentiveDetails")]
        public async Task<IActionResult> GetIncentiveDetails(int IncentiveCode, string mode,string Type)
        {
            return Ok(await _repo.GetIncentiveDetails(UserHelper.GetUser(User), IncentiveCode, mode,Type));
        }
        [HttpPost("DeleteIncentive")]
        public async Task<IActionResult> DeleteIncentive(Incentive model)
        {

            return Ok(await _repo.DeleteIncentive(UserHelper.GetUser(User), model));
        }


        [HttpGet("GetDepartmentTypeCode")]
        public async Task<IActionResult> GetDepartmentTypeCode(int DepartmentCode)
        {

            return Ok(await _repo.GetDepartmentTypeCode(UserHelper.GetUser(User), DepartmentCode));
        }
    }
}
