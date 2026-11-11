using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.MobileApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.MobileApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleDashboardController : ControllerBase
    {

        #region Private properties
        private readonly IUserRoleDashboardRepository _repo;
        #endregion
        #region Constructor        
        public UserRoleDashboardController(IUserRoleDashboardRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpGet("GetSecuritytotalactivityList")]
        public async Task<IActionResult> GetSecuritytotalactivityList(string Date,int WorkShopcode)
        {
            return Ok(await _repo.GetSecuritytotalactivityList(UserHelper.GetUser(User), Date, WorkShopcode));

        }
        [HttpGet("GetSecurityDeatilsList")]
        public async Task<IActionResult> GetSecurityDeatilsList(string Date,int WorkShopcode)
        {
            return Ok(await _repo.GetSecurityDeatilsList(UserHelper.GetUser(User), Date, WorkShopcode));
        }
          [HttpGet("GetSecurityHistoryDeatilsList")]
        public async Task<IActionResult> GetSecurityHistoryDeatilsList(string Date,int WorkShopcode)
        {
            return Ok(await _repo.GetSecurityHistoryDeatilsList(UserHelper.GetUser(User), Date, WorkShopcode));
        }
         [HttpGet("GetSecurityPendingList")]
        public async Task<IActionResult> GetSecurityPendingList(string Date,int WorkShopcode)
        {
            return Ok(await _repo.GetSecurityPendingList(UserHelper.GetUser(User), Date, WorkShopcode));
        }
        [HttpGet("GetSecurityVehicleInList")]
        public async Task<IActionResult> GetSecurityVehicleInList(string Date,int WorkShopcode)
        {
            return Ok(await _repo.GetSecurityVehicleInList(UserHelper.GetUser(User), Date, WorkShopcode));
        } 
        [HttpPost("GetSecurityVehicleOutSave")]
        public async Task<IActionResult> GetSecurityVehicleOutSave(UserRoleDashboard model)
        {
            return Ok(await _repo.GetSecurityVehicleOutSave(UserHelper.GetUser(User), model));
        }
         [HttpPost("GetVehichlePassSaveMobile")]
        public async Task<IActionResult> GetVehichlePassSaveMobile(UserRoleDashboard model)
        {
            return Ok(await _repo.GetVehichlePassSaveMobile(UserHelper.GetUser(User), model));
        }

    }
}
