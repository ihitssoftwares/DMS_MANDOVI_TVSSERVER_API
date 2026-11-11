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
    public class McareCancellationController : ControllerBase
    {
        #region Private properties
        private readonly IMcareCancellationRepository _repo;
        #endregion
        #region Constructor        
        public McareCancellationController(IMcareCancellationRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int PlanCode,int EntryCode)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), PlanCode, EntryCode));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(McareCancellation model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
