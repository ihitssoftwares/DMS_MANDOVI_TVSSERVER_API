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
    public class MCarePlanController : ControllerBase
    {
        #region Private properties
        private readonly IMCarePlanRepository _repo;
        #endregion
        #region Constructor        
        public MCarePlanController(IMCarePlanRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), TabIndex));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(MCarePlan model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, model));
        }
        [HttpGet("GetMCarePlanDetails")]
        public async Task<IActionResult> GetMCarePlanDetails(int MCarePlanCode, string mode, string Type)
        {
            return Ok(await _repo.GetMCarePlanDetails(UserHelper.GetUser(User), MCarePlanCode, mode, Type));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(MCarePlan model)
        {

            return Ok(await _repo.Delete(UserHelper.GetUser(User), model));
        }

        #endregion
    }
}
