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
    public class ColdCallController : ControllerBase
    {
        #region Private properties
        private readonly IColdCallRepository _repo;
        #endregion
        #region Constructor        
        public ColdCallController(IColdCallRepository repo)
        {
            _repo = repo;
        }

        #endregion

        [HttpPost("ImportFromExcel")]
        public async Task<IActionResult> ImportFromExcel(COLDCALLFILEDOWNLOAD model)
        {
            return Ok(await _repo.ImportFromExcel(UserHelper.GetUser(User), model));
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User),  Month));
        }
    }
}
