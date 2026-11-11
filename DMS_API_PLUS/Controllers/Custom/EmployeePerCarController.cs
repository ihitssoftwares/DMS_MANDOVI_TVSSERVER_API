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
    public class EmployeePerCarController : Controller
    {
      
        private readonly IEmployeePerCarRepository _repo;
   
          
        public EmployeePerCarController(IEmployeePerCarRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Month)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Month));
        }
    }

}