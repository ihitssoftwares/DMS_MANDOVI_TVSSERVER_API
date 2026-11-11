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
    public class WorkShopManagerJobStatusController : Controller
    {
        #region Private properties
        private readonly IWorkShopManagerJobStatusRepository _repo;
        #endregion
        #region Constructor        
        public WorkShopManagerJobStatusController(IWorkShopManagerJobStatusRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string Type)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), Type));
        }
    }
}
