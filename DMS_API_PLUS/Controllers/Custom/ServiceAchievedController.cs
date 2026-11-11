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
    public class ServiceAchievedController : Controller
    {
        #region Private properties
        private readonly IServiceAchievedRepository _repo;
        #endregion
        #region Constructor        
        public ServiceAchievedController(IServiceAchievedRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int Designation, int Parameter)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Designation, Parameter));
        }
        #endregion
        [HttpPost("Save")]
        public async Task<IActionResult> Save(ServiceAchieved model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
