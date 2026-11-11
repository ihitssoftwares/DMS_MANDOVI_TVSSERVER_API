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
    public class PriceDetailsController : Controller
    {
        #region Private properties
        private readonly IPriceDetailsRepository _repo;
        #endregion
        #region Constructor        
        public PriceDetailsController(IPriceDetailsRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(int Type, string Fromdate, string ToDate)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),Type,Fromdate,ToDate));
        }
        
        #endregion
        
        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetVarientDetails(int PriceId)
        {
            return Ok(await _repo.GetVarientDetails(UserHelper.GetUser(User), PriceId));
        }
    }
}
