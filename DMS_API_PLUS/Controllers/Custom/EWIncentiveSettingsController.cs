using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class EWIncentiveSettingsController : ControllerBase
    {

        #region Private properties
        private readonly IEWIncentiveSettingsRepository _repo;
        #endregion
        #region Constructor        
        public EWIncentiveSettingsController(IEWIncentiveSettingsRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Designation,int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Designation, Region));
        }

        [HttpGet("GetEWIncentiveSettingsDetails")]
        public async Task<IActionResult> GetEWIncentiveSettingsDetails(int Month, int Designation, int Region)
        {
            return Ok(await _repo.GetEWIncentiveSettingsDetails(UserHelper.GetUser(User), Month, Designation, Region));
        }

        [HttpPost("EWIncentiveSettingsSave")]
        public async Task<IActionResult> EWIncentiveSettingsSave(EWIncentiveSettings model)
        {
            return Ok(await _repo.EWIncentiveSettingsSave(UserHelper.GetUser(User), model));
        }
    }
}
