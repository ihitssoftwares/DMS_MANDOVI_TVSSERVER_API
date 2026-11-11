using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Shared.Custom;
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
    public class CarModelController : ControllerBase
    {
        #region Private properties
        private readonly ICarModelRepository _repo;
        #endregion
        #region Constructor        
        public CarModelController(ICarModelRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("List")]
        public async Task<IActionResult> List(String Type, string TabIndex, int DisModel,string ModelGrp)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),Type, TabIndex, DisModel, ModelGrp));
        }
        #endregion
        [HttpPost("AddNewModel")]
        public async Task<IActionResult> AddNewModel(CarModel input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetModelDetails")]
        public async Task<IActionResult> GetModelDetails(int ModelCode, string mode, string Type)
        {
            return Ok(await _repo.GetModelDetails(UserHelper.GetUser(User), ModelCode, mode, Type));
        }
        [HttpPost("DeleteModel")]
        public async Task<IActionResult> DeleteModel(CarModel model)
        {

            return Ok(await _repo.DeleteModel(UserHelper.GetUser(User), model));
        }
    }
}
