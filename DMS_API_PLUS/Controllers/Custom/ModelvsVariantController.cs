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
    public class ModelvsVariantController : Controller
    {
        private readonly IModelvsVariantRepository _repo;


        public ModelvsVariantController(IModelvsVariantRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int Modeldr)
        {
            return Ok(await _repo.GetList(UserHelper.GetUser(User), Modeldr));
        }
        [HttpGet("GetPopUpDetails")]
        public async Task<IActionResult> GetPopUpDetails()
        {
            return Ok(await _repo.GetPopUpDetails(UserHelper.GetUser(User)));
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(ModelvsVariant model)
        {
            return Ok(await _repo.Save(UserHelper.GetUser(User), model));
        }
        [HttpGet("Getdetails")]
        public async Task<IActionResult> Getdetails( int HDCode,int ColorCode)
        {
            return Ok(await _repo.Getdetails(UserHelper.GetUser(User), HDCode, ColorCode));
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(ModelvsVariant model)
        {
            return Ok(await _repo.Edit(UserHelper.GetUser(User), model));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(ModelvsVariant model)
        {
            return Ok(await _repo.Delete(UserHelper.GetUser(User), model));
        }
    }
}
