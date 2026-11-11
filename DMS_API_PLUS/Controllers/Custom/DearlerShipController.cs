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
    public class DearlerShipController : ControllerBase
    {
        #region Private properties
        private readonly IDearlerShipRepository _repo;
        #endregion
        #region Constructor        
        public DearlerShipController(IDearlerShipRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),TabIndex));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(DearlerShip model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, model));
        }
        [HttpGet("GetDealershipDetails")]
        public async Task<IActionResult> GetDealershipDetails(int DealerCode, string mode, string Type)
        {
            return Ok(await _repo.GetDealershipDetails(UserHelper.GetUser(User), DealerCode, mode,Type));
        }
        [HttpPost("DearlerDelete")]
        public async Task<IActionResult> DearlerDelete(DearlerShip model)
        {
            return Ok(await _repo.DearlerDelete(UserHelper.GetUser(User), model));
        }
        #endregion
    }
}
