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
    public class TestDriveSettingsController : ControllerBase
    {
        #region Private properties
        private readonly ITestDriveSettingsRepository _repo;
        #endregion
        #region Constructor        
        public TestDriveSettingsController(ITestDriveSettingsRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(int Branch, int Model)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Branch, Model));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(TestDriveSettings input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetTestDriveSettingsDetails")]
        public async Task<IActionResult> GetTestDriveSettingsDetails(int VehicleCode, string mode)
        {
            return Ok(await _repo.GetTestDriveSettingsDetails(UserHelper.GetUser(User), VehicleCode, mode));
        }
        [HttpPost("DeleteTestDriveSettings")]
        public async Task<IActionResult> DeleteTestDriveSettings(TestDriveSettings model)
        {

            return Ok(await _repo.DeleteTestDriveSettings(UserHelper.GetUser(User), model));
        }
        #endregion
    }
}
