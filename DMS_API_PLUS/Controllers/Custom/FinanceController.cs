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
    public class FinanceController : ControllerBase
    {

        #region Private properties
        private readonly IFinanceRepository _repo;
        #endregion
        #region Constructor        
        public FinanceController(IFinanceRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), TabIndex));
        }
        #endregion
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Finance model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, model));
        }
        [HttpGet("GetFinanceDetails")]
        public async Task<IActionResult> GetFinanceDetails(int FinancierCode, string mode)
        {
            return Ok(await _repo.GetFinanceDetails(UserHelper.GetUser(User), FinancierCode, mode));
        }
        [HttpPost("FinanceDelete")]
        public async Task<IActionResult> FinanceDelete(Finance model)
        {
            return Ok(await _repo.FinanceDelete(UserHelper.GetUser(User), model));
        }
    }
}
