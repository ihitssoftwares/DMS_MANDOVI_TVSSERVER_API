using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Shared.Custom;
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
    public class RTODetailsController : ControllerBase
    {
        #region Private properties
        private readonly IRTODetailsRepository _repo;
        #endregion
        #region Constructor        
        public RTODetailsController(IRTODetailsRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }

        [HttpGet("GetRegistrationDetails")]
        public async Task<IActionResult> GetRegistrationDetails(int RegistrationCode)
        {
            return Ok(await _repo.GetRegistrationDetails(UserHelper.GetUser(User), RegistrationCode));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(RTODetailsRegistration model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }

        [HttpGet("GetRTODetails")]
        public async Task<IActionResult> GetRTODetails(int RegistrationCode)
        {
            return Ok(await _repo.GetRTODetails(UserHelper.GetUser(User), RegistrationCode));
        }
    }
}