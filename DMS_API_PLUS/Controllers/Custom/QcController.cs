using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
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
    public class QcController : ControllerBase
    {
        #region Private properties
        private readonly IQcRepository _repo;
        #endregion
        #region Constructor        
        public QcController(IQcRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpPost("GetList")]
        public async Task<IActionResult> GetList(Filter filter,int Region,int Branch)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), filter,Region,Branch));
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int SalesVehicleCode)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), SalesVehicleCode));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(Qc model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
