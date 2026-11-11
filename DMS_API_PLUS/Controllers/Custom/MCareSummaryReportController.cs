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
    public class MCareSummaryReportController : ControllerBase
    {
        private readonly IMCareSummaryReportRepository _repo;

        public MCareSummaryReportController(IMCareSummaryReportRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string FromDate, string ToDate, int DivisionCode, int RegionCode, int BranchCode, int EmployeeCode, string SalesFilter,int Year)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), FromDate, ToDate, DivisionCode, RegionCode, BranchCode, EmployeeCode,SalesFilter,Year));
        }
      
    }
}
