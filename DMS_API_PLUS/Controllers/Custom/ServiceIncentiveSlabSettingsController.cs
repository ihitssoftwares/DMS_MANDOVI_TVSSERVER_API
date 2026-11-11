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
    public class ServiceIncentiveSlabSettingsController : ControllerBase
    {

        #region Private properties
        private readonly IServiceIncentiveSlabSettingsRepository _repo;
        #endregion
        #region Constructor        
        public ServiceIncentiveSlabSettingsController(IServiceIncentiveSlabSettingsRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string Branch, string Designation, string WEFDate)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User),Branch,Designation,WEFDate));
        }
        [HttpGet("GetParameterDetails")]
        public async Task<IActionResult> GetParameterDetails(int ParameterCode)
        {
            return Ok(await _repo.GetParameterDetails(UserHelper.GetUser(User), ParameterCode));
        }
        [HttpPost("ServiceSave")]
        public async Task<IActionResult> Save(ServiceIncentiveSlabSettings model)
        {
            return Ok(await _repo.ServiceSave(UserHelper.GetUser(User), model));
        }
    }
}
