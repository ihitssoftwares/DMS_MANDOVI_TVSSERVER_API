using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
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
    public class SpotIncentiveModelWiseController : ControllerBase
    {
        #region Private properties
        private readonly ISpotIncentiveModelWiseRepository _repo;
        #endregion
        #region Constructor        
        public SpotIncentiveModelWiseController(ISpotIncentiveModelWiseRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpPost("SpotIncentiveModelWiseSave")]
        public async Task<IActionResult> SpotIncentiveModelWiseSave(SpotIncentiveModelWise model)
        {
            return Ok(await _repo.SpotIncentiveModelWiseSave(UserHelper.GetUser(User), model));
        }


        [HttpPost("GetList")]
        public async Task<IActionResult> GetList([FromBody] Filter filter, int Month, int Model, int Ageing, string Status)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), filter, Month, Model, Ageing, Status));
        }
        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int HdCode, string VIN)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), HdCode,VIN));
        }
    }
}
