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
    public class LabourVsMcareServiceController : ControllerBase
    {

        #region Private properties
        private readonly ILabourVsMcareServiceRepository _repo;
        #endregion
        #region Constructor        
        public LabourVsMcareServiceController(ILabourVsMcareServiceRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int isAssigned)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }
        #endregion

        //#region Get
        //[HttpGet("GetPopupDetails")]
        //public async Task<IActionResult> GetPopupDetails()
        //{

        //    return Ok(await _repo.GetPopupDetails(UserHelper.GetUser(User)));
        //}
        //#endregion

        [HttpPost("PopupSave")]
        public async Task<IActionResult> PopupSave(LabourVsMcareService model)
        {

            return Ok(await _repo.PopupSave(UserHelper.GetUser(User), model));
        }
    }
}
