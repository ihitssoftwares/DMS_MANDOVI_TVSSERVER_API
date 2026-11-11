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
    public class LeadStatusController : ControllerBase
    {
        #region Private properties
        private readonly ILeadStatusRepository _repo;
        #endregion
        #region Constructor        
        public LeadStatusController(ILeadStatusRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string Type, string Fromdate, string ToDate, string Groupby)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Type, Fromdate, ToDate, Groupby));
        }
        #endregion
    }
}
