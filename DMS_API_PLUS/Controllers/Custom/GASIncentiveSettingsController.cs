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
    public class GASIncentiveSettingsController : ControllerBase
    {

        #region Private properties
        private readonly IGASIncentiveSettingsRepository _repo;
        #endregion
        #region Constructor        
        public GASIncentiveSettingsController(IGASIncentiveSettingsRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Designation ,int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Designation, Region));
        }

        [HttpGet("GetGASIncentiveSettingsDetails")]
        public async Task<IActionResult> GetGASIncentiveSettingsDetails(int Month, int Designation, int Region)
        {
            return Ok(await _repo.GetGASIncentiveSettingsDetails(UserHelper.GetUser(User), Month, Designation, Region));
        }

        [HttpPost("GASIncentiveSettingsSave")]
        public async Task<IActionResult> GASIncentiveSettingsSave(GASIncentiveSettings model)
        {
            return Ok(await _repo.GASIncentiveSettingsSave(UserHelper.GetUser(User), model));
        }
    }
}
