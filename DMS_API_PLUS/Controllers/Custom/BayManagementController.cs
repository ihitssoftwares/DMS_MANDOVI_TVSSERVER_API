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
    public class BayManagementController : ControllerBase
    {
        #region Private properties
        private readonly IBayManagementRepository _repo;
        #endregion
        #region Constructor        
        public BayManagementController(IBayManagementRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List( int WorkShopCode)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), WorkShopCode));
        }
        [HttpGet("GetBayDetails")]
        public async Task<IActionResult> GetBayDetails(int JobCardCode, int customerCode, int WorkShopCode)
        {
            return Ok(await _repo.GetBayDetails(UserHelper.GetUser(User), JobCardCode, customerCode, WorkShopCode));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(BayManagement model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
        #endregion
    }
}
