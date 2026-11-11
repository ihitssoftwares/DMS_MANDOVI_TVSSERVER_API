using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class DataValidationAlertsController : ControllerBase
    {
        #region Private properties
        private readonly IDataValidationAlertsRepository _repo;
        #endregion
        #region Constructor        
        public DataValidationAlertsController(IDataValidationAlertsRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetValidationList")]
        public async Task<IActionResult> GetValidationList(int ModuleCode, string Severity)
        {

            return Ok(await _repo.GetValidationList(UserHelper.GetUser(User), ModuleCode, Severity));
        }

        [HttpGet("GetAlertDetails")]
        public async Task<IActionResult> GetAlertDetails(string Type,int Code)
        {

            return Ok(await _repo.GetAlertDetails(UserHelper.GetUser(User), Type,Code));
        }
    }
}
