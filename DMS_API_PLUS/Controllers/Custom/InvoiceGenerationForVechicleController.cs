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
    public class InvoiceGenerationForVechicleController : ControllerBase
    {

        #region Private properties
        private readonly IInvoiceGenerationForVechicleRepository _repo;
        #endregion
        #region Constructor        
        public InvoiceGenerationForVechicleController(IInvoiceGenerationForVechicleRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Status)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Status));
        }

        [HttpGet("GetAccList")]
        public async Task<IActionResult> GetAccList(int OrderTrnCode)
        {
            return Ok(await _repo.GetAccList(UserHelper.GetUser(User), OrderTrnCode));
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int OrderTrnCode)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), OrderTrnCode));
        }


        [HttpPost("Save")]
        public async Task<IActionResult> Save(InvoiceGenerationForVechicle model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }

}