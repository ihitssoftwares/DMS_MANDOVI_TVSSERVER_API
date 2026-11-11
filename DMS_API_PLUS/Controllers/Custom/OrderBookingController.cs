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
    public class OrderBookingController : ControllerBase
    {

        #region Private properties
        private readonly IOrderBookingRepository _repo;
        #endregion
        #region Constructor        
        public OrderBookingController(IOrderBookingRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month));
        }

        [HttpGet("GetLeadEnquiryDetails")]
        public async Task<IActionResult> GetLeadEnquiryDetails(int EnqCode, string LeadNo)
        {
            return Ok(await _repo.GetLeadEnquiryDetails(UserHelper.GetUser(User), EnqCode, LeadNo));
        }

        [HttpPost("OrderBooking")]
        public async Task<IActionResult> OrderBooking(OrderBooking model)
        {
            return Ok(await _repo.OrderBooking(UserHelper.GetUser(User), model));
        }
        [HttpGet("GetExShowroomPrice")]
        public async Task<IActionResult> GetExShowroomPrice(int Model, int Variant, int Color, string FuelType, string Transmission, string OrderDate)
        {
            return Ok(await _repo.GetExShowroomPrice(UserHelper.GetUser(User), Model, Variant, Color, FuelType, Transmission, OrderDate));
        }
    }
}
