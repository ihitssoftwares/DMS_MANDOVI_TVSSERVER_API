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
    public class DSEEnquiryReportController : ControllerBase
    {
        #region Private properties
        private readonly IDSEEnquiryReportRepository _repo;
        #endregion
        #region Constructor        
        public DSEEnquiryReportController(IDSEEnquiryReportRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string From, string To, string Type, string RegionCode, string BranchCode)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), From, To, Type, RegionCode, BranchCode));

        }
    }
}
