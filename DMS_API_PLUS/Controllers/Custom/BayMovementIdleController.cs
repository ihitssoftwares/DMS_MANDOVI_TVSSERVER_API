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
    public class BayMovementIdleController : ControllerBase
    {
        #region Private properties
        private readonly IBayMovementIdleRepository _repo;
        #endregion
        #region Constructor        
        public BayMovementIdleController(IBayMovementIdleRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int WorkShop)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), WorkShop));
        }

        #endregion
    }
}
