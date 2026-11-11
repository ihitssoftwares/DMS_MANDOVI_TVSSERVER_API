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
    public class IncentiveTargetTeamSettingsController : Controller
    {
        #region Private properties
        private readonly IIncentiveTargetTeamSettingsRepository _repo;
        #endregion
        #region Constructor        
        public IncentiveTargetTeamSettingsController(IIncentiveTargetTeamSettingsRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int EmployeeCode,int Branch)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), EmployeeCode, Branch));
        }
        [HttpGet("GetBranch")]
        public async Task<IActionResult> GetBranch(int EmployeeCode)
        {

            return Ok(await _repo.GetBranch(UserHelper.GetUser(User), EmployeeCode));
        }

        [HttpPost("IncentiveSettingsSave")]
        public async Task<IActionResult> IncentiveSettingsSave(IncentiveTargetTeamSettings model)
        {
            return Ok(await _repo.IncentiveSettingsSave(UserHelper.GetUser(User), model));
        }

    }
}
