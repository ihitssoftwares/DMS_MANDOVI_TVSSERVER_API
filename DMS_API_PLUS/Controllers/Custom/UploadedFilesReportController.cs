using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class UploadedFilesReportController : Controller
    {
        #region Private properties
        private readonly IUploadedFilesReportRepository _repo;
        #endregion
        #region Constructor        
        public UploadedFilesReportController(IUploadedFilesReportRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string module, string month)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), module, month));
        }



    }
}
#endregion
