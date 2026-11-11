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
    public class WorkshopFileReportController : Controller
    {
        #region Private properties
        private readonly IWorkshopFileReportRepository _repo;
        #endregion
        #region Constructor        
        public WorkshopFileReportController(IWorkshopFileReportRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string Workshopcode, string FromDate, string ToDate)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Workshopcode, FromDate, ToDate));
        }
        [HttpGet("GetPopupList")]
        public async Task<IActionResult> GetPopupList(int FileCode, string FromDate, string ToDate, string workShop)
        {

            return Ok(await _repo.GetPopupList(UserHelper.GetUser(User), FileCode, FromDate, ToDate, workShop));
        }
        #endregion

    }
}
