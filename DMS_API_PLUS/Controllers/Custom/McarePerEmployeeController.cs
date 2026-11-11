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
    public class McarePerEmployeeController : Controller
    {
        private readonly IMcarePerEmployeeRepositroy _repo;

        public McarePerEmployeeController(IMcarePerEmployeeRepositroy repo)
        {
            _repo = repo;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string FromDate, string ToDate, int DivisionCode, int RegionCode, int BranchCode, int EmployeeCode, int Year)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), FromDate, ToDate, DivisionCode, RegionCode, BranchCode, EmployeeCode, Year));
        }
        [HttpGet("GetEmployeeDetail")]
        public async Task<IActionResult> GetEmployeeDetail(int EmployeeCode)
        {
            return Ok(await _repo.GetEmployeeDetail(UserHelper.GetUser(User), EmployeeCode));
        }
    }
}
