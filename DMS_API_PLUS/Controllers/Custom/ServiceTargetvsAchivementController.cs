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
    public class ServiceTargetvsAchivementController : Controller
    {
        #region Private properties
        private readonly IServiceTargetvsAchivementRepository _repo;
        #endregion
        #region Constructor        
        public ServiceTargetvsAchivementController(IServiceTargetvsAchivementRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int IncentiveGroup, int Region, int Parameter)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, IncentiveGroup, Region, Parameter));
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int months, int IncentiveGroups, int Region, int Parameters, int empCode)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), months, IncentiveGroups, Region, Parameters, empCode));

        }


    }
}
