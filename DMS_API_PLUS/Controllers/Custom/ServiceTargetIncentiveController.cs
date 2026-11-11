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
    public class ServiceTargetIncentiveController : Controller
    {
        #region Private properties
        private readonly IServiceTargetIncentiveRepository _repo;
        #endregion
        #region Constructor        
        public ServiceTargetIncentiveController(IServiceTargetIncentiveRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int IncentiveGroup, int Region)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, IncentiveGroup, Region));
        }

        [HttpGet("GeteditList")]
        public async Task<IActionResult> GeteditList(int Month, int IncentiveGroup, int Region)
        {

            return Ok(await _repo.GeteditList(UserHelper.GetUser(User), Month, IncentiveGroup, Region));
        }

        [HttpPost("SettingsSave")]
        public async Task<IActionResult> SettingsSave(ServiceTargetIncentive model,int monthcode)
        {
            //model.User = UserHelper.GetUser(User);
            return Ok(await _repo.SettingsSave(UserHelper.GetUser(User), model, monthcode));
        }

        [HttpGet("SavePopup")]
        public async Task<IActionResult> SavePopup(int monthfromCode, int MonthToCode,int RegionCode)
        {
            return Ok(await _repo.SavePopup(UserHelper.GetUser(User), monthfromCode, MonthToCode,RegionCode));
        }
    }
}
