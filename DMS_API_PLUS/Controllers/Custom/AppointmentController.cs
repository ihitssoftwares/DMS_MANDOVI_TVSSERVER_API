using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class AppointmentController : ControllerBase
    {
        #region Private properties
        private readonly IAppointmentRepository _repo;
        #endregion
        #region Constructor        
        public AppointmentController(IAppointmentRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpPost("AppointmentSave")]
        public async Task<IActionResult> AppointmentSave(Appointment model)
        {
            return Ok(await _repo.AppointmentSave(UserHelper.GetUser(User), model));
        }


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string FromDate, string ToDate)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User),FromDate, ToDate));
        }
    }
}
