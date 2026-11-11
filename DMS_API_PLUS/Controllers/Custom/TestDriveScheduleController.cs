using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class TestDriveScheduleController : ControllerBase
    {
        #region Private properties
        private readonly ITestDriveScheduleRepository _repo;
        #endregion
        #region Constructor        
        public TestDriveScheduleController(ITestDriveScheduleRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(string LeadNo)
        {
            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), LeadNo));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(TestDriveSchedule model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
        #endregion
    }
}
