using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.General;
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
    public class ColdFollowUpReportController : ControllerBase
    {

        #region Private properties
        private readonly IColdFollowUpReportRepository _repo;
        #endregion
        #region Constructor        
        public ColdFollowUpReportController(IColdFollowUpReportRepository repo)
        {
            _repo = repo;
        }

        #endregion


       

        [HttpPost("GetList")]
        public async Task<IActionResult> List(Filter filter, string FromDate, string Todate, int Region, int Branch, string Status)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), filter, FromDate, Todate,Region,Branch, Status));
        }

        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(int Trnno)
        {
            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), Trnno));
        }
    }

}
