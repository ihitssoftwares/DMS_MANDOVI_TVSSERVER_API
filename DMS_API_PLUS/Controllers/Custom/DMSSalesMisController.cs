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
    public class DMSSalesMisController : ControllerBase
    {
        #region Private properties
        private readonly IDMSSalesMisRepository _repo;
        #endregion
        #region Constructor        
        public DMSSalesMisController(IDMSSalesMisRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetTabDetails")]
        public async Task<IActionResult> GetTabDetails(int Delearship,  string Fromdate, string ToDate)
        {
            return Ok(await _repo.GetTabDetails(UserHelper.GetUser(User), Delearship,  Fromdate, ToDate));
        }

        [HttpGet("GetBranchWiseDetails")]
        public async Task<IActionResult> GetBranchWiseDetails(int Delearship,  string Fromdate, string ToDate)
        {
            return Ok(await _repo.GetBranchWiseDetails(UserHelper.GetUser(User), Delearship, Fromdate, ToDate));
        }

        [HttpGet("GetModelWiseDetails")]
        public async Task<IActionResult> GetModelWiseDetails(int Delearship,  string Fromdate, string ToDate)
        {
            return Ok(await _repo.GetModelWiseDetails(UserHelper.GetUser(User), Delearship, Fromdate, ToDate));
        }

        [HttpGet("GetTLWiseDetails")]
        public async Task<IActionResult> GetTLWiseDetails(int Delearship, string Fromdate, string ToDate)
        {
            return Ok(await _repo.GetTLWiseDetails(UserHelper.GetUser(User), Delearship, Fromdate, ToDate));
        }


        [HttpGet("GetTLVSEMPLOYEEDetails")]
        public async Task<IActionResult> GetTLVSEMPLOYEEDetails(int Delearship, string Fromdate, string ToDate,int TLEmployeeCode)
        {
            return Ok(await _repo.GetTLVSEMPLOYEEDetails(UserHelper.GetUser(User), Delearship,  Fromdate, ToDate, TLEmployeeCode));
        }

        [HttpGet("GetVariantWiseDetails")]
        public async Task<IActionResult> GetVariantWiseDetails(int Delearship, string Fromdate, string ToDate)
        {
            return Ok(await _repo.GetVariantWiseDetails(UserHelper.GetUser(User), Delearship,  Fromdate, ToDate));
        }

        [HttpGet("GetV1Details")]
        public async Task<IActionResult> GetV1Details(int Branch, string Fromdate, string ToDate, int Model)
        {
            return Ok(await _repo.GetV1Details(UserHelper.GetUser(User),  Branch,  Fromdate,  ToDate,  Model));
        }
    }
}
