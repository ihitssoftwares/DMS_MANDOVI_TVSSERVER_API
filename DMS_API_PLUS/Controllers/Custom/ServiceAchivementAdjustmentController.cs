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
    public class ServiceAchivementAdjustmentController : Controller
    {
        #region Private properties
        private readonly IServiceAchivementAdjustmentRepository _repo;
        #endregion
        #region Constructor        
        public ServiceAchivementAdjustmentController(IServiceAchivementAdjustmentRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetList")]
        public async Task<IActionResult> List(int Month, int IncentiveGroup, int BranchCode, int Parameter)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month, IncentiveGroup, BranchCode, Parameter));
        }

      
        [HttpPost("SettingsSave")]
        public async Task<IActionResult> SettingsSave(ServiceAchivementAdjustment model, int ParameterCode, int IncentiveGroupCode, int monthcode, int Employecode, decimal ActualValue)
        {
            //model.User = UserHelper.GetUser(User);
            return Ok(await _repo.SettingsSave(UserHelper.GetUser(User), model,ParameterCode,IncentiveGroupCode, monthcode, Employecode,ActualValue));
        }

       

       


        
    }
}
