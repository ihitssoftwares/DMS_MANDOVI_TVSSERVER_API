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
    public class WorkShopController : ControllerBase
    {
        #region Private properties
        private readonly IWorkShopRepository _repo;
        #endregion
        #region Constructor        
        public WorkShopController(IWorkShopRepository repo)
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
        #endregion
        [HttpPost("AddNewWorkShop")]
        public async Task<IActionResult> AddNewWorkShop(WorkShop input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetWorkShopDetails")]
        public async Task<IActionResult> GetWorkShopDetails(int WorkShopCode, string mode)
        {
            return Ok(await _repo.GetWorkShopDetails(UserHelper.GetUser(User), WorkShopCode, mode));
        }
        [HttpPost("DeleteWorkShop")]
        public async Task<IActionResult> DeleteWorkShop(WorkShop model)
        {

            return Ok(await _repo.DeleteWorkShop(UserHelper.GetUser(User), model));
        }

    }
}
