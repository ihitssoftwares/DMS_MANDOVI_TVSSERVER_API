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
    public class MCareServicesController : ControllerBase
    {
        #region Private properties
        private readonly IMCareServicesRepository _repo;
        #endregion

        #region Constructor
        public MCareServicesController(IMCareServicesRepository repo)
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
        public async Task<IActionResult> Create(MCareServices model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, model));
        }

        [HttpGet("GetMCareServicesDetails")]
        public async Task<IActionResult> GetMCareServicesDetails(int MCareServicesCode, string mode, string Type)
        {
            return Ok(await _repo.GetMCareServicesDetails(UserHelper.GetUser(User), MCareServicesCode, mode, Type));
        }

        [HttpPost("DeleteMCareServices")]
        public async Task<IActionResult> DeleteMCareServices(MCareServices model)
        {
            return Ok(await _repo.DeleteMCareServices(UserHelper.GetUser(User), model));
        }
        #endregion
    }
}
