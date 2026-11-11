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
    public class MCareRegistrationReportController : ControllerBase
    {
        #region Private properties
        private readonly IMCareRegistrationReportRepository _repo;
        #endregion
        #region Constructor        
        public MCareRegistrationReportController(IMCareRegistrationReportRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int PlanCode, string Status, int RegionCode, int BranchCode)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), PlanCode, Status, RegionCode, BranchCode));
        }
        #endregion
    }
}
