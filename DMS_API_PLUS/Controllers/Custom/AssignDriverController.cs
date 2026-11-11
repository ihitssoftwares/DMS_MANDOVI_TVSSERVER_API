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
    public class AssignDriverController : ControllerBase
    {
        #region Private properties
        private readonly IAssignDriverRepository _repo;
        #endregion
        #region Constructor        
        public AssignDriverController(IAssignDriverRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int BranchCode, DateTime PreferredDate, int isAssigned)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), BranchCode, PreferredDate, isAssigned));
        }

        [HttpGet("GetCustomerList")]
        public async Task<IActionResult> GetCustomerList(int CustomerCode)
        {

            return Ok(await _repo.GetCustomerList(UserHelper.GetUser(User), CustomerCode));
        }

        [HttpPost("PopupSave")]
        public async Task<IActionResult> PopupSave(AssignDriver model,int empcode)
        {

            return Ok(await _repo.PopupSave(UserHelper.GetUser(User), model, empcode));
        }
    }

    
}
