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
    public class ServiceIncentiveProccesingReportController : ControllerBase
    {

        #region Private properties
        private readonly IServiceIncentiveProccesingReportRepository _repo;
        #endregion
        #region Constructor        
        public ServiceIncentiveProccesingReportController(IServiceIncentiveProccesingReportRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpGet("GetIncentiveList")]
        public async Task<IActionResult> GetIncentiveList(int MonthCode, int RegionCode,int BranchCode,int EmpCode)
        {
            return Ok(await _repo.GetIncentiveList(UserHelper.GetUser(User), MonthCode, RegionCode, BranchCode,EmpCode));

        }
        [HttpGet("GetPopupList")]
        public async Task<IActionResult> GetPopupList(int MonthCode, int Region, int branchCode, int EmpCode, int ParaCode, int InceCode)
        {
            return Ok(await _repo.GetPopupList(UserHelper.GetUser(User), MonthCode, Region, branchCode, EmpCode, ParaCode, InceCode));

        }

        [HttpGet("GetExcelProcessList")]
        public async Task<IActionResult> GetExcelProcessList(int MonthCode, int Region, int BranchCode,string Type,int Employeecode)
        {
            return Ok(await _repo.GetExcelProcessList(UserHelper.GetUser(User), MonthCode, Region,BranchCode,Type, Employeecode));

        }
    }
}
