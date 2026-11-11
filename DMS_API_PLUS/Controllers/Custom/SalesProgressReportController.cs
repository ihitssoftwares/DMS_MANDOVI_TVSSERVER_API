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
    public class SalesProgressReportController : ControllerBase
    {

        #region Private properties
        private readonly ISalesProgressReportRepository _repo;
        #endregion
        #region Constructor        
        public SalesProgressReportController(ISalesProgressReportRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(string monthStartDate, string monthEndDate)
        {

            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), monthStartDate, monthEndDate));
        }
    }
}
