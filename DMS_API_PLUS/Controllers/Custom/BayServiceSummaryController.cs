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
    public class BayServiceSummaryController : ControllerBase
    {
        #region Private properties
        private readonly IBayServiceSummaryRepository _repo;
        #endregion
        #region Constructor        
        public BayServiceSummaryController(IBayServiceSummaryRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get

        [HttpGet("GetBayList")]
        public async Task<IActionResult> GetBayList(int WorkShopCode)
        {

            return Ok(await _repo.GetBayList(UserHelper.GetUser(User), WorkShopCode));
        } 
        [HttpGet("GetGateINList")]
        public async Task<IActionResult> GetGateINList(int WorkShopCode,string Date)
        {

            return Ok(await _repo.GetGateINList(UserHelper.GetUser(User), WorkShopCode,Date));
        } 
        [HttpGet("GetjobCardList")]
        public async Task<IActionResult> GetjobCardList(int WorkShopCode,string Date)
        {

            return Ok(await _repo.GetjobCardList(UserHelper.GetUser(User), WorkShopCode,Date));
        } 
        [HttpGet("GetBayVsTechList")]
        public async Task<IActionResult> GetBayVsTechList(int WorkShopCode,string Date)
        {

            return Ok(await _repo.GetBayVsTechList(UserHelper.GetUser(User), WorkShopCode,Date));
        } 
        [HttpGet("GetTechInOutList")]
        public async Task<IActionResult> GetTechInOutList(int WorkShopCode,string Date)
        {

            return Ok(await _repo.GetTechInOutList(UserHelper.GetUser(User), WorkShopCode,Date));
        }
        [HttpGet("GetjobcompletedList")]
        public async Task<IActionResult> GetjobcompletedList(int WorkShopCode, string Date)
        {

            return Ok(await _repo.GetjobcompletedList(UserHelper.GetUser(User), WorkShopCode, Date));
        }
        
        [HttpGet("GetBayDetailsList")]
        public async Task<IActionResult> GetBayDetailsList(int jcno)
        {

            return Ok(await _repo.GetBayDetailsList(UserHelper.GetUser(User), jcno));
        }

        [HttpGet("LoadJobCardDetails")]
        public async Task<IActionResult> LoadJobCardDetails(int jobCardNo)
        {

            return Ok(await _repo.LoadJobCardDetails(UserHelper.GetUser(User), jobCardNo));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(BayServiceSummary model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
        [HttpPost("JobCardSave")]
        public async Task<IActionResult> JobCardSave(BayServiceSummary model)
        {
            return Ok(await _repo.JobCardSave(UserHelper.GetUser(User), model));
        }
        [HttpPost("BayVsJobSave")]
        public async Task<IActionResult> BayVsJobSave(BayServiceSummary model)
        {
            return Ok(await _repo.BayVsJobSave(UserHelper.GetUser(User), model));
        }
        [HttpPost("BayVsTechSave")]
        public async Task<IActionResult> BayVsTechSave(BayServiceSummary model)
        {
            return Ok(await _repo.BayVsTechSave(UserHelper.GetUser(User), model));
        }
        [HttpPost("TechSave")]
        public async Task<IActionResult> TechSave(BayServiceSummary model)
        {
            return Ok(await _repo.TechSave(UserHelper.GetUser(User), model));
        }
        [HttpPost("JobCompleteionSave")]
        public async Task<IActionResult> JobCompleteionSave(BayServiceSummary model)
        {
            return Ok(await _repo.JobCompleteionSave(UserHelper.GetUser(User), model));
        }
        [HttpPost("GateOutSave")]
        public async Task<IActionResult> GateOutSave(BayServiceSummary model)
        {
            return Ok(await _repo.GateOutSave(UserHelper.GetUser(User), model));
        }
        

        #endregion
    }
}

