using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class VehiclesDeliveryController : ControllerBase
    {
        #region Private properties
        private readonly IVehiclesDeliveryRepository _repo;
        #endregion
        #region Constructor        
        public VehiclesDeliveryController(IVehiclesDeliveryRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int Branch)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Branch));
        }

        [HttpGet("GetPopUpDetails")]
        public async Task<IActionResult> GetPopUpDetails(int OrderTrnCode)
        {

            return Ok(await _repo.GetPopUpDetails(UserHelper.GetUser(User), OrderTrnCode));
        }

        [HttpPost("PopupSave")]
        public async Task<IActionResult> PopupSave(VehiclesDelivery vehicleModel)
        {

            return Ok(await _repo.PopupSave(UserHelper.GetUser(User), vehicleModel));
        }

    }
}
