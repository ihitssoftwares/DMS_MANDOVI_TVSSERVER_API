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
    public class TestDriveController : ControllerBase
    {
        #region Private properties
        private readonly ITestDriveRepository _repo;
        #endregion
        #region Constructor        
        public TestDriveController(ITestDriveRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(String Type)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Type));
        }
         [HttpGet("GetLead")]
        public async Task<IActionResult> GetLead(String Customer)
        {

            return Ok(await _repo.GetLead(UserHelper.GetUser(User), Customer));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(TestDrive model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(string LeadNo)
        {
            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), LeadNo));
        }
        #endregion
    }
}
