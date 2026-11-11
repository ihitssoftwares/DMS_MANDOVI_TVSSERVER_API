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
    public class DSEvsTLController : ControllerBase
    {
        #region Private properties
        private readonly IDSEvsTLRepository _repo;
        #endregion
        #region Constructor        
        public DSEvsTLController(IDSEvsTLRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string Code, string branch, string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),Code,branch,TabIndex));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(DSEvsTL input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetDSEvsTLDetails")]
        public async Task<IActionResult> GetDSEvsTLDetails(int TrnCode, string mode,int EmpCode)
        {
            return Ok(await _repo.GetDSEvsTLDetails(UserHelper.GetUser(User), TrnCode, mode,EmpCode));
        }
        [HttpPost("DeleteDSEvsTL")]
        public async Task<IActionResult> DeleteDSEvsTL(DSEvsTL model)
        {

            return Ok(await _repo.DeleteDSEvsTL(UserHelper.GetUser(User), model));
        }
        [HttpGet("GetUpdatedDetails")]
        public async Task<IActionResult> GetUpdatedDetails(int Trnno)
        {
            return Ok(await _repo.GetUpdatedDetails(UserHelper.GetUser(User), Trnno));
        }
        #endregion
    }
}
