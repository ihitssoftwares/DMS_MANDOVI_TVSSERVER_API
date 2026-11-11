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
    public class MCarePlanSettingsController : ControllerBase
    {

        #region Private properties
        private readonly IMCarePlanSettingsRepository _repo;
        #endregion

        #region Constructor
        public MCarePlanSettingsController(IMCarePlanSettingsRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> List(int PlanCode)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), PlanCode));
        }
        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int Type)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User),Type));
        }
        [HttpGet("GetEditDetails")]
        public async Task<IActionResult> GetEditDetails(int Code, int DtCode)
        {
            return Ok(await _repo.GetEditDetails(UserHelper.GetUser(User),  Code, DtCode));
        }
        #endregion
        [HttpPost("Save")]
        public async Task<IActionResult> Create(MCarePlanSettings model )
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
        [HttpPost("SaveSettings")]
        public async Task<IActionResult> SaveSettings(MCarePlanSettings model)
        {
            return Ok(await _repo.SaveSettings(UserHelper.GetUser(User), model));
        }
    }
}
