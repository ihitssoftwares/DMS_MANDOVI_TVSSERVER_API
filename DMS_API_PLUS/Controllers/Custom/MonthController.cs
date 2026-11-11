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
    public class MonthController : ControllerBase
    {
        #region Private properties
        private readonly IMonthRepository _repo;
        #endregion
        #region Constructor        
        public MonthController(IMonthRepository repo)
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
        [HttpPost("AddNewMonth")]
        public async Task<IActionResult> AddNewMonth(Month input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetMonthDetails")]
        public async Task<IActionResult> GetMonthDetails(int MonthCode, string mode, string Type)
        {
            return Ok(await _repo.GetMonthDetails(UserHelper.GetUser(User), MonthCode, mode, Type));
        }
    }
}
