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
    public class McpIncentiveSettingController : ControllerBase
    {

        #region Private properties
        private readonly IMcpIncentiveSettingRepository _repo;
        #endregion
        #region Constructor        
        public McpIncentiveSettingController(IMcpIncentiveSettingRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Designation,int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpGet("GetMcpIncentiveSettingsDetails")]
        public async Task<IActionResult> GetMcpIncentiveSettingsDetails(int Month, int Designation,int Region)
        {
            return Ok(await _repo.GetMcpIncentiveSettingsDetails(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpPost("McpIncentiveSettingSave")]
        public async Task<IActionResult> McpIncentiveSettingSave(McpIncentiveSetting model)
        {
            return Ok(await _repo.McpIncentiveSettingSave(UserHelper.GetUser(User), model));
        }
    }

}
