using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class MisModelWiseReportController : Controller
    {
        #region Private properties
        private readonly IMisModelWiseReportRepository _repo;
        #endregion
        #region Constructor        
        public MisModelWiseReportController(IMisModelWiseReportRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int ReportType, int Branch, int Model, int SourceOfEnq, int Color, int Region,int Channel)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),  ReportType,  Branch,  Model,  SourceOfEnq,  Color,  Region, Channel));
        }
    }
}
