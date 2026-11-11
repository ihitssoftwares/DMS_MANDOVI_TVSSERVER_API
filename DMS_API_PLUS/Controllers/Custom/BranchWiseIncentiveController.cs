using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class BranchWiseIncentiveController : ControllerBase
    {
        #region Private properties
        private readonly IBranchWiseIncentiveRepository _repo;
        #endregion
        #region Constructor        
        public BranchWiseIncentiveController(IBranchWiseIncentiveRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int Parameter, int Region,int IncentiveGroup)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Parameter, Region,IncentiveGroup));
        }

       

        

        [HttpGet("GetBranchWiseIncentiveDetails")]
        public async Task<IActionResult> GetBranchWiseIncentiveDetails(int HdCode, int BranchCode, int IncentiveGroupCode, int month, int Parameter, int Region)
        {
            return Ok(await _repo.GetBranchWiseIncentiveDetails(UserHelper.GetUser(User), HdCode, BranchCode, IncentiveGroupCode, month, Parameter, Region));
        }

        [HttpPost("BranchWiseIncentiveSave")]
        public async Task<IActionResult> BranchWiseIncentiveSave(BranchWiseIncentive model)
        {
            return Ok(await _repo.BranchWiseIncentiveSave(UserHelper.GetUser(User), model));
        }


        
    }
}
