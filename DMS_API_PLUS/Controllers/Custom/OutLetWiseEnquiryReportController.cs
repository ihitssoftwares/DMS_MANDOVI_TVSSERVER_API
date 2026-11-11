using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.General;
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
    public class OutLetWiseEnquiryReportController : ControllerBase
    {
        #region Private properties
        private readonly IOutLetWiseEnquiryReportRepository _repo;
        #endregion
        #region Constructor        
        public OutLetWiseEnquiryReportController(IOutLetWiseEnquiryReportRepository repo)
        {
            _repo = repo;
        }
        #endregion
        [HttpPost("GetList")]
        public async Task<IActionResult> GetList(int MonthCode, int ModelCode, int EnquiryCode, Filter filter)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), MonthCode, ModelCode, EnquiryCode, filter));
        }
        [HttpGet("GetPopUpDetails")]
        public async Task<IActionResult> GetPopUpDetails(string ColType, string channel, string regionName, string branchCode, string monthCode, string modelCode, string enquiryCode, string Type)
        {

            return Ok(await _repo.GetPopUpDetails(UserHelper.GetUser(User), ColType, channel, regionName, branchCode, monthCode, modelCode, enquiryCode, Type));
        }
    }
}
