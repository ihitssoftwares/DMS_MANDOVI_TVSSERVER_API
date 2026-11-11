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
    public class SalesPerformanceFYWiseController : ControllerBase
    {
        #region Private properties
        private readonly ISalesPerformanceFYWiseRepository _repo;
        #endregion
        #region Constructor        
        public SalesPerformanceFYWiseController(ISalesPerformanceFYWiseRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpGet("Getlist")]
        public async Task<IActionResult> GetTechnicanlist(int FY, int Branch,string FYText)
        {
            return Ok(await _repo.Getlist(UserHelper.GetUser(User), FY, Branch, FYText));

        }
    }
}
