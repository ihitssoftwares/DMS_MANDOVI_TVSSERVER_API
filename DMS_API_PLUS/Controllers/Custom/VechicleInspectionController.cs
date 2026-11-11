using Cloud_Custom.Api.Repository.IRepository.Custom;
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
    public class VechicleInspectionController : Controller
    {
        #region Private properties
        private readonly IVechicleInspectionRepository _repo;
        #endregion
        #region Constructor        
        public VechicleInspectionController(IVechicleInspectionRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }


        [HttpGet("GetInspectionList")]
        public async Task<IActionResult> GetInspectionList(int HDcode)
        {
            return Ok(await _repo.GetInspectionList(UserHelper.GetUser(User),HDcode));
        }

    }
}
