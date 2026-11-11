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
    public class SalesIncentiveSettingsController : ControllerBase
    {

        #region Private properties
        private readonly ISalesIncentiveSettingsRepository _repo;
        #endregion
        #region Constructor        
        public SalesIncentiveSettingsController(ISalesIncentiveSettingsRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Designation, int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpGet("GetSalesIncentiveSettingsDetails")]
        public async Task<IActionResult> GetSalesIncentiveSettingsDetails(int Month, int Designation, int Region)
        {
            return Ok(await _repo.GetSalesIncentiveSettingsDetails(UserHelper.GetUser(User), Month, Designation, Region));
        }

        [HttpPost("SalesIncentiveSettingsSave")]
        public async Task<IActionResult> SalesIncentiveSettingsSave(SalesIncentiveSettings model)
        {
            return Ok(await _repo.SalesIncentiveSettingsSave(UserHelper.GetUser(User), model));
        }
    }
}
