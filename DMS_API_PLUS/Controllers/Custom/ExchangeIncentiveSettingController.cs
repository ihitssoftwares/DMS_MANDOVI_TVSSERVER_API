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
    public class ExchangeIncentiveSettingController : ControllerBase
    {

        #region Private properties
        private readonly IExchangeIncentiveSettingRepository _repo;
        #endregion
        #region Constructor        
        public ExchangeIncentiveSettingController(IExchangeIncentiveSettingRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Designation,int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpGet("GetExchangeIncentiveSettingsDetails")]
        public async Task<IActionResult> GetExchangeIncentiveSettingsDetails(int Month, int Designation,int Region)
        {
            return Ok(await _repo.GetExchangeIncentiveSettingsDetails(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpPost("ExchangeIncentiveSettingSave")]
        public async Task<IActionResult> ExchangeIncentiveSettingSave(ExchangeIncentiveSetting model)
        {
            return Ok(await _repo.ExchangeIncentiveSettingSave(UserHelper.GetUser(User), model));
        }
    }
}
