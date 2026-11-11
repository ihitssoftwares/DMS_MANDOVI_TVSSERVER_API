using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class EnterpriseDashboardController : Controller
    {
        #region Private properties
        private readonly IEnterpriseDashboardRepository _repo;
        #endregion
        #region Constructor        
        public EnterpriseDashboardController(IEnterpriseDashboardRepository repo)
        {
            _repo = repo;
        }
        #endregion
        [HttpGet("GetReportList")]
        public async Task<IActionResult> GetReportList(int BranchCode)
        {

            return Ok(await _repo.GetReportList(UserHelper.GetUser(User), BranchCode));
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int WorkShopCode)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), WorkShopCode));
        } 
        [HttpGet("GetStatusList")]
        public async Task<IActionResult> GetStatusList(int WorkShopCode,string Status)
        {

            return Ok(await _repo.GetStatusList(UserHelper.GetUser(User), WorkShopCode,Status));
        }
    }
}
