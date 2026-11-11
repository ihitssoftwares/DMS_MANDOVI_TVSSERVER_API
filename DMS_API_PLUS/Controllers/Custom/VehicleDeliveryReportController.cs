using Cloud_Custom.Api.Repository.IRepository.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class VehicleDeliveryReportController : ControllerBase
    {
        #region Private properties
        private readonly IVehicleDeliveryReportRepository _repo;
        #endregion
        #region Constructor        
        public VehicleDeliveryReportController(IVehicleDeliveryReportRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int Branch)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Branch));
        }
    }
}
