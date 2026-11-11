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
    public class BookedAppointmentController : Controller
    {
        #region Private properties
        private readonly IBookedAppointmentRepository _repo;
        #endregion
        #region Constructor        
        public BookedAppointmentController(IBookedAppointmentRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int AppoinmentStatus)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), AppoinmentStatus));
        }

        [HttpGet("GetSearchList")]
        public async Task<IActionResult> GetSearchList(string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo)
        {
            return Ok(await _repo.GetSearchList(UserHelper.GetUser(User), SearchCustomerName, SearchCustomerRegisterNo, SearchPhoneNo));
        }



        [HttpGet("GetSearchDetails")]
        public async Task<IActionResult> GetSearchDetails(string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo)
        {
            return Ok(await _repo.GetSearchDetails(UserHelper.GetUser(User), SearchCustomerName, SearchCustomerRegisterNo, SearchPhoneNo));
        }

    }
}
