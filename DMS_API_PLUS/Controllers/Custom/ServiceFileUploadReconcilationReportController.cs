using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Authorization;
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
    public class ServiceFileUploadReconcilationReportController : Controller
    {
        #region Private properties
        private readonly IServiceFileUploadReconcilationReportRepository _repo;
        #endregion
        #region Constructor        
        public ServiceFileUploadReconcilationReportController(IServiceFileUploadReconcilationReportRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int Region)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Region));
        }

        [HttpGet("GetPopUp")]
        public async Task<IActionResult> GetPopUp(string date)
        {

            return Ok(await _repo.GetPopUp(UserHelper.GetUser(User), date));
        }

        [HttpGet("GetPopUp1")]
        public async Task<IActionResult> GetPopUp1(string date)
        {

            return Ok(await _repo.GetPopUp1(UserHelper.GetUser(User), date));
        }

        [HttpGet("GetPopUp2")]
        public async Task<IActionResult> GetPopUp2(string date)
        {

            return Ok(await _repo.GetPopUp2(UserHelper.GetUser(User), date));
        }


    }
}
