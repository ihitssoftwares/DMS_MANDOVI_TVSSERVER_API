using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Authorization;
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
    public class ReceiptController : Controller
    {

        #region Private properties
        private readonly IReceiptRepository _repo;
        #endregion
        #region Constructor        
        public ReceiptController(IReceiptRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), TabIndex));
        }

        #endregion

        [AllowAnonymous]
        [HttpGet("ReceiptJSON")]

        public async Task<IActionResult> ReceiptJSON(string RegGi, int RegCode)
        {


            return Json(await _repo.ReceiptJSON(RegGi, RegCode));
        }


        [HttpPost("Save")]
        public async Task<IActionResult> Save(Receipt model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
