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
    public class SalesPositionController : ControllerBase
    {
        #region Private properties
        private readonly ISalesPositionRepository _repo;
        #endregion
        #region Constructor        
        public SalesPositionController(ISalesPositionRepository repo)
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
        [HttpPost("Create")]
        public async Task<IActionResult> Create(SalesPosition model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, model));
        }
        [HttpGet("GetPositionDetails")]
        public async Task<IActionResult> GetPositionDetails(int IncentiveCode, string mode, string Type)
        {
            return Ok(await _repo.GetPositionDetails(UserHelper.GetUser(User), IncentiveCode, mode, Type));
        }
        [HttpPost("DeletePostion")]
        public async Task<IActionResult> DeletePostion(SalesPosition model)
        {

            return Ok(await _repo.DeletePostion(UserHelper.GetUser(User), model));
        }
        #endregion
    }
}
