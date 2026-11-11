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
    public class JobCardDetailsAIController : ControllerBase
    {
        private readonly IJobCardDetailsAIRepository _repo;
        public JobCardDetailsAIController(IJobCardDetailsAIRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("JobCardDetailsExtractedList")]
        public async Task<IActionResult> JobCardDetailsExtractedList()
        {

            return Ok(await _repo.JobCardDetailsExtractedList(UserHelper.GetUser(User)));
        }
        [HttpPost("JobCardPhotoSave")]
        public async Task<IActionResult>JobCardPhotoSave([FromForm]  JobCardPhotoAI model)
        {
            return Ok(await _repo.JobCardPhotoSave(UserHelper.GetUser(User),model));
        }
    }
}
