using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
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
    public class WorkshopFileUploadController : Controller
    {
        #region Private properties
        private readonly IWorkshopFileUploadRepository _repo;
        #endregion
        #region Constructor        
        public WorkshopFileUploadController(IWorkshopFileUploadRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string PickedDate)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), PickedDate));
        }
         [HttpGet("OrderList")]
        public async Task<IActionResult> OrderList(int FileCode)
        {

            return Ok(await _repo.OrderList(UserHelper.GetUser(User), FileCode));
        }
        [HttpPost("ImportFromExcel")]
        public async Task<IActionResult> ImportFromExcel(WorkshopFileUpload model)
        {
            return Ok(await _repo.ImportFromExcel(UserHelper.GetUser(User), model));
        }

        [HttpGet("GetListByParticular")]
        public async Task<IActionResult> GetListByParticular(int PaticularCode, string Date)
        {

            return Ok(await _repo.GetListByParticular(UserHelper.GetUser(User), PaticularCode, Date));
        }
        [HttpPost("SmartUpload")]
        public async Task<IActionResult> SmartUpload(WorkshopFileUpload model)
        {
            return Ok(await _repo.SmartUpload(UserHelper.GetUser(User), model));
        }

        [HttpPost("SmartUploadAutoFix")]
        public async Task<IActionResult> SmartUploadAutoFix(WorkshopFileUpload model)
        {
            return Ok(await _repo.SmartUploadAutoFix(UserHelper.GetUser(User), model));
        }

        [HttpPost]
        [Route("UploadFolder")]
        public async Task<IActionResult> UploadFolder()
        {
            string monthUpload = Request.Form["MonthUpload"];
            var result = await _repo.UploadFolder( UserHelper.GetUser(User),Request.Form.Files, monthUpload);
            return Ok(result);
        }

        [HttpPost("GetServerFileCount")]
        public async Task<IActionResult> GetServerFileCount(WorkshopFileUpload model)
        {
            int count = await _repo.GetServerFileCount(UserHelper.GetUser(User),model);
            return Ok(count);
        }
        #endregion
    }
}
