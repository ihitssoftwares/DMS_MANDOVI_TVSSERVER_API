using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using SAMPLE_API_PLUS.Helper;

namespace DMS_API_PLUS.Controllers.Custom
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        #region Private properties
        private readonly IMobileRepository _repo;
        #endregion
        #region Constructor        
        public MobileController(IMobileRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet("DashBoardDetails")]
        public async Task<IActionResult> DashBoardDetails()
        {

            return Ok(await _repo.DashBoardDetails(UserHelper.GetUser(User)));
        }

        [HttpGet("SalesDetails")]
        public async Task<IActionResult> SalesDetails(string FromDate,string ToDate)
        {

            return Ok(await _repo.SalesDetails(UserHelper.GetUser(User), FromDate, ToDate));
        }

        [HttpGet("MobileSalesDetails")]
        public async Task<IActionResult> MobileSalesDetails(string FromDate, string ToDate, Guid EmployeeUserGI)
        {

            return Ok(await _repo.MobileSalesDetails(UserHelper.GetUser(User), FromDate, ToDate,EmployeeUserGI));
        }

        [HttpGet("GADetails")]
        public async Task<IActionResult> GADetails(string FromDate, string ToDate)
        {

            return Ok(await _repo.GADetails(UserHelper.GetUser(User), FromDate, ToDate));
        }

        [HttpGet("BookingDetails")]
        public async Task<IActionResult> BookingDetails()
        {

            return Ok(await _repo.BookingDetails(UserHelper.GetUser(User)));
        }

        [HttpGet("LeadDetails")]
        public async Task<IActionResult> LeadDetails(string Type)
        {

            return Ok(await _repo.LeadDetails(UserHelper.GetUser(User),Type));
        }
        [HttpGet("MobileLeadDetails")]
        public async Task<IActionResult> MobileLeadDetails(string Type,Guid EmployeeUserGI)
        {

            return Ok(await _repo.MobileLeadDetails(UserHelper.GetUser(User), Type, EmployeeUserGI));
        }

        [HttpGet("MobileBookingDetails")]
        public async Task<IActionResult> MobileBookingDetails(Guid EmployeeUserGI)
        {

            return Ok(await _repo.MobileBookingDetails(UserHelper.GetUser(User),EmployeeUserGI));
        }

        [HttpGet("BrowseDetails")]
        public async Task<IActionResult> BrowseDetails()
        {

            return Ok(await _repo.BrowseDetails(UserHelper.GetUser(User)));
        }

        [HttpGet("Offers")]
        public async Task<IActionResult> Offers(int TabCode)
        {

            return Ok(await _repo.Offers(UserHelper.GetUser(User), TabCode));
        }
    }
}
