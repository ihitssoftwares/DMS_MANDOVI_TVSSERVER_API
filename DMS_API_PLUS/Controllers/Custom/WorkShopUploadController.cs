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
    public class WorkShopUploadController : ControllerBase
    {
        #region Private properties
        private readonly IWorkShopUploadRepository _repo;
        #endregion
        #region Constructor        
        public WorkShopUploadController(IWorkShopUploadRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string PickedDate)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), PickedDate));
        }
        [HttpGet("GetEntryDateList")]
        public async Task<IActionResult> GetEntryDateList(string PickedDate)
        {

            return Ok(await _repo.GetEntryDateList(UserHelper.GetUser(User), PickedDate));
        }
        [HttpGet("OrderList")]
        public async Task<IActionResult> OrderList(int FileCode)
        {

            return Ok(await _repo.OrderList(UserHelper.GetUser(User), FileCode));
        }
        [HttpPost("ImportFromExcel")]
        public async Task<IActionResult> ImportFromExcel(WorkShopUpload model)
        {
            return Ok(await _repo.ImportFromExcel(UserHelper.GetUser(User), model));
        }

        [HttpGet("GetListByParticular")]
        public async Task<IActionResult> GetListByParticular(int WorkshopCode, int ParticularCode, string Date)
        {

            return Ok(await _repo.GetListByParticular(UserHelper.GetUser(User), WorkshopCode, ParticularCode,Date));
        }
          [HttpGet("EntryListperPopularList")]
        public async Task<IActionResult> EntryListperPopularList(int WorkshopCode, int ParticularCode, string Date)
        {

            return Ok(await _repo.EntryListperPopularList(UserHelper.GetUser(User), WorkshopCode, ParticularCode,Date));
        }

        [HttpGet("GetWorkShopList")]
        public async Task<IActionResult> GetWorkShopList(string ParticularName, string Date)
        {

            return Ok(await _repo.GetWorkShopList(UserHelper.GetUser(User), ParticularName, Date));
        } [HttpGet("GetEntryWiseWorKshopList")]
        public async Task<IActionResult> GetEntryWiseWorKshopList(string ParticularName, string Date)
        {

            return Ok(await _repo.GetEntryWiseWorKshopList(UserHelper.GetUser(User), ParticularName, Date));
        }
        #endregion
    }
}
