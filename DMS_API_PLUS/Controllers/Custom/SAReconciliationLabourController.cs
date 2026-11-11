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
    public class SAReconciliationLabourController : ControllerBase
    {
        #region Private properties
        private readonly ISAReconciliationLabourRepository _repo;
        #endregion

        #region Constructor
        public SAReconciliationLabourController(ISAReconciliationLabourRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Region, int Branch, string ServiceAdvisor, bool IsAssigned)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Region, Branch, ServiceAdvisor, IsAssigned));
        }

        [HttpGet("GetSADetails")]
        public async Task<IActionResult> GetSADetails(int Month, int Region, int Branch, string JCNumber, string LabourDescription)
        {
            return Ok(await _repo.GetSADetails(UserHelper.GetUser(User), Month, Region, Branch, JCNumber, LabourDescription));
        }

        [HttpGet("GetJCdetails")]
        public async Task<IActionResult> GetJCdetails(string JCNO)
        {
            return Ok(await _repo.GetJCdetails(UserHelper.GetUser(User), JCNO));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(SAReconciliationLabour model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
