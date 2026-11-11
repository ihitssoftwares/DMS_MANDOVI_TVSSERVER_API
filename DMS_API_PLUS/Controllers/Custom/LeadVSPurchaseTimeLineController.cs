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
    public class LeadVSPurchaseTimeLineController : ControllerBase
    {

        #region Private properties
        private readonly ILeadVSPurchaseTimeLineRepository _repo;
        #endregion
        #region Constructor        
        public LeadVSPurchaseTimeLineController(ILeadVSPurchaseTimeLineRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int Model, string LeadType)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), Model, LeadType));
        }
    }
}
