using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class VariantController : Controller
    {
        #region Private properties
        private readonly IVariantRepository _repo;
        #endregion
        #region Constructor        
        public VariantController(IVariantRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), TabIndex));
        }
        #endregion
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Variant model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, model));
        }
        [HttpGet("GetVarientDetails")]
        public async Task<IActionResult> GetVarientDetails(int VariantCode, string mode, string Type)
        {
            return Ok(await _repo.GetVarientDetails(UserHelper.GetUser(User), VariantCode, mode,Type));
        }
        [HttpPost("VariantDelete")]
        public async Task<IActionResult> VariantDelete(Variant model)
        {
            return Ok(await _repo.VariantDelete(UserHelper.GetUser(User),model));
        }
    }
}
       

