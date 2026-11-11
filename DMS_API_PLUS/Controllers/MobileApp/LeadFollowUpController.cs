
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.Mobile;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.MobileApp;

namespace DMS_API_PLUS.Controllers.MobileApp
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeadFollowUpController : ControllerBase
    {
        #region Private properties
        private readonly ILeadFollowUpRepository _repo;
        #endregion
        #region Constructor        
        public LeadFollowUpController(ILeadFollowUpRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int TabIndex)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), TabIndex));
        }

        [HttpGet("GetEmployeePosition")]
        public async Task<IActionResult> GetEmployeePosition()
        {
            return Ok(await _repo.GetEmployeePosition(UserHelper.GetUser(User)));
        }

        [HttpGet("GetMyTeamList")]
        public async Task<IActionResult> GetMyTeamList(string Type )
        {
            return Ok(await _repo.GetMyTeamList(UserHelper.GetUser(User),Type));
        }
    }
}
