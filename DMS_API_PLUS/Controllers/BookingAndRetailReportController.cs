using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Repository.Repository.Custom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingAndRetailReportController : ControllerBase
    {
        #region Private properties
        private readonly IBookingAndRetailReportRepository _repo;
        #endregion
        #region Constructor        
        public BookingAndRetailReportController(IBookingAndRetailReportRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string Type, string FromDate, string ToDate, int Month)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Type, FromDate, ToDate, Month));
        }
        #endregion
    }
}
