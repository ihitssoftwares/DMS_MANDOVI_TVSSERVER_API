using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class ServiceIncentiveReportController : ControllerBase
    {
        #region Private properties
        private readonly IServiceIncentiveReportRepository _repo;
        #endregion
        #region Constructor        
        public ServiceIncentiveReportController(IServiceIncentiveReportRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int Parameter, int Region)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Parameter, Region));
        }
    }
}
