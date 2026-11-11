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
    public class OutSourcedWorkController : ControllerBase
    {
        #region Private properties
        private readonly IOutSourcedWorkRepository _repo;
        #endregion
        #region Constructor        
        public OutSourcedWorkController(IOutSourcedWorkRepository repo)
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
        public async Task<IActionResult> Create(OutSourcedWork model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, model));
        }
        [HttpGet("GetOutSourcedWorkDetails")]
        public async Task<IActionResult> GetOutSourcedWorkDetails(int Code, string mode, string Type)
        {
            return Ok(await _repo.GetOutSourcedWorkDetails(UserHelper.GetUser(User), Code, mode, Type));
        }
    }
}
