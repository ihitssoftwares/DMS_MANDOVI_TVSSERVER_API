using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceIncentiveSettingController : ControllerBase
    {

        #region Private properties
        private readonly IFinanceIncentiveSettingRepository _repo;
        #endregion
        #region Constructor        
        public FinanceIncentiveSettingController(IFinanceIncentiveSettingRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Designation ,int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpGet("GetFinanceIncentiveSettingsDetails")]
        public async Task<IActionResult> GetFinanceIncentiveSettingsDetails(int Month, int Designation, int Region)
        {
            return Ok(await _repo.GetFinanceIncentiveSettingsDetails(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpPost("FinanceIncentiveSettingSave")]
        public async Task<IActionResult> FinanceIncentiveSettingSave(FinanceIncentiveSetting model)
        {
            return Ok(await _repo.FinanceIncentiveSettingSave(UserHelper.GetUser(User), model));
        }
    }
}
