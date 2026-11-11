using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class IncentiveGroupVsDesignationController : Controller
    {
        #region Private properties
        private readonly IIncentiveGroupVsDesignationRepository _repo;
        #endregion
        #region Constructor        
        public IncentiveGroupVsDesignationController(IIncentiveGroupVsDesignationRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(int IncentiveCode)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), IncentiveCode));
        }
        #endregion
        [HttpPost("Save")]
        public async Task<IActionResult> Save(IncentiveGroupVsDesignation Model)
        {
            Model.user = UserHelper.GetUser(User);
            return Ok(await _repo.Save(Model));
        }
    }
}
