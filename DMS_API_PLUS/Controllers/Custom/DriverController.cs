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
    public class DriverController : Controller
    {
        #region Private properties
        private readonly IDriverRepository _repo;
        #endregion
        #region Constructor        
        public DriverController(IDriverRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("DriverDetails")]
        public async Task<IActionResult> DriverDetails()
        {
            return Ok(await _repo.DriverDetails(UserHelper.GetUser(User)));
        }
        [HttpGet("PickupList")]
        public async Task<IActionResult> PickupList()
        {
            return Ok(await _repo.PickupList(UserHelper.GetUser(User)));
        }

        #endregion
        [HttpPost("UpdateEntryStatus")]
        public async Task<IActionResult> UpdateEntryStatus(Driver model)
        {

            return Ok(await _repo.UpdateEntryStatus(UserHelper.GetUser(User), model));
        }
        [HttpPost("UpdateExitStatus")]
        public async Task<IActionResult> SaveEntry(Driver model)
        {

            return Ok(await _repo.UpdateExitStatus(UserHelper.GetUser(User), model));
        }
        
    }
}
