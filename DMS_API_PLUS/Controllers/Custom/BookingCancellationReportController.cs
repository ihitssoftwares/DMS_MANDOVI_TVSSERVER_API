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
    public class BookingCancellationReportController : ControllerBase
    {
        #region Private properties
        private readonly IBookingCancellationReportRepository _repo;
        #endregion
        #region Constructor
        public BookingCancellationReportController(IBookingCancellationReportRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string Type, string FromDate, string ToDate, int Month, int ReportType)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Type, FromDate, ToDate, Month, ReportType));
        }
        #endregion
    }
}
