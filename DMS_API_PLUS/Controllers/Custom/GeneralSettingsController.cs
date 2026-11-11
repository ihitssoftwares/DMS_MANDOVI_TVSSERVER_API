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
    public class GeneralSettingsController : ControllerBase
    {
        #region Private properties
        private readonly IGeneralSettingsRepository _repo;
        #endregion
        #region Constructor        
        public GeneralSettingsController(IGeneralSettingsRepository repo)
        {
            _repo = repo;
        }

        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }


  

        [HttpPost("Save")]
        public async Task<IActionResult> Save(GeneralSettings model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
