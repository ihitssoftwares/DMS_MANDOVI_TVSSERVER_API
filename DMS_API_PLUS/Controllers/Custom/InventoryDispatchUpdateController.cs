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
    public class InventoryDispatchUpdateController : ControllerBase
    {
        #region Private properties
        private readonly IInventoryDispatchUpdateRepository _repo;
        #endregion
        #region Constructor        
        public InventoryDispatchUpdateController(IInventoryDispatchUpdateRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpPost("ImportDispatchFromExcel")]
        public async Task<IActionResult> ImportDispatchFromExcel(InventoryDispatchUpdate model)
        {
            return Ok(await _repo.ImportDispatchFromExcel(UserHelper.GetUser(User), model));
        }

        [HttpGet("GetDispatchStockList")]
        public async Task<IActionResult> GetDispatchStockList(int BatchCode)
        {
            return Ok(await _repo.GetDispatchStockList(UserHelper.GetUser(User), BatchCode));
        }

        [HttpGet("GetSummaryDetails")]
        public async Task<IActionResult> GetSummaryDetails(int BatchCode)
        {
            return Ok(await _repo.GetSummaryDetails(UserHelper.GetUser(User), BatchCode));
        }
        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int BatchCode)
        {
            return Ok(await _repo.Delete(UserHelper.GetUser(User), BatchCode));
        }

      
    }
}
