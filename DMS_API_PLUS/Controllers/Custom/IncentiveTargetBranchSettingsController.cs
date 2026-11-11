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
    public class IncentiveTargetBranchSettingsController : Controller
    {
        #region Private properties
        private readonly IIncentiveTargetBranchSettingsRepository _repo;
        #endregion
        #region Constructor        
        public IncentiveTargetBranchSettingsController(IIncentiveTargetBranchSettingsRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int EmployeeCode)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), EmployeeCode));
        }


        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int EmployeeCode)
        {

            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), EmployeeCode));
        }


        [HttpPost("IncentiveSettingsSave")]
        public async Task<IActionResult> IncentiveSettingsSave(IncentiveTargetBranchSettings model,int TLEmployeeCode)
        {
            return Ok(await _repo.IncentiveSettingsSave(UserHelper.GetUser(User), model, TLEmployeeCode));
        }

    }
}
