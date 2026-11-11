
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cloud_Custom.Api.Repository.IRepository.General;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_Custom.Api.Shared.General;

namespace SAMPLE_API_PLUS.Controllers.General
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        #region Private properties
        private readonly ICommonRepository _repo;
        #endregion
        #region Constructor        
        public CommonController(ICommonRepository repo)
        {
            _repo = repo;
        }
        #endregion
        [HttpPost("UploadIformFileToBLOB")]
        public async Task<IActionResult> UploadIformFileToBLOB([FromForm] File FileObj, string SubFolder)
        {
            return Ok(await _repo.UploadIformFileToBLOB(UserHelper.GetUser(User), FileObj, SubFolder));
        }
        [HttpGet("GetEmployeeHeader")]
        public async Task<IActionResult> GetEmployeeHeader(Guid EmployeeGI)
        {
            return Ok(await _repo.GetEmployeeHeader(EmployeeGI, UserHelper.GetUser(User)));
        }
        [HttpGet("GetMasterInactiveValidation")]
        public async Task<IActionResult> GetMasterInactiveValidation(string Master, int Code)
        {

            return Ok(await _repo.GetMasterInactiveValidation(Master, Code, UserHelper.GetUser(User)));
        }
        [HttpGet("GetAPIUrl")]
        public async Task<IActionResult> GetAPIUrl()
        {
            return Ok(await _repo.GetAPIUrl(UserHelper.GetUser(User)));
        }
           [HttpGet("GetReceiptUrl")]
        public async Task<IActionResult> GetReceiptUrl()
        {
            return Ok(await _repo.GetReceiptUrl(UserHelper.GetUser(User)));
        }


        [HttpGet("GetExcelPassword")]
        public async Task<IActionResult> GetExcelPassword(string ReportName, string Type)
        {
            var obj = await _repo.GetExcelPassword(UserHelper.GetUser(User), ReportName, Type);
            string Password = Cryptography.Decrypt(obj.Password, true);
            obj.Password = Password;
            return Ok(obj);
        }
        [HttpGet("GetCurrentMonthDropdown")]
        public async Task<IActionResult> GetCurrentMonthDropdown()
        {
            return Ok(await _repo.GetCurrentMonthDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetCurrentLeavePeriod")]
        public async Task<IActionResult> GetCurrentLeavePeriod()
        {
            return Ok(await _repo.GetCurrentLeavePeriod(UserHelper.GetUser(User)));
        }
        [HttpGet("GetAttendanceProcessedLastMonth")]
        public async Task<IActionResult> GetAttendanceProcessedLastMonth()
        {
            return Ok(await _repo.GetAttendanceProcessedLastMonth(UserHelper.GetUser(User)));
        }
        [HttpGet("GetcertificateActive")]
        public async Task<IActionResult> GetcertificateActive()
        {
            return Ok(await _repo.GetcertificateActive(UserHelper.GetUser(User)));
        }  
        [HttpGet("GetReceipt")]
        public async Task<IActionResult> GetReceipt()
        {
            return Ok(await _repo.GetReceipt(UserHelper.GetUser(User)));
        }
        #region SOFTWARE URLS

        [HttpGet("GetSoftwareURLs")]
        public async Task<IActionResult> GetSoftwareURLs()
        {
            return Ok(await _repo.GetSoftwareURLs(UserHelper.GetUser(User)));

        }
        #endregion
        #region DYNAMIC FILE STORAGE
        [HttpGet("GetFileStorageType")] // FILE UPLOADING  to IIS, BLOB, AWS
        public async Task<IActionResult> GetFileStorageType()
        {
            return Ok(await _repo.GetFileStorageType(UserHelper.GetUser(User)));
        }

        //[HttpPost("UploadByteArrayToBLOB")]
        //public async Task<IActionResult> UploadByteArrayToBLOB([FromBody] File FileObj, string SubFolder)
        //{
        //    return Ok(await _repo.UploadByteArrayToBLOB(UserHelper.GetUser(User), FileObj, SubFolder));
        //}

        //[HttpPost("UploadIformFileToBLOB")]
        //public async Task<IActionResult> UploadIformFileToBLOB([FromForm] File FileObj, string SubFolder)
        //{
        //    return Ok(await _repo.UploadIformFileToBLOB(UserHelper.GetUser(User), FileObj, SubFolder));
        //}
        //[HttpPost("UploadByteArrayToIIS")]
        //public async Task<IActionResult> UploadByteArrayToIIS([FromBody] File FileObj, string SubFolder)
        //{
        //    return Ok(await _repo.UploadByteArrayToIIS(UserHelper.GetUser(User), FileObj, SubFolder));
        //}

        //[HttpPost("UploadIformFileToIIS")]
        //public async Task<IActionResult> UploadIformFileToIIS([FromForm] File FileObj, string SubFolder)
        //{
        //    return Ok(await _repo.UploadIformFileToIIS(UserHelper.GetUser(User), FileObj, SubFolder));
        //}

        //[HttpPost("UploadIformFileToAWS")]
        //public async Task<IActionResult> UploadIformFileToAWS([FromForm] File FileObj, string SubFolder)
        //{
        //    return Ok(await _repo.UploadIformFileToAWS(UserHelper.GetUser(User), FileObj, SubFolder));
        //}
        //[HttpPost("UploadByteArrayToAWS")]
        //public async Task<IActionResult> UploadByteArrayToAWS([FromBody] File FileObj, string SubFolder)
        //{
        //    return Ok(await _repo.UploadByteArrayToAWS(UserHelper.GetUser(User), FileObj, SubFolder));
        //}

#endregion
    }
}
