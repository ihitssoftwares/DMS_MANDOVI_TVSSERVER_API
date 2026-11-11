using Cloud_Custom.Api.Repository.IRepository.Account;
using Cloud_Custom.Api.Shared.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Private properties
        private readonly IUserRepository _repo;
        #endregion
        #region Constructor        
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region GET
        [HttpGet("GetUserList")]
        public async Task<IActionResult> GetUserList(string Tabindex)
        {
            return Ok(await _repo.GetUserList(UserHelper.GetUser(User), Tabindex));

        }
        //[HttpPost("GetUserList_Excel")]
        //public async Task<IActionResult> GetUserList_Excel(string Tabindex)
        //{
        //    return Ok(await _repo.GetUserList_Excel(UserHelper.GetUser(User), Tabindex));

        //}
        [HttpGet("GetApplicableMenus")]
        public async Task<IActionResult> GetApplicableMenus(int UserRoleCode)
        {
            return Ok(await _repo.GetApplicableMenus(UserHelper.GetUser(User), UserRoleCode));

        }
        [HttpGet("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails(Guid UserMasterGI, Guid LogGI, string Type)
        {
            return Ok(await _repo.GetUserDetails(UserHelper.GetUser(User), UserMasterGI, LogGI, Type));
        }
        #endregion
        #region POST
        [HttpPost("UserSave")]
        public async Task<IActionResult> UserSave(User model)
        {
            model.UserBase = UserHelper.GetUser(User);
         
            return Ok(await _repo.UserSave(model));
        }
        //[HttpPost("ApproveOrReject")]
        //public async Task<IActionResult> ApproveOrReject(User model)
        //{
        //    model.UserBase = UserHelper.GetUser(User);
        //    return Ok(await _repo.UserApproveOrReject(model));
        //}
        #endregion
        #region Delete
        [HttpDelete("{UserMasterGI}")]

        public async Task<IActionResult> Delete(Guid UserMasterGI)
        {
            User model = new User();
            model.UserMasterGI = UserMasterGI;
            model.UserBase = UserHelper.GetUser(User);
            return Ok(await _repo.UserDelete(model));
        }
        #endregion
    }
}
