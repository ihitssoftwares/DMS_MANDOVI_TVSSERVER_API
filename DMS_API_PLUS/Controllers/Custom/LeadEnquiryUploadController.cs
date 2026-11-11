using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
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
    public class LeadEnquiryUploadController : ControllerBase
    {
        #region Private properties
        private readonly ILeadEnquiryUploadRepository _repo;
        #endregion
        #region Constructor        
        public LeadEnquiryUploadController(ILeadEnquiryUploadRepository repo)
        {
            _repo = repo;
        }

        #endregion

        [HttpPost("ImportFromExcel")]
        public async Task<IActionResult> ImportFromExcel([FromBody]LeadEnquiryUpload model)
        {
            return Ok(await _repo.ImportFromExcel(UserHelper.GetUser(User), model));
        }

        

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList(Filter filter, int Month)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), filter, Month));
        }
    }
}
