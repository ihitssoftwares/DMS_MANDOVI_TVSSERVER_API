using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
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
    public class CustomerController : Controller
    {
        #region Private properties
        private readonly ICustomerRepository _repo;
        #endregion
        #region Constructor        
        public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpPost("List")]
        public async Task<IActionResult> List(Filter filter)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), filter));
        }
        #endregion
        [HttpPost("AddNewCustomer")]
        public async Task<IActionResult> AddNewCustomer(Customer input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetCustomerDetails")]
        public async Task<IActionResult> GetCustomerDetails(int CustomerCode, string mode)
        {
            return Ok(await _repo.GetCustomerDetails(UserHelper.GetUser(User), CustomerCode, mode));
        }
        [HttpPost("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(Customer model)
        {

            return Ok(await _repo.DeleteCustomer(UserHelper.GetUser(User), model));
        }

        [HttpPost("CustomerImportFromExcel")]
        public async Task<IActionResult> CustomerImportFromExcel(Customer model)
        {
            return Ok(await _repo.CustomerImportFromExcel(UserHelper.GetUser(User), model));
        }
    }
}
