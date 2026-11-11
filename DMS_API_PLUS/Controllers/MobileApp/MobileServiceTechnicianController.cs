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
    public class MobileServiceTechnicianController : Controller
    {
        #region Private properties
        private readonly IMobileServiceTechnicianRepository _repo;
        #endregion
        #region Constructor        
        public MobileServiceTechnicianController(IMobileServiceTechnicianRepository repo)
        {
            _repo = repo;
        }
        #endregion


        [HttpPost("GetServiceTechnicianSave")]
        public async Task<IActionResult> GetServiceTechnicianSave(MobileServiceTechnician model)
        {
            return Ok(await _repo.GetServiceTechnicianSave(UserHelper.GetUser(User), model));
        }
    }
}
