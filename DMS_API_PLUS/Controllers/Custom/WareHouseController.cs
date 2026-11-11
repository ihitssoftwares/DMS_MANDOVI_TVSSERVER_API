using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class WareHouseController : Controller
    {
        #region Private properties
        private readonly IWareHouseRepository _repo;
        #endregion
        #region Constructor        
        public WareHouseController(IWareHouseRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), TabIndex));
        }
        #endregion
        [HttpPost("AddNewWareHouse")]
        public async Task<IActionResult> AddNewWareHouse(WareHouse input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetWareHouseDetails")]
        public async Task<IActionResult> GetWareHouseDetails(int WarehouseCode, string mode, string Type)
        {
            return Ok(await _repo.GetWareHouseDetails(UserHelper.GetUser(User), WarehouseCode, mode, Type));
        }
        [HttpPost("DeleteWareHouse")]
        public async Task<IActionResult> DeleteModel(WareHouse model)
        {

            return Ok(await _repo.DeleteWareHouse(UserHelper.GetUser(User), model));
        }
    }
}
