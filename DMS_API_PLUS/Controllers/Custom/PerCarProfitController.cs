using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class PerCarProfitController : ControllerBase
    {
        #region Private properties
        private readonly IPerCarProfitRepository _repo;
        #endregion
        #region Constructor        
        public PerCarProfitController(IPerCarProfitRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string Month)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month));
        }
        [HttpGet("GetFinanceExportToExcelList")]
        public async Task<IActionResult> GetFinanceExportToExcelList(int Month, string Branch)
        {
            return Ok(await _repo.GetFinanceExportToExcelList(UserHelper.GetUser(User), Month, Branch));
        }
        #endregion

    }
}
