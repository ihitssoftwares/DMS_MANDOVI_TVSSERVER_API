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
    public class MCareServiceEntryController : ControllerBase
    {
        #region Private properties
        private readonly IMCareServiceEntryRepository _repo;
        #endregion
        #region Constructor        
        public MCareServiceEntryController(IMCareServiceEntryRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetPopupDetails")]
        public async Task<IActionResult> GetPopupDetails( int RegEntryCode, int CustomerCode)
        {
            return Ok(await _repo.GetPopupDetails(UserHelper.GetUser(User), RegEntryCode, CustomerCode));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(MCareServiceEntry model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
        [HttpGet("ViewDetails")]
        public async Task<IActionResult> ViewDetails(int ServiceCode,int RegCode )
        {

            return Ok(await _repo.ViewDetails(UserHelper.GetUser(User),ServiceCode,RegCode));
        }
        #endregion
    }
}
