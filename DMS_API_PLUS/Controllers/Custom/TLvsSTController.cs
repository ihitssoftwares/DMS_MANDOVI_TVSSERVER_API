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
    public class TLvsSTController : ControllerBase
    {
        #region Private properties
        private readonly ITLvsSTRepository _repo;
        #endregion
        #region Constructor        
        public TLvsSTController(ITLvsSTRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string data)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),data));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> AddNewStore(TLvsST input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetTLvsSTDetails")]
        public async Task<IActionResult> GetTLvsSTDetails(int TrnCode, string mode)
        {
            return Ok(await _repo.GetTLvsSTDetails(UserHelper.GetUser(User), TrnCode, mode));
        }
        [HttpPost("DeleteTLvsST")]
        public async Task<IActionResult> DeleteTLvsST(TLvsST model)
        {

            return Ok(await _repo.DeleteTLvsST(UserHelper.GetUser(User), model));
        }
        #endregion
    }
}
