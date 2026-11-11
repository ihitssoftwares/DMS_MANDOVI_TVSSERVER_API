using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.Mobile;
using Microsoft.AspNetCore.Http;
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
    public class MobileWorkshopManagerController : ControllerBase
    {
        #region Private properties
        private readonly IMobileWorkshopManagerRepository _repo;
        #endregion
        #region Constructor        
        public MobileWorkshopManagerController(IMobileWorkshopManagerRepository repo)
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

        [HttpGet("CardDetailsList")]
        public async Task<IActionResult> CardDetailsList(string Type)
        {
            return Ok(await _repo.CardDetailsList(UserHelper.GetUser(User), Type));
        }

        [HttpGet("BayList")]
        public async Task<IActionResult> BayList()
        {
            return Ok(await _repo.BayList(UserHelper.GetUser(User)));
        }


        [HttpGet("JobCardDetails")]
        public async Task<IActionResult> JobCardDetails(int JobCardEntryCode)
        {
            return Ok(await _repo.JobCardDetails(UserHelper.GetUser(User), JobCardEntryCode));
        }
        [HttpPost("UpdateJobCard")]
        public async Task<IActionResult> UpdateJobCard(int JobCardPhotoEntryCode, string Type)
        {

            return Ok(await _repo.UpdateJobCard(UserHelper.GetUser(User), JobCardPhotoEntryCode, Type));
        }

        [HttpGet("History")]
        public async Task<IActionResult> HistoryList(int ServiceAdvisorCode, DateTime PickedDate)
        {
            return Ok(await _repo.HistoryList(UserHelper.GetUser(User), ServiceAdvisorCode, PickedDate));
        }
        [HttpGet("HistoryDetails")]
        public async Task<IActionResult> HistoryDetails(int JobCardEntryCode)
        {
            return Ok(await _repo.HistoryDetails(UserHelper.GetUser(User), JobCardEntryCode));
        }
        [HttpGet("GetNotAssignedList")]
        public async Task<IActionResult> GetList()
        {

            return Ok(await _repo.GetNotAssignedList(UserHelper.GetUser(User)));
        }

        [HttpGet("GetCustomerDetails")]
        public async Task<IActionResult> GetCustomerDetails(int CustomerCode)
        {

            return Ok(await _repo.GetCustomerDetails(UserHelper.GetUser(User), CustomerCode));
        }
        [HttpGet("JobCardList")]
        public async Task<IActionResult> JobCardList()
        {

            return Ok(await _repo.JobCardList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetBayDetails")]
        public async Task<IActionResult> GetBayDetails(int JobCardCode)
        {
            return Ok(await _repo.GetBayDetails(UserHelper.GetUser(User), JobCardCode));
        }

        #endregion
        [HttpPost("SaveBay")]
        public async Task<IActionResult> SaveBay(MobileWorkshopManager model)
        {
            return Ok(await _repo.SaveBay(UserHelper.GetUser(User), model));
        }
        [HttpPost("PopupSave")]
        public async Task<IActionResult> PopupSave(MobileWorkshopManager model, int empcode)
        {

            return Ok(await _repo.PopupSave(UserHelper.GetUser(User), model, empcode));
        }
        [HttpPost("SaveEntry")]
        public async Task<IActionResult> SaveEntry(MobileWorkshopManager model)
        {

            return Ok(await _repo.SaveEntry(UserHelper.GetUser(User), model));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(int JobCardPhotoEntryCode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), JobCardPhotoEntryCode));
        }
    }
}
