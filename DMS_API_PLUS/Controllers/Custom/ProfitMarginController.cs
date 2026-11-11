using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class ProfitMarginController : Controller
    {
        #region Private properties
        private readonly IProfitMarginRepository _repo;
        #endregion
        #region Constructor        
        public ProfitMarginController(IProfitMarginRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int VechicleModel)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), VechicleModel));
        }
        [HttpGet("GetTabList")]
        public async Task<IActionResult> GetTabList(string TabIndex)
        {

            return Ok(await _repo.GetTabList(UserHelper.GetUser(User), TabIndex));
        }


        [HttpPost("SettingsSave")]
        public async Task<IActionResult> SettingsSave(ProfitMargin model, int VechicleModel)
        {
            //model.User = UserHelper.GetUser(User);
            return Ok(await _repo.SettingsSave(UserHelper.GetUser(User), model, VechicleModel));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(ProfitMargin model, string TabIndex)
        {
            //model.User = UserHelper.GetUser(User);
            return Ok(await _repo.Save(UserHelper.GetUser(User), model, TabIndex));
        }

    }
}
