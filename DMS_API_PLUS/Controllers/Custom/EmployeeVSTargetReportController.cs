using Cloud_Custom.Api.Repository.IRepository.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class EmployeeVSTargetReportController : Controller
    {
        #region Private properties
        private readonly IEmployeeVSTargetReportRepository _repo;
        #endregion
        #region Constructor        
        public EmployeeVSTargetReportController(IEmployeeVSTargetReportRepository repo)
        {
            _repo = repo;
        }
        #endregion
        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int Region, int Branch, int Parameter)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Region, Branch, Parameter));
        }
    }
}
