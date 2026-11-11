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
    public class MCareServiceReportController : ControllerBase
    {
        #region Private properties
        private readonly IMCareServiceReportRepository _repo;
        #endregion
        #region Constructor        
        public MCareServiceReportController(IMCareServiceReportRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int PlanCode)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), PlanCode));
        }

        [HttpGet("GetPopupDetails")]
        public async Task<IActionResult> GetPopupDetails(int RegEntryCode, int CustomerCode)
        {
            return Ok(await _repo.GetPopupDetails(UserHelper.GetUser(User), RegEntryCode, CustomerCode));
        }

        #endregion
    }
}
