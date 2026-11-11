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
    public class ServiceIncentiveProcessingLockController : ControllerBase
    {
        #region Private properties
        private readonly IServiceIncentiveProcessingLockRepository _repo;
        #endregion
        #region Constructor        
        public ServiceIncentiveProcessingLockController(IServiceIncentiveProcessingLockRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(ServiceIncentiveProcessingLock model)
        {
            model.User = UserHelper.GetUser(User);
            return Ok(await _repo.Save(model,  model.User));
        }
    }
}
