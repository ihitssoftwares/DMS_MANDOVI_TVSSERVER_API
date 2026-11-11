using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class JobCardTrackingReportController : Controller
    {
        #region Private properties
        private readonly IJobCardTrackingReportRepository _repo;
        #endregion
        #region Constructor        
        public JobCardTrackingReportController(IJobCardTrackingReportRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(int WorkshopCode, string PickedDate)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), WorkshopCode, PickedDate));
        }
        [HttpGet("GetBayDetails")]
        public async Task<IActionResult> GetBayDetails(int JobCardEntryCode)
        {
            return Ok(await _repo.GetBayDetails(UserHelper.GetUser(User), JobCardEntryCode));
        }
        #endregion
    }
}
