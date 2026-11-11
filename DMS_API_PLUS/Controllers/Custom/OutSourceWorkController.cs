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
    public class OutSourceWorkController : ControllerBase
    {
        #region Private properties
        private readonly IOutSourceWorkRepository _repo;
        #endregion
        #region Constructor        
        public OutSourceWorkController(IOutSourceWorkRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(int Month, int Branch,int Region)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Branch,Region));
        }
        [HttpGet("GetJcDetails")]
        public async Task<IActionResult> GetJcDetails(string JobCardCode, int Branch)
        {
            return Ok(await _repo.GetJcDetails(UserHelper.GetUser(User), JobCardCode,  Branch));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(OutSourceWork model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
        #endregion
    }
}
