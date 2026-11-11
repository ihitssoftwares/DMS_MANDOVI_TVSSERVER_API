using Cloud_Custom.Api.Repository.IRepository;
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
    public class ServiceAgeingSummeryController : ControllerBase
    {
        #region Private properties
        private readonly IServiceAgeingSummeryRepository _repo;
        #endregion
        #region Constructor        
        public ServiceAgeingSummeryController(IServiceAgeingSummeryRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult>GetList(int Age)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),Age));
        }

        #endregion
    }
}
