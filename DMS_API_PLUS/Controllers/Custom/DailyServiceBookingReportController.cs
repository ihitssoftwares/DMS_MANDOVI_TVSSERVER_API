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
    public class DailyServiceBookingReportController : ControllerBase
    {
        #region Private properties
        private readonly IDailyServiceBookingReportRepository _repo;
        #endregion
        #region Constructor        
        public DailyServiceBookingReportController(IDailyServiceBookingReportRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int BranchCode,DateTime PreferredDate)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),BranchCode, PreferredDate));
        }
    }
}
