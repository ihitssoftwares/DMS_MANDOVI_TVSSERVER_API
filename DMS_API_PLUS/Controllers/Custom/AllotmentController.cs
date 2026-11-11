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
    public class AllotmentController : ControllerBase
    {
        #region Private properties
        private readonly IAllotmentRepository _repo;
        #endregion
        #region Constructor        
        public AllotmentController(IAllotmentRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Model,int Variant, string Status)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Model,Variant,Status));
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int OrderTrnCode)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), OrderTrnCode));
        }
        [HttpGet("GetInvoice")]
        public async Task<IActionResult> GetInvoice(int Model, int Variant)
        {
            return Ok(await _repo.GetInvoice(UserHelper.GetUser(User), Model, Variant));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(Allotment model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
