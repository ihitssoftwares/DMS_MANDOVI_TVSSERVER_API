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
    public class EnquiryFollowUpReportController : Controller
    {
        #region Private properties
        private readonly IEnquiryFollowUpReportRepository _repo;
        #endregion
        #region Constructor        
        public EnquiryFollowUpReportController(IEnquiryFollowUpReportRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int Region,int Branch)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Region,Branch));
        }




    }
}
