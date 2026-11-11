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
    public class OrderBookingUploadController : ControllerBase
    {

        #region Private properties
        private readonly IOrderBookingUploadRepository _repo;
        #endregion
        #region Constructor        
        public OrderBookingUploadController(IOrderBookingUploadRepository repo)
        {
            _repo = repo;
        }

        #endregion

        [HttpPost("OrderImportFromExcel")]
        public async Task<IActionResult> OrderImportFromExcel(OrderBookingUpload model)
        {
            return Ok(await _repo.OrderImportFromExcel(UserHelper.GetUser(User), model));
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month));
        }

    }
}
