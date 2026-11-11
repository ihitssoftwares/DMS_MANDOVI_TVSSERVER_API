using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class AddLeadController : ControllerBase
    {
        #region Private properties
        private readonly IAddLeadRepository _repo;
        #endregion
        #region Constructor        
        public AddLeadController(IAddLeadRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }
       
        [HttpPost("Save")]
        public async Task<IActionResult> Save(AddLead model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }

    }
}
