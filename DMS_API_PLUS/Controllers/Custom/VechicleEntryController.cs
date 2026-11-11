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
    public class VechicleEntryController : Controller
    {
        #region Private properties
        private readonly IVechicleEntryRepository _repo;
        #endregion
        #region Constructor        
        public VechicleEntryController(IVechicleEntryRepository repo)
        {
            _repo = repo;
        }
        #endregion
        [HttpPost("Save")]
        public async Task<IActionResult> NewRequestSave(VechicleEntry model)
        {
            //model.User = UserHelper.GetUser(User);
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
