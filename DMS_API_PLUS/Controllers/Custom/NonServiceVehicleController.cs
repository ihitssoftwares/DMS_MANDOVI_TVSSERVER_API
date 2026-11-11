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
    public class NonServiceVehicleController : ControllerBase
    {
        #region Private properties
        private readonly INonServiceVehicleRepository _repo;
        #endregion

        #region Constructor        
        public NonServiceVehicleController(INonServiceVehicleRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }
        #endregion
        [HttpPost("Create")]
        public async Task<IActionResult> Create(NonServiceVehicle model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, model));
        }

        [HttpGet("GetNonServiceVehicleDetails")]
        public async Task<IActionResult> GetNonServiceVehicleDetails(int NonServiceVehicleCode, string mode)
        {
            return Ok(await _repo.GetNonServiceVehicleDetails(UserHelper.GetUser(User), NonServiceVehicleCode, mode));
        }
        [HttpPost("NonServiceVehicleDelete")]
        public async Task<IActionResult> NonServiceVehicleDelete(NonServiceVehicle model)
        {
            return Ok(await _repo.NonServiceVehicleDelete(UserHelper.GetUser(User), model));
        }
    }
}
