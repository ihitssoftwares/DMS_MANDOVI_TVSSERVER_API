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
    public class WorkshopManagerBayOccupencyController : Controller
    {
        #region Private properties
        private readonly IWorkshopManagerBayOccupencyRepository _repo;
        #endregion
        #region Constructor        
        public WorkshopManagerBayOccupencyController(IWorkshopManagerBayOccupencyRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }
    }
}
