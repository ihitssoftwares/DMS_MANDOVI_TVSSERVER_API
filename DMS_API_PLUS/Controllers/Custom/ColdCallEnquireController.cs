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
    public class ColdCallEnquireController : ControllerBase
    {
        #region Private properties
        private readonly IColdCallEnquireRepository _repo;
        #endregion
        #region Constructor        
        public ColdCallEnquireController(IColdCallEnquireRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }

        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(string ColdCallNo)
        {
            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), ColdCallNo));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(ColdCallEnquire model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }

    }
}
