using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.Custom
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderRegisterController : ControllerBase
    {

        #region Private properties
        private readonly IOrderRegisterRepository _repo;
        #endregion
        #region Constructor        
        public OrderRegisterController(IOrderRegisterRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string DateFilterType, string FromDate, string ToDate,string Status)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User),DateFilterType,FromDate, ToDate, Status));
        }

        [HttpGet("GetOrderBookingDetails")]
        public async Task<IActionResult> GetOrderBookingDetails(int OrderTrnCode, string OrderNo)
        {
            return Ok(await _repo.GetOrderBookingDetails(UserHelper.GetUser(User),OrderTrnCode,OrderNo));
        }

    }
}
