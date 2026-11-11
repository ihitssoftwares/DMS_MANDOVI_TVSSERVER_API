using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.Mobile;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.MobileApp;

namespace DMS_API_PLUS.Controllers.MobileApp
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ColdCallEnquireDetailsController : ControllerBase
    {
        #region Private properties
        private readonly IColdCallEnqiureDetailsRepository _repo;
        #endregion
        #region Constructor        
        public ColdCallEnquireDetailsController(IColdCallEnqiureDetailsRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpPost("Save")]
        public async Task<IActionResult> Save(ColdCallEnquireDetails model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }

    }
}
