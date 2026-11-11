using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class ServicePartsController : ControllerBase
    {
        #region Private properties
        private readonly IServicePartsRepository _repo;
        #endregion
        #region Constructor        
        public ServicePartsController(IServicePartsRepository repo)
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
        //[HttpPost("AddNewWareHouse")]
        //public async Task<IActionResult> AddNewWareHouse(WareHouse input, string mode)
        //{

        //    return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        //}
        //[HttpGet("GetWareHouseDetails")]
        //public async Task<IActionResult> GetWareHouseDetails(int WarehouseCode, string mode, string Type)
        //{
        //    return Ok(await _repo.GetWareHouseDetails(UserHelper.GetUser(User), WarehouseCode, mode, Type));
        //}
        //[HttpPost("DeleteWareHouse")]
        //public async Task<IActionResult> DeleteModel(WareHouse model)
        //{

        //    return Ok(await _repo.DeleteWareHouse(UserHelper.GetUser(User), model));
        //}
    }
}
