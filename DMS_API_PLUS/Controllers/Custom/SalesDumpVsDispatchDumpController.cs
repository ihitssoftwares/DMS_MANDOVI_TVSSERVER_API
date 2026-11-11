using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Microsoft.AspNetCore.Authorization;
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
    public class SalesDumpVsDispatchDumpController : ControllerBase
    {
        #region Private properties
        private readonly ISalesDumpVsDispatchDumpRepository _repo;
        #endregion

        #region Constructor
        public SalesDumpVsDispatchDumpController(ISalesDumpVsDispatchDumpRepository repo)
        {
            _repo = repo;
        }
        #endregion

        

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList(Filter filter, int Month, int Status, int Branch)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), filter, Month, Status, Branch));
        }

    }
}
