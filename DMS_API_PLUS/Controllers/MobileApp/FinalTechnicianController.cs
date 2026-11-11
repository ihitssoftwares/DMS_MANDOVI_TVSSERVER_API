using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.Mobile;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.MobileApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalTechnicianController : Controller
    {
        #region Private properties
        private readonly IFinalTechnicionRepository _repo;
        #endregion
        #region Constructor        
        public FinalTechnicianController(IFinalTechnicionRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region 
       
        [HttpGet("TechnicionTiles")]
        public async Task<IActionResult> GetTechnicionTiles()
        {
            return Ok(await _repo.GetTechnicionTiles(UserHelper.GetUser(User)));
        }

        [HttpGet("SearchRegNo")]
        public async Task<IActionResult> MobileRegNoSearch(string REGNO)
        {
            return Ok(await _repo.MobileRegNoSearch(UserHelper.GetUser(User), REGNO));
        }

        [HttpGet("GetMCareDetails")]
        public async Task<IActionResult> GetMCareDetails(int CustomerCode)
        {
            return Ok(await _repo.GetMCareDetails(UserHelper.GetUser(User),CustomerCode));
        }

        [HttpGet("JobInProgress")]
        public async Task<IActionResult> GetJobInProgressList()
        {
            return Ok(await _repo.GetJobInProgressList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTechnicianRecentList")]
        public async Task<IActionResult> GetTechnicianRecentList()
        {
            return Ok(await _repo.GetTechnicianRecentList(UserHelper.GetUser(User)));
        }

        [HttpGet("GetTechnicianHistory")]
        public async Task<IActionResult> GetTechnicianHistory(string Date)
        {
            return Ok(await _repo.GetTechnicianHistory(UserHelper.GetUser(User),Date));
        }

        #endregion
        [HttpPost("GetServiceTechnicianSave")]
        public async Task<IActionResult> GetServiceTechnicianSave(FinalTechnician model, string Mode)
        {
            return Ok(await _repo.GetServiceTechnicianSave(UserHelper.GetUser(User), model,Mode));
        }
       
      
    }
}
