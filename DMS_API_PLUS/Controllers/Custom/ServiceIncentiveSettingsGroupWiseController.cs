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
    public class ServiceIncentiveSettingsGroupWiseController : Controller
    {
        #region Private properties
        private readonly IServiceIncentiveSettingsGroupWiseRepository _repo;
        #endregion
        #region Constructor        
        public ServiceIncentiveSettingsGroupWiseController(IServiceIncentiveSettingsGroupWiseRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int Parameter, int Region)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Parameter, Region));
        }

        [HttpGet("GeteditList")]
        public async Task<IActionResult> GeteditList(int Month, int IncentiveGroup, int Region, int ParameterCode)
        {

            return Ok(await _repo.GeteditList(UserHelper.GetUser(User), Month, IncentiveGroup, Region, ParameterCode));
        }

        [HttpPost("SettingsSave")]
        public async Task<IActionResult> SettingsSave(ServiceIncentiveSettingsGroupWise model, int monthcode)
        {
            //model.User = UserHelper.GetUser(User);
            return Ok(await _repo.SettingsSave(UserHelper.GetUser(User), model, monthcode));
        }

        [HttpGet("GetIncentiveSettingsDetails")]
        public async Task<IActionResult> GetIncentiveSettingsDetails(int IncentiveGroupCode, int month, int Parameter, int Region)
        {
            return Ok(await _repo.GetIncentiveSettingsDetails(UserHelper.GetUser(User), IncentiveGroupCode, month, Parameter, Region));
        }

        [HttpPost("IncentiveSettingsSave")]
        public async Task<IActionResult> IncentiveSettingsSave(ServiceIncentiveSettingsGroupWise model)
        {
            return Ok(await _repo.IncentiveSettingsSave(UserHelper.GetUser(User), model));
        }


        [HttpGet("SavePopup")]
        public async Task<IActionResult> SavePopup(int monthfromCode, int MonthToCode, int RegionCode)
        {
            return Ok(await _repo.SavePopup(UserHelper.GetUser(User), monthfromCode, MonthToCode,RegionCode));
        }
    }
}
