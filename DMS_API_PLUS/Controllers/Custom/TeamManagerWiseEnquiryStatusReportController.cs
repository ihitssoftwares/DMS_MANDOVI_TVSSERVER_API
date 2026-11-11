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
    public class TeamManagerWiseEnquiryStatusReportController : ControllerBase
    {
        #region Private properties
        private readonly ITeamManagerWiseEnquiryStatusReportRepository _repo;
        #endregion
        #region Constructor        
        public TeamManagerWiseEnquiryStatusReportController(ITeamManagerWiseEnquiryStatusReportRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int MonthCode, int ModelCode, int SourceCode, int Channel, int Region, int Team)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), MonthCode, ModelCode, SourceCode,Channel,Region,Team));

        }

        
    }
}
