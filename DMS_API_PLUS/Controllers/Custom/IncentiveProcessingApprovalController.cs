using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.Custom
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IncentiveProcessingApprovalController : ControllerBase
    {
        #region Private properties
        private readonly IIncentiveProcessingApprovalRepository _repo;
        #endregion
        #region Constructor        
        public IncentiveProcessingApprovalController(IIncentiveProcessingApprovalRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Delearship, int Designation, int Incentive)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Delearship, Designation, Incentive));
        }

        [HttpPost("EmployeeWiseUpdate")]
        public async Task<IActionResult> EmployeeWiseUpdate(IncentiveProcessingApproval model)
        {
            return Ok(await _repo.EmployeeWiseUpdate(UserHelper.GetUser(User), model));
        }

        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(int HDCode, int EmployeeCode)
        {
            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), HDCode, EmployeeCode));
        }
    }
}
