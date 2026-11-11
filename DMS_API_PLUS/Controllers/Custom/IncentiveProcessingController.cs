using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Repository.Repository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class IncentiveProcessingController : ControllerBase
    {
        #region Private properties
        private readonly IIncentiveProcessingRepository _repo;
        #endregion
        #region Constructor        
        public IncentiveProcessingController(IIncentiveProcessingRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Delearship, int Designation, int Incentive)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Delearship, Designation, Incentive));
        }

        [HttpPost("EmployeeWiseUpdate")]
        public async Task<IActionResult> EmployeeWiseUpdate(IncentiveProcessing model)
        {
            return Ok(await _repo.EmployeeWiseUpdate(UserHelper.GetUser(User), model));
        }

        [HttpGet("Process")]
        public async Task<IActionResult> Process(int Month, int Delearship, int Designation, int Incentive)
        {
            return Ok(await _repo.Process(UserHelper.GetUser(User),  Month, Delearship, Designation, Incentive));
        }

        [HttpGet("Validate")]
        public async Task<IActionResult> Validate(int Month, int Delearship, int Designation, int Incentive)
        {
            return Ok(await _repo.Validate(UserHelper.GetUser(User), Month, Delearship, Designation, Incentive));
        }

        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(int HDCode, int EmployeeCode)
        {
            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), HDCode, EmployeeCode));
        }

    }
}
