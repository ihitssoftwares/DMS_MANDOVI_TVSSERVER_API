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
    public class TodaysVehiclePickupReportController : ControllerBase
    {
        #region Private properties
        private readonly ITodaysVehiclePickupReportRepository _repo;
        #endregion
        #region Constructor        
        public TodaysVehiclePickupReportController(ITodaysVehiclePickupReportRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int BranchCode )
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), BranchCode));
        }


        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int Code)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), Code));
        }
    }
}
