using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class MCareDashBoardController : ControllerBase
    {
        #region Private properties
        private readonly IMCareDashBoardRepository _repo;
        #endregion
        #region Constructor        
        public MCareDashBoardController(IMCareDashBoardRepository repo)
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
        #region GetMonthlyRevenue
        [HttpGet("GetMonthlyRevenueData")]
        public async Task<IActionResult> GetMonthlyRevenueData(string monthlyRevenue)
        {

            return Ok(await _repo.GetMonthlyRevenueData(UserHelper.GetUser(User), monthlyRevenue));
        }
        #endregion
        #region GetTop10Data
        [HttpGet("GetTop10Data")]
        public async Task<IActionResult> GetTop10Data(string Top,int Region)
        {
            return Ok(await _repo.GetTop10Data(UserHelper.GetUser(User), Top,Region));
        }
        #endregion
        //[HttpGet("TotalPopup")]
        //public async Task<IActionResult> TotalPopup(int PlanCode)
        //{
        //    return Ok(await _repo.TotalPopup(UserHelper.GetUser(User), PlanCode));
        //}

        //[HttpGet("PolicyPopup")]
        //public async Task<IActionResult> PolicyPopup(int PlanCode)
        //{
        //    return Ok(await _repo.PolicyPopup(UserHelper.GetUser(User), PlanCode));
        //}
        //[HttpGet("CancelledPopup")]
        //public async Task<IActionResult> CancelledPopup(int PlanCode)
        //{
        //    return Ok(await _repo.CancelledPopup(UserHelper.GetUser(User), PlanCode));
        //}
        //[HttpGet("ExpiredPopup")]
        //public async Task<IActionResult> ExpiredPopup(int PlanCode)
        //{
        //    return Ok(await _repo.ExpiredPopup(UserHelper.GetUser(User), PlanCode));
        //}

        //[HttpGet("RenewalPopup")]
        //public async Task<IActionResult> RenewalPopup(int PlanCode)
        //{
        //    return Ok(await _repo.RenewalPopup(UserHelper.GetUser(User), PlanCode));
        //}

        //[HttpGet("CurrentplanPopup")]
        //public async Task<IActionResult> CurrentplanPopup(int PlanCode)
        //{
        //    return Ok(await _repo.CurrentplanPopup(UserHelper.GetUser(User), PlanCode));
        //}
        [HttpGet("Popup")]
        public async Task<IActionResult> Popup(int PlanCode,string Type)
        {
            return Ok(await _repo.Popup(UserHelper.GetUser(User), PlanCode,Type));
        }
    }
}
