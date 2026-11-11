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
    public class BranchTargetSettingsController : ControllerBase
    {

        #region Private properties
        private readonly IBranchTargetSettingsRepository _repo;
        #endregion
        #region Constructor        
        public BranchTargetSettingsController(IBranchTargetSettingsRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Region));
        }

       

        [HttpPost("BranchWiseUpdate")]
        public async Task<IActionResult> BranchWiseUpdate(BranchTargetSettings model)
        {
            return Ok(await _repo.BranchWiseUpdate(UserHelper.GetUser(User), model));
        }

        
    }
}
