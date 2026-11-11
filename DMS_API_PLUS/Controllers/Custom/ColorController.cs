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
    public class ColorController : Controller
    {
        #region Private properties
        private readonly IColorRepository _repo;
        #endregion
        #region Constructor        
        public ColorController(IColorRepository repo)
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
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Color model, string mode)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User),mode, model));
        }
        [HttpGet("GetColorDetails")]
        public async Task<IActionResult> GetColorDetails(int ColorCode, string mode, string Type)
        {
            return Ok(await _repo.GetColorDetails(UserHelper.GetUser(User), ColorCode, mode,Type));
        }
        [HttpPost("DeleteColor")]
        public async Task<IActionResult> DeleteColor(Color model)
        {

            return Ok(await _repo.DeleteColor(UserHelper.GetUser(User), model));
        }

        #endregion
    }
}
       
