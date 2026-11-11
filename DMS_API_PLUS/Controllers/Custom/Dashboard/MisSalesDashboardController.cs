using Cloud_Custom.Api.Repository.IRepository.Custom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.Custom.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class MisSalesDashboardController : ControllerBase
    {
        #region Private properties
        private readonly IMisSalesDashboardRepository _repo;
        #endregion
        #region Constructor        
        public MisSalesDashboardController(IMisSalesDashboardRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetTabDetails")]
        public async Task<IActionResult> GetTabDetails(int Month, string Fromdate, string ToDate, int Type, string Grid,int Region,int PageNo = 1, int PageSize = 10 )
        {
            return Ok(await _repo.GetTabDetails(UserHelper.GetUser(User), Month, Fromdate, ToDate,Type, Grid,Region, PageNo, PageSize));
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month, string Fromdate, string ToDate, int Type, string Grid,int Region)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, Fromdate, ToDate, Type,Grid, Region));
        }
            [HttpGet("GetInventoryList")]
        public async Task<IActionResult> GetInventoryList(int Month, string Fromdate, string ToDate, int Type, string Grid,int Region, int PageNo = 1, int PageSize = 10)
        {
            return Ok(await _repo.GetInventoryList(UserHelper.GetUser(User), Month, Fromdate, ToDate, Type,Grid, Region, PageNo, PageSize));
        }

         [HttpGet("GetRetailTabDetails")]
        public async Task<IActionResult> GetRetailTabDetails(int Month, string Fromdate, string ToDate,int Region, int Type)
        {
            return Ok(await _repo.GetRetailTabDetails(UserHelper.GetUser(User), Month, Fromdate, ToDate, Region, Type));
        }
         [HttpGet("GetInventoryTabDetails")]
        public async Task<IActionResult> GetInventoryTabDetails(int Month, string Fromdate, string ToDate,int Region, int Type)
        {
            return Ok(await _repo.GetInventoryTabDetails(UserHelper.GetUser(User), Month, Fromdate, ToDate, Region, Type));
        }
         [HttpGet("GetInventoryBookingDetails")]
        public async Task<IActionResult> GetInventoryBookingDetails(int Model, int Variant, int Color,int Region)
        {
            return Ok(await _repo.GetInventoryBookingDetails(UserHelper.GetUser(User), Model, Variant, Color, Region));
        }

    }
}
