using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class SalesSummaryReportController : Controller
    {
        #region Private properties
        private readonly ISalesSummaryReportRepository _repo;
        #endregion
        #region Constructor        
        public SalesSummaryReportController(ISalesSummaryReportRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(DateTime FromDate, DateTime ToDate, int TypeCode,DateTime? Date)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), FromDate, ToDate, TypeCode,Date));
        }
    }
}
