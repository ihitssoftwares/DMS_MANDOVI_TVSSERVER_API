using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.Mobile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.MobileApp
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GatePassController : ControllerBase
    {
        private readonly IGatePassRepository _repo;       
        public GatePassController(IGatePassRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("GatePassSave")]
        public async Task<IActionResult> GatePassSave([FromForm] GatePass model)
        {
            return Ok(await _repo.GatePassSave(UserHelper.GetUser(User),model));
        }
         [HttpPost("GetVehichleGatePassCodeSave")]
        public async Task<IActionResult> GetVehichleGatePassCodeSave(GatePass model)
        {
            return Ok(await _repo.GetVehichleGatePassCodeSave(UserHelper.GetUser(User),model));
        }

    }
}
