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
    public class TechnicianEfficiencyController : ControllerBase
    {
        #region Private properties
        private readonly ITechnicianEfficiencyRepository _repo;
        #endregion
        #region Constructor        
        public TechnicianEfficiencyController(ITechnicianEfficiencyRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpGet("GetTechnicanlist")]
        public async Task<IActionResult> GetTechnicanlist(string date, int workshop)
        {
            return Ok(await _repo.GetTechnicanlist(UserHelper.GetUser(User), date, workshop));

        }
    }
}
