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
    public class InsurIncentiveSettingController : ControllerBase
    {
        #region Private properties
        private readonly IInsurIncentiveSettingRepository _repo;
        #endregion
        #region Constructor        
        public InsurIncentiveSettingController(IInsurIncentiveSettingRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Designation, int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpGet("GetInsurIncentiveSettingsDetails")]
        public async Task<IActionResult> GetInsurIncentiveSettingsDetails(int Month, int Designation, int Region)
        {
            return Ok(await _repo.GetInsurIncentiveSettingsDetails(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpPost("InsurIncentiveSettingSave")]
        public async Task<IActionResult> InsurIncentiveSettingSave(InsurIncentiveSetting model)
        {
            return Ok(await _repo.InsurIncentiveSettingSave(UserHelper.GetUser(User), model));
        }
    }
}
