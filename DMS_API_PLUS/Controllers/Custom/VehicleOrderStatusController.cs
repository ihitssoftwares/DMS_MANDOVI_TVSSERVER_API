using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class VehicleOrderStatusController : Controller
    {
        #region Private properties
        private readonly IVehicleOrderStatusRepository _repo;
        #endregion
        #region Constructor        
        public VehicleOrderStatusController(IVehicleOrderStatusRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult>List(string Fromdate, string ToDate)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Fromdate,ToDate));
        }
        [HttpGet("Create")]
        public async Task<IActionResult> Create(int RegistrationCode, int OrdertrnCode)
        {
            return Ok(await _repo.Create(UserHelper.GetUser(User), RegistrationCode, OrdertrnCode));
        }
        #endregion
    }
}
