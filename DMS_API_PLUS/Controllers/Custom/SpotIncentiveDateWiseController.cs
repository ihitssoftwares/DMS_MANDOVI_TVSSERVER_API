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
    public class SpotIncentiveDateWiseController : ControllerBase
    {
        #region Private properties
        private readonly ISpotIncentiveDateWiseRepository _repo;
        #endregion
        #region Constructor        
        public SpotIncentiveDateWiseController(ISpotIncentiveDateWiseRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpPost("SpotIncentiveDateWiseSave")]
        public async Task<IActionResult> SpotIncentiveDateWiseSave(SpotIncentiveDateWise model)
        {
            return Ok(await _repo.SpotIncentiveDateWiseSave(UserHelper.GetUser(User), model));
        }


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month,int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month,Region));
        }
   [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int HdCode)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), HdCode));
        }
    }
}
