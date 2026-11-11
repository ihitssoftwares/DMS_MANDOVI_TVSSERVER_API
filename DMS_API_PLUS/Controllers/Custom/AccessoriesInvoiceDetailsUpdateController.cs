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
    public class AccessoriesInvoiceDetailsUpdateController : ControllerBase
    {
        #region Private properties
        private readonly IAccessoriesInvoiceDetailsUpdateRepository _repo;
        #endregion
        #region Constructor        
        public AccessoriesInvoiceDetailsUpdateController(IAccessoriesInvoiceDetailsUpdateRepository repo)
        {
            _repo = repo;
        }

        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int MonthCode, int BranchCode)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), MonthCode, BranchCode));
        }


        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int DtCode)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), DtCode));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(AccessoriesInvoiceDetailsUpdate model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
