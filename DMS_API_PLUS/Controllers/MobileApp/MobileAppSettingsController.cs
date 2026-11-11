using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.Mobile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.MobileApp
{
    public class MobileAppSettingsController : Controller
    {
        #region Private Properties
        private readonly IMobileAppSettingsRepository _repo;

        #endregion
        #region Constructor
        public MobileAppSettingsController(IMobileAppSettingsRepository repo)
        {
            _repo = repo;

        }
        #endregion
        #region API Services
        #region post
        [HttpPost("UpdateMobileFcmID")]
        public async Task<IActionResult> UpdateMobileFcmID([FromBody] MobileAppSettings DiviceData)
        {

            return Ok(await _repo.UpdateMobileFcmID(DiviceData, UserHelper.GetUser(User)));
        }
        // [AllowAnonymous]
        [HttpPost("SetMobAppVersion")]
        public async Task<IActionResult> SetMobAppVersion([FromBody] MobAppVersion appVersion)
        {
            return Ok(await _repo.SetMobAppVersion(appVersion, UserHelper.GetUser(User)));
        }

        [AllowAnonymous]
        [HttpGet("GetAppVersion")]
        public async Task<IActionResult> GetAppVersion()
        {
            return Ok(await _repo.GetAppVersion());
        }

        [HttpGet("GetNotificationCountDetails")]
        public async Task<IActionResult> GetNotificationCountDetails()
        {
            //UserBase user = new UserBase { UserGuid = new Guid("E9DFC12E-5984-43CB-B471-CFD4DE5E4227"), CompanyGuid = new Guid("EDBB6E60-2A1B-4F7F-BA31-8B54E78FB1BD") };
            //return Ok(await _repo.GetMobileAppSettings(user));
            return Ok(await _repo.GetNotificationCountDetails(UserHelper.GetUser(User)));

        }

        [HttpGet("GetMobDefaultLandingPage")]
        public async Task<IActionResult> GetMobDefaultLandingPage()
        {

            return Ok(await _repo.GetMobDefaultLandingPage(UserHelper.GetUser(User)));

        }

        #endregion
        #endregion
    }
}
