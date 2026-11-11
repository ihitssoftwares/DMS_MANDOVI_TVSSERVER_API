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
    public class ServiceParameterListController : Controller
    {
        #region Private properties
        private readonly IServiceParameterListRepository _repo;
        #endregion
        #region Constructor        
        public ServiceParameterListController(IServiceParameterListRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int IncentiveGroup)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), IncentiveGroup));
        }


    }
}
