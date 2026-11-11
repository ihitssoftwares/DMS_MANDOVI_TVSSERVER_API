using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class SeviceAchivementvsTargetController : Controller
    {
        #region Private properties
        private readonly ISeviceAchivementvsTargetRepository _repo;
        #endregion
        #region Constructor        
        public SeviceAchivementvsTargetController(ISeviceAchivementvsTargetRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Region, int MonthCode, int ParameterCode)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Region, MonthCode, ParameterCode));
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int parameterCode, int IncentiveGroupCode, int RegionCode, int BranchCode, int MonthCode)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User),parameterCode,IncentiveGroupCode,RegionCode,BranchCode,MonthCode));
        }


        [HttpGet("GetDrillDownDetails")]
        public async Task<IActionResult> GetDrillDownDetails(int MonthCode, int parameterCode, int EmployeeCode)
        {
            return Ok(await _repo.GetDrillDownDetails(UserHelper.GetUser(User), MonthCode, parameterCode, EmployeeCode));
        }
    }
}
