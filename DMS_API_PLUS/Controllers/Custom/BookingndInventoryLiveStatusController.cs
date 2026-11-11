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
    public class BookingndInventoryLiveStatusController : ControllerBase
    {
        #region Private properties
        private readonly IBookingndInventoryLiveStatusRepository _repo;
        #endregion
        #region Constructor        
        public BookingndInventoryLiveStatusController(IBookingndInventoryLiveStatusRepository repo)
        {
            _repo = repo;
        }

        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Type,int ModelCode,int RegionCode,int BranchCode)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),Type,ModelCode,RegionCode, BranchCode));
        }


        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(string Type, int ModelCode, int Variant, int Color,int Region,int Branch,int GroupBy)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User),Type, ModelCode,Variant,Color,Region, Branch, GroupBy));
        }
    }
}
