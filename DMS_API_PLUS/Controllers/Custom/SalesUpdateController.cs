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
    public class SalesUpdateController : ControllerBase
    {

        #region Private properties
        private readonly ISalesUpdateRepository _repo;
        #endregion
        #region Constructor        
        public SalesUpdateController(ISalesUpdateRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Status,int DealerCode)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Status, DealerCode));
        }

        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(int HDCode,int Status,int Model)
        {
            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), HDCode, Status, Model));
        }

        [HttpPost("EmployeeWiseUpdate")]
        public async Task<IActionResult> EmployeeWiseUpdate(SalesUpdate model)
        {
            return Ok(await _repo.EmployeeWiseUpdate(UserHelper.GetUser(User), model));
        }
        
        [HttpPost("EmployeeWiseDelete")]
        public async Task<IActionResult> EmployeeWiseDelete(SalesUpdate model)
        {
            return Ok(await _repo.EmployeeWiseDelete(UserHelper.GetUser(User), model));
        }

        [HttpGet("GetPlanAmount")]
        public async Task<IActionResult> GetPlanAmount(string Type,int Model, int Code)
        {
            return Ok(await _repo.GetPlanAmount(UserHelper.GetUser(User), Type, Model, Code));
        }

        [HttpGet("GetInsuranceAmount")]
        public async Task<IActionResult> GetInsuranceAmount(string Type, int Model, int Code)
        {
            return Ok(await _repo.GetInsuranceAmount(UserHelper.GetUser(User), Type, Model, Code));
        }

        [HttpGet("GetFinanceAmount")]
        public async Task<IActionResult> GetFinanceAmount(string Type, int Model, int Code)
        {
            return Ok(await _repo.GetFinanceAmount(UserHelper.GetUser(User), Type, Model, Code));
        }
    }
}
