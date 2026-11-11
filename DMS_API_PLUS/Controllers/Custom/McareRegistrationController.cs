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
    public class McareRegistrationController : Controller
    {
        #region Private properties
        private readonly IMcareRegistrationRepository _repo;
        #endregion
        #region Constructor        
        public McareRegistrationController(IMcareRegistrationRepository repo)
        {
            _repo = repo;
        }

        #endregion
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int AppoinmentStatus)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), AppoinmentStatus));
        }

        [HttpGet("GetSearchList")]
        public async Task<IActionResult> GetSearchList(string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo, string VinNo)
        {
            return Ok(await _repo.GetSearchList(UserHelper.GetUser(User), SearchCustomerName, SearchCustomerRegisterNo, SearchPhoneNo, VinNo));
        }



        [HttpGet("GetSearchDetails")]
        public async Task<IActionResult> GetSearchDetails(string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo, string VinNo)
        {
            return Ok(await _repo.GetSearchDetails(UserHelper.GetUser(User), SearchCustomerName, SearchCustomerRegisterNo, SearchPhoneNo, VinNo));
        }
        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(string SearchCustomerRegisterNo)
        {
            return Ok(await _repo.GetDetails(UserHelper.GetUser(User), SearchCustomerRegisterNo));
        }

        [HttpPost("Save")]
        public async Task<IActionResult> NewRequestSave(McareRegistration model)
        {
            //model.User = UserHelper.GetUser(User);
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }

        [HttpGet("GetPlanAmount")]
        public async Task<IActionResult> GetPlanAmount(int id, int VechicleModel, string FromDate)
        {
            //model.User = UserHelper.GetUser(User);
            return Ok(await _repo.GetPlanAmount(UserHelper.GetUser(User), id,VechicleModel, FromDate));
        }

    }
}
