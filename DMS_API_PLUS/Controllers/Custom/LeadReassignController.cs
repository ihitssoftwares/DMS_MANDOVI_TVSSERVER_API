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
    public class LeadReassignController : ControllerBase
    {
        #region Private properties
        private readonly ILeadReassignRepository _repo;
        #endregion
        #region Constructor        
        public LeadReassignController(ILeadReassignRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpPost("GetList")]
        public async Task<IActionResult> GetList(Filter filter)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), filter));
        }


    

        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(int Trnno)
        {
            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), Trnno));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(LeadReassign model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
        [HttpGet("GetUpdatedDetails")]
        public async Task<IActionResult> GetUpdatedDetails(int Trnno)
        {
            return Ok(await _repo.GetUpdatedDetails(UserHelper.GetUser(User), Trnno));
        }

    }
}
