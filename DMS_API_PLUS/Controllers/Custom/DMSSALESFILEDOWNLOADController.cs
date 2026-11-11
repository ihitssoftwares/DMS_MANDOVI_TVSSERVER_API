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
    public class DMSSALESFILEDOWNLOADController : ControllerBase
    {
        #region Private properties
        private readonly IDMSSALESFILEDOWNLOADRepository _repo;
        #endregion
        #region Constructor        
        public DMSSALESFILEDOWNLOADController(IDMSSALESFILEDOWNLOADRepository repo)
        {
            _repo = repo;
        }

        #endregion

        [HttpPost("ImportFromExcel")]
        public async Task<IActionResult> ImportFromExcel(DMSSALESFILEDOWNLOAD model)
        {
            return Ok(await _repo.ImportFromExcel(UserHelper.GetUser(User), model));
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Region, int Branch)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User),  Month, Region, Branch));
        }
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int BatchCode)
        {
            return Ok(await _repo.Delete(UserHelper.GetUser(User), BatchCode));
        }
    }
}
