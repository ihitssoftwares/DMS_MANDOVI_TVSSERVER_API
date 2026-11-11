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
    public class RegistrationFinalSubmitController : ControllerBase
    {

        #region Private properties
        private readonly IRegistrationFinalSubmitRepository _repo;
        #endregion
        #region Constructor        
        public RegistrationFinalSubmitController(IRegistrationFinalSubmitRepository repo)
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

        [HttpGet("Verify")]
        public async Task<IActionResult> Verify(int RegistrationCode, string Remarks, string Mode)
        {
            return Ok(await _repo.Verify(UserHelper.GetUser(User), RegistrationCode, Remarks, Mode));
        }
    }
}
