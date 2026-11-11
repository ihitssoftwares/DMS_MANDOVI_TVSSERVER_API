using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.Custom
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FirstServiceCallController : Controller
    {
        #region Private properties
        private readonly IFirstServiceCallRepository _repo;
        #endregion
        #region Constructor        
        public FirstServiceCallController(IFirstServiceCallRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(int ServiceCode)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), ServiceCode));
        }
        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int RegistrationCode, int OrdertrnCode)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), RegistrationCode, OrdertrnCode));
        }
        #endregion
        [HttpPost("Save")]
        public async Task<IActionResult> Save(FirstServiceCall model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
