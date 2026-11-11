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
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : Controller
    {
        #region Private properties
        private readonly ICertificateRepository _repo;
        #endregion
        #region Constructor        
        public CertificateController(ICertificateRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }

        #endregion

        [HttpGet("GetCertificateDetails")]
        public async Task<IActionResult> GetCertificateDetails(int RegEntryCode)
        {
            return Ok(await _repo.GetCertificateDetails(UserHelper.GetUser(User), RegEntryCode));
        }
        [AllowAnonymous]
        [HttpGet("CertificateJSON")]
      
        public async Task<IActionResult> CertificateJSON(string RegGi,int RegCode )
        {


            return Json(await _repo.CertificateJSON(RegGi, RegCode));
        }
    }
}
