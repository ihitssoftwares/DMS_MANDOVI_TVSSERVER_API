using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.Custom
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly IUserRoleRepository _repo;
        public UserRoleController(IUserRoleRepository repo)
        {
            _repo = repo;
        }
        #region Get

        [HttpGet("GetUserRoleList")]
        public async Task<IActionResult> GetUserRoleList(string TabIndex)
        {
            return Ok(await _repo.GetUserRoleList(UserHelper.GetUser(User), TabIndex));
        }
        [HttpGet("GetUserRoleTabDetails")]
        public async Task<IActionResult> GetUserRoleTabDetails(Guid UserRoleGI)
        {
            return Ok(await _repo.GetUserRoleTabDetails(UserHelper.GetUser(User), UserRoleGI));
        }
        [HttpGet("GetUserRoleDetails")]
        public async Task<IActionResult> GetUserRoleDetails(Guid UserRoleGI, Guid LogGI, string Type)
        {
            return Ok(await _repo.GetUserRoleDetails(UserHelper.GetUser(User), UserRoleGI, LogGI, Type));
        }
        [HttpGet("GetApplicabilityDetails")]
        //public async Task<IActionResult> GetApplicabilityDetails([FromQuery(Name = "Code")] int[] Code, [FromQuery(Name = "Appl")] bool[] Appl, [FromQuery(Name = "Name")] string[] Name)
        public async Task<IActionResult> GetApplicabilityDetails(string data, int count, int Mcount, string mode)
        {
            Head input = new Head();
            input.Module = new FormPermissionArray();
            input.SubModule = new FormPermissionArray();
            dynamic da = JsonConvert.DeserializeObject(data);
            input.Mode = mode;
            input.LogGI = da.LogGI;
            input.GI = da.GI;
            input.EDITMODE = da.EDITMODE;
            if (mode == "Module")
            {
                input.Module.Code = new int[Mcount];
                input.Module.Applicable = new bool[Mcount];
                input.Module.Name = new string[Mcount];
                for (int i = 0; i < Mcount; i++)
                {
                    input.Module.Code[i] = da.Module.Code[i];
                    input.Module.Applicable[i] = da.Module.Applicable[i];
                    input.Module.Name[i] = da.Module.Name[i];
                }
            }
            else
            {
                input.SubModule.Code = new int[Mcount];
                for (int i = 0; i < Mcount; i++)
                {
                    input.SubModule.Code[i] = da.SubModule.Code[i];
                }
            }

            return Ok(await _repo.GetApplicabilityDetails(UserHelper.GetUser(User), input));
        }
        #endregion
        #region post
        [HttpPost("TabApplicability")]
        public async Task<IActionResult> TabApplicability(UserRole input)
        {
            input.User = UserHelper.GetUser(User);
            return Ok(await _repo.TabApplicabilitySave(input));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserRole input)
        {
            input.User = UserHelper.GetUser(User);
            return Ok(await _repo.UserRoleSave(input));
        }

        [HttpPost("ApproveOrReject")]
        public async Task<IActionResult> ApproveOrReject(UserRole model)
        {
            model.User = UserHelper.GetUser(User);
            return Ok(await _repo.UserRoleApproveOrReject(model));
        }

        #endregion
        #region Delete
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid UserRoleGI)
        {
            return Ok(await _repo.UserRoleDelete(UserHelper.GetUser(User), UserRoleGI));

        }
        #endregion
    }
}
