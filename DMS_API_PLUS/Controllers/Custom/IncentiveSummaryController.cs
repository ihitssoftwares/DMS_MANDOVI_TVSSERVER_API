using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class IncentiveSummaryController : ControllerBase
    {

        #region Private properties
        private readonly IIncentiveSummaryRepository _repo;
        #endregion
        #region Constructor        
        public IncentiveSummaryController(IIncentiveSummaryRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Delearship, int Designation, int Branch)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Delearship, Designation,Branch));
        }


        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(int Month, int Delearship, int Designation,int EmployeeCode)
        {
            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), Month, Delearship, Designation,EmployeeCode));
        }


        [HttpGet("SummaryExcel")]
        public async Task<IActionResult> SummaryExcel(int Month, int Delearship, int Designation, int Branch)
        {
            return Ok(await _repo.SummaryExcel(UserHelper.GetUser(User), Month, Delearship, Designation,Branch));
        }
    }
}
