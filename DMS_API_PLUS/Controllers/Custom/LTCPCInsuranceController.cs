using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class LTCPCInsuranceController : ControllerBase
    {
        #region Private properties
        private readonly ILTCPCInsuranceRepository _repo;
        #endregion
        #region Constructor        
        public LTCPCInsuranceController(ILTCPCInsuranceRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, int Designation,int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int Month, int Designation,int Region)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), Month, Designation,Region));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(LTCPCInsurance model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }         
    }
}
