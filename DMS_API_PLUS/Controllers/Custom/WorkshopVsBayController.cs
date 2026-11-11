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
    public class WorkshopVsBayController : ControllerBase
    {
        #region Private properties
        private readonly IWorkshopVsBayRepository _repo;
        #endregion
        #region Constructor        
        public WorkshopVsBayController(IWorkshopVsBayRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("Getlist")]
        public async Task<IActionResult> Getlist()
        {

            return Ok(await _repo.Getlist(UserHelper.GetUser(User)));
        }
        #endregion

        #region Get

        [HttpGet("GetBayDetails")]
        public async Task<IActionResult> GetBayDetails(int BranchCode)
        {
            return Ok(await _repo.GetBayDetails(UserHelper.GetUser(User), BranchCode));
        }
        #endregion

        [HttpPost("Save")]
        public async Task<IActionResult> Save(WorkshopVsBay model, int WorkShopCode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), WorkShopCode,model));
        }
    }


}

