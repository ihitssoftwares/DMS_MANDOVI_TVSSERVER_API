using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.Mobile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.MobileApp
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MobileSalesDashboardController : Controller
    {
        #region Private properties
        private readonly IMobileSalesDashboardRepository _repo;
        #endregion
        #region Constructor        
        public MobileSalesDashboardController(IMobileSalesDashboardRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int UserCode)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), UserCode));
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int UserCode,string Type)
        {

            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), UserCode,Type));
        }

        [HttpGet("GetTargetAchievement")]
        public async Task<IActionResult> GetTargetAchievement(int UserCode, int MonthCode)
        {

            return Ok(await _repo.GetTargetAchievement(UserHelper.GetUser(User), UserCode, MonthCode));
        }


        [HttpGet("GetDetailsTL")]
        public async Task<IActionResult> GetDetailsTL(int UserCode, string Type)
        {

            return Ok(await _repo.GetDetailsTL(UserHelper.GetUser(User), UserCode, Type));
        }

    }
}
