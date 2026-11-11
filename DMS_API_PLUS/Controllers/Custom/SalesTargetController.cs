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
    public class SalesTargetController : ControllerBase
    {
        #region Private properties
        private readonly ISalesTargetRepository _repo;
        #endregion
        #region Constructor        
        public SalesTargetController(ISalesTargetRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(int Month,int Branch)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Branch));
        }
        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetEmployeeDetails(int Month,int Type,int TeamLeadCode)
        {

            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), Month, Type, TeamLeadCode));
        }
        [HttpPost("EmpSave")]
        public async Task<IActionResult> EmpSave(SalesTarget Model)
        {
            Model.User = UserHelper.GetUser(User);
            return Ok(await _repo.EmpSave(Model));
        }

        #endregion
    }
}
