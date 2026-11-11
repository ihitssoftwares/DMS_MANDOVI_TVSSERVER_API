using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class PriceSettingsController : Controller
    {
        #region Private properties
        private readonly IPriceSettingsRepository _repo;
        #endregion
        #region Constructor        
        public PriceSettingsController(IPriceSettingsRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(int Type,int Region)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Type, Region));
        }
        //[HttpGet("GetPriceSettingsDeatils")]
        //public async Task<IActionResult> GetPriceSettingsDetails(string mode, int Type)
        //{
        //    return Ok(await _repo.GetPriceSettingsDetails(UserHelper.GetUser(User), mode, Type));
        //}
        #endregion
        [HttpPost("Save")]
        public async Task<IActionResult> Save(PriceSettings model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model, mode));
        }
        [HttpGet("GetVarientDetails")]
        public async Task<IActionResult> GetVarientDetails(int PriceId, string mode)
        {
            return Ok(await _repo.GetVarientDetails(UserHelper.GetUser(User), PriceId, mode));
        }
    }
}
