using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DMS_API_PLUS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        #region Private properties
        private readonly IRegistrationRepository _repo;
        #endregion
        #region Constructor        
        public RegistrationController(IRegistrationRepository repo)
        {
            _repo = repo;
        }

        #endregion



        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }

        [HttpGet("GetOrderDetails")]
        public async Task<IActionResult> GetOrderDetails(int OrderTrnCode)
        {
            return Ok(await _repo.GetOrderDetails(UserHelper.GetUser(User), OrderTrnCode));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(Registration model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
    }
}
