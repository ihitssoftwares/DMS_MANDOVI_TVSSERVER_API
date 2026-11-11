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
    public class TechnicianInOutSaveController : Controller
    {
        #region Private properties
        private readonly ITechnicianInOutSaveRepository _repo;
        #endregion
        #region Constructor        
        public TechnicianInOutSaveController(ITechnicianInOutSaveRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpPost("GetTechnicianInOutSave")]
        public async Task<IActionResult> GetTechnicianInOutSave(TechnicianInOutSave model,string Mode)
        {
            return Ok(await _repo.GetTechnicianInOutSave(UserHelper.GetUser(User), model,Mode));
        }
    }
}
