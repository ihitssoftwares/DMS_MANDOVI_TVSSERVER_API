using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class ServicePreprocessingController : ControllerBase
    {
        #region Private properties
        private readonly IServicePreprocessingRepository _repo;
        #endregion
        #region Constructor        
        public ServicePreprocessingController(IServicePreprocessingRepository repo)
        {
            _repo = repo;
        }

        #endregion
        

        [HttpGet("GetProcessList")]
        public async Task<IActionResult> GetProcess(int MonthCode, int Region)
        {
            return Ok(await _repo.GetProcess(UserHelper.GetUser(User), MonthCode, Region));

        }

    }
}
