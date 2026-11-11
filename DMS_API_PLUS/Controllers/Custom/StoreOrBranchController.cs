using Cloud_Custom.Api.Repository.Repository.Custom;
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
    public class StoreOrBranchController : ControllerBase
    {
        #region Private properties
        private readonly IStoreOrBranchRepository _repo;
        #endregion
        #region Constructor        
        public StoreOrBranchController(IStoreOrBranchRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(int Type,int Region, int Workshoponly)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Type, Region, Workshoponly));
        }
        [HttpPost("AddnewBranch")]
        public async Task<IActionResult> AddnewBranch(StoreOrBranch input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetStoreOrBranchDetails")]
        public async Task<IActionResult> GetBranchDetails(int BranchCode, string mode)
        {
            return Ok(await _repo.GetBranchDetails(UserHelper.GetUser(User), BranchCode, mode));
        }

        [HttpPost("DeleteBranch")]
        public async Task<IActionResult> DeleteBranch(StoreOrBranch model)
        {

            return Ok(await _repo.DeleteBranch(UserHelper.GetUser(User), model));
        }
        #endregion





        [HttpPost("PopupSave")]
        public async Task<IActionResult> PopupSave(StoreOrBranch model)
        {

            return Ok(await _repo.PopupSave(UserHelper.GetUser(User), model));
        }

        #region Get
        [HttpGet("GetPopupList")]
        public async Task<IActionResult> GetPopupList(int BranchCode)
        {

            return Ok(await _repo.GetPopupList(UserHelper.GetUser(User), BranchCode));
        }
        #endregion


        [HttpGet("DeletePopup")]
        public async Task<IActionResult> DeletePopup(int BranchCode, int DtCode)
        {

            return Ok(await _repo.DeletePopup(UserHelper.GetUser(User), BranchCode, DtCode));
        }
    }
}
