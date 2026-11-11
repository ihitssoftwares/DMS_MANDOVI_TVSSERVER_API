using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cloud_Custom.Api.Repository.IRepository.General;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMPLE_API_PLUS.Controllers.General
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        #region Private properties
        private readonly IMenuRepository _repo;
        #endregion
        #region Constructor        
        public MenuController(IMenuRepository repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet("GetCustomMenu")]
        public async Task<IActionResult> GetCustomMenu()
        {
            return Ok(await _repo.GetCustomMenu(UserHelper.GetUser(User)));
        }
        [HttpGet("GetMenuDetails")]
        public async Task<IActionResult> GetMenuDetails(int MenuCode)
        {
            return Ok(await _repo.GetMenuDetails(UserHelper.GetUser(User), MenuCode));
        }

        [HttpGet("GetModuleList")]
        public async Task<IActionResult> GetModuleList(string LoginFrom)
        {
            return Ok(await _repo.GetModuleList(UserHelper.GetUser(User), LoginFrom));
        }

        [HttpGet("GetModuleVsMenuList")]
        public async Task<IActionResult> GetModuleVsMenuList(int ModuleCode)
        {
            return Ok(await _repo.GetModuleVsMenuList(UserHelper.GetUser(User), ModuleCode));
        }
    }
}
