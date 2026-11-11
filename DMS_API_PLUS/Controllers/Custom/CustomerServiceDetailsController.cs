using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
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
    public class CustomerServiceDetailsController : Controller
    {
        #region Private properties
        private readonly ICustomerServiceDetailsRepository _repo;
        #endregion
        #region Constructor        
        public CustomerServiceDetailsController(ICustomerServiceDetailsRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User)));
        }
        #endregion
        [HttpPost("Save")]
        public async Task<IActionResult> Save(CustomerServiceDetails input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetPopupDetails")]
        public async Task<IActionResult> GetPopupDetails(int CustomerCode)
        {
            return Ok(await _repo.GetCustomerDetails(UserHelper.GetUser(User), CustomerCode));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(CustomerServiceDetails model)
        {

            return Ok(await _repo.Delete(UserHelper.GetUser(User), model));
        }
    }
}
