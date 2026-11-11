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
    public class LoadDataUpdateController : Controller
    {
        #region Private properties
        private readonly ILoadDataUpdateRepository _repo;
        #endregion
        #region Constructor        
        public LoadDataUpdateController(ILoadDataUpdateRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), TabIndex));
        }
        [HttpGet("GetTabList")]
        public async Task<IActionResult> GetTabList(string TabIndex)
        {

            return Ok(await _repo.GetTabList(UserHelper.GetUser(User), TabIndex));
        }


        [HttpPost("SettingsSave")]
        public async Task<IActionResult> SettingsSave(LoadDataUpdate model, int VechicleModel)
        {
            //model.User = UserHelper.GetUser(User);
            return Ok(await _repo.SettingsSave(UserHelper.GetUser(User), model, VechicleModel));
        }

        [HttpGet("SavePopup")]
        public async Task<IActionResult> Save(int BranchCode, string Name, int EmployeeCode, string Tabindex,int Technicianemployee)
        {
            //model.User = UserHelper.GetUser(User);
            return Ok(await _repo.SavePopup(UserHelper.GetUser(User), BranchCode,Name, EmployeeCode,Tabindex, Technicianemployee));
        }

    }
}
