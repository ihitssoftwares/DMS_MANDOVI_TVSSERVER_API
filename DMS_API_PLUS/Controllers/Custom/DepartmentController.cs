using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Microsoft.AspNetCore.Http;
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
    public class DepartmentController : ControllerBase
    {
        #region Private properties
        private readonly IDepartmentRepository _repo;
        #endregion
        #region Constructor        
        public DepartmentController(IDepartmentRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),TabIndex));
        }
        #endregion
        [HttpPost("AddNewDepartment")]
        public async Task<IActionResult> AddNewDepartment(Department input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetDepartmentDetails")]
        public async Task<IActionResult> GetDepartmentDetails(int DepartmentCode, string mode, string Type)
        {
            return Ok(await _repo.GetDepartmentDetails(UserHelper.GetUser(User), DepartmentCode, mode, Type));
        }
        [HttpPost("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(Department model)
        {

            return Ok(await _repo.DeleteDepartment(UserHelper.GetUser(User), model));
        }
    }
}
