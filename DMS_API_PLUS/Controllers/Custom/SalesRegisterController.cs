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
    public class SalesRegisterController : ControllerBase
    {

        #region Private properties
        private readonly ISalesRegisterRepository _repo;
        #endregion
        #region Constructor        
        public SalesRegisterController(ISalesRegisterRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string FromDate, string ToDate, int Region, int Branch, int Model, int Executive,int Month)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), FromDate, ToDate, Region, Branch, Model, Executive,Month));
        }
    }
}
