using Cloud_Custom.Api.Repository.IRepository.Custom;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.Custom
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPerformanceReportController : ControllerBase
    {
        private readonly ISalesPerformanceReportRepository _repo;

        public SalesPerformanceReportController(ISalesPerformanceReportRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int MonthCode)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), MonthCode));
        }
    }
}