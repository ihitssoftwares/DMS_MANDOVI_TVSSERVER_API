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
    public class ShowroomRentController : ControllerBase
    {

        #region Private properties
        private readonly IShowroomRentRepository _repo;
        #endregion
        #region Constructor        
        public ShowroomRentController(IShowroomRentRepository repo)
        {
            _repo = repo;
        }

        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Region, int WorkhoporShowroom)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Region, WorkhoporShowroom));
        }


        [HttpPost("RentUpdate")]
        public async Task<IActionResult> RentUpdate(ShowroomRent model)
        {
            return Ok(await _repo.RentUpdate(UserHelper.GetUser(User), model));
        }


    }
}
