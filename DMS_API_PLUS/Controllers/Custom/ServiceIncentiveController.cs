using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class ServiceIncentiveController : ControllerBase
    {
        #region Private properties
        private readonly IServiceIncentiveRepository _repo;
        #endregion
        #region Constructor        
        public ServiceIncentiveController(IServiceIncentiveRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpGet("GetIncentiveList")]
        public async Task<IActionResult> GetIncentiveList(int MonthCode, int IncentiveCode)
        {
            return Ok(await _repo.GetIncentiveList(UserHelper.GetUser(User),MonthCode,IncentiveCode));

        }

        [HttpGet("GetProcessList")]
        public async Task<IActionResult> GetProcessList(int MonthCode, int Region, int Employeecode)
        {
            return Ok(await _repo.GetProcessList(UserHelper.GetUser(User), MonthCode, Region,Employeecode));

        }

        [HttpGet("GetExcelProcessList")]
        public async Task<IActionResult> GetExcelProcessList(int MonthCode, int Region, int Employeecode)
        {
            return Ok(await _repo.GetExcelProcessList(UserHelper.GetUser(User), MonthCode, Region, Employeecode));

        }
        [HttpGet("GetExportToExcelList")]
        public async Task<IActionResult> GetExportToExcelList(int MonthCode, int Region)
        {
            return Ok(await _repo.GetExportToExcelList(UserHelper.GetUser(User), MonthCode, Region));
        }

    }
}
