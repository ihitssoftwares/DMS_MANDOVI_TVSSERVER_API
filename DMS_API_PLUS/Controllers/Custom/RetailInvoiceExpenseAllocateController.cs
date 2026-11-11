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
    public class RetailInvoiceExpenseAllocateController : ControllerBase
    {
        #region Private properties
        private readonly IRetailInvoiceExpenseAllocateRepository _repo;
        #endregion

        #region Constructor
        public RetailInvoiceExpenseAllocateController(IRetailInvoiceExpenseAllocateRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, string Status, string Branch)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Status, Branch));
        }
        //[HttpGet("GetExportToExcel")]
        //public async Task<IActionResult> GetExportToExcel(int Month, string Status, string Branch)
        //{
        //    return Ok(await _repo.GetExportToExcel(UserHelper.GetUser(User), Month, Status, Branch));
        //}

        [HttpGet("GetPopupDetails")]
        public async Task<IActionResult> GetPopupDetails(int SalesTrnCode)
        {
            return Ok(await _repo.GetPopupDetails(UserHelper.GetUser(User), SalesTrnCode));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(RetailInvoiceExpenseAllocate model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
