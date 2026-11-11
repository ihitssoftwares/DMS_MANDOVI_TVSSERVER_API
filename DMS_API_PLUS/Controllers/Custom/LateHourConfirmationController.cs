using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Custom;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMPLE_API_PLUS.Controllers.Custom
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LateHourConfirmationController : Controller
    {
        #region Private properties
        private readonly ILateHourConfirmationRepository _repo;
        #endregion
        #region Constructor        
        public LateHourConfirmationController(ILateHourConfirmationRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpPost("ConfirmationList_PROFANT")]
        public async Task<IActionResult> ConfirmationList_PROFANT(string TabIndex, int Month, Filter filter)
        {
            return Ok(await _repo.ConfirmationList_PROFANT(UserHelper.GetUser(User), TabIndex, Month, filter));
        }
        [HttpGet("GetEmployeeAttnDetails_PROFANT")]
        public async Task<IActionResult> GetEmployeeAttnDetails_PROFANT(int Month, Guid EmployeeGI)
        {
            return Ok(await _repo.GetEmployeeAttnDetails_PROFANT(UserHelper.GetUser(User), Month, EmployeeGI));
        }

        [HttpPost("LessHourConfirmationSave_PROFANT")]
        public async Task<IActionResult> LessHourConfirmationSave_PROFANT(AttendanceWagesConfirmation Model)
        {
            Model.User = UserHelper.GetUser(User);
            return Ok(await _repo.LessHourConfirmationSave_PROFANT(Model));
        }


        [HttpPost("ConfirmationList_PROFANT_EXCEL")]
        public async Task<IActionResult> ConfirmationList_PROFANT_EXCEL(int Month, string Tab, Filter filter)
        {
            return Ok(await _repo.ConfirmationList_PROFANT_EXCEL(UserHelper.GetUser(User), Month, Tab, filter));
        }

        [HttpPost("Update_PROFANT")]
        public async Task<IActionResult> Update_PROFANT(AttendanceWagesConfirmation model)
        {
            model.User = UserHelper.GetUser(User);
            return Ok(await _repo.Update_PROFANT(model));
        }
    }
}
