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
    public class OrderUpdateController : ControllerBase
    {

        #region Private properties
        private readonly IOrderUpdateRepository _repo;
        #endregion
        #region Constructor        
        public OrderUpdateController(IOrderUpdateRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month));
        }

        [HttpGet("GetOrderBookingDetails")]
        public async Task<IActionResult> GetOrderBookingDetails(int OrderTrnCode, string OrderNo)
        {
            return Ok(await _repo.GetOrderBookingDetails(UserHelper.GetUser(User), OrderTrnCode, OrderNo));
        }

        [HttpPost("OrderBookingUpdate")]
        public async Task<IActionResult> OrderBookingUpdate(OrderBooking model)
        {
            return Ok(await _repo.OrderBookingUpdate(UserHelper.GetUser(User), model));
        }
 
        [HttpGet("GetRatePerItem")]
        public async Task<IActionResult> GetRatePerItem(int ItemCode)
        {
            return Ok(await _repo.GetRatePerItem(UserHelper.GetUser(User), ItemCode));
        }

    }
}
