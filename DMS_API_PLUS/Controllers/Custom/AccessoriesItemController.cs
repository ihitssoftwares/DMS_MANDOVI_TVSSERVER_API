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
    public class AccessoriesItemController : ControllerBase
    {

        #region Private properties
        private readonly IAccessoriesItemRepository _repo;
        #endregion
        #region Constructor        
        public AccessoriesItemController(IAccessoriesItemRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(string TabIndex)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User), TabIndex));
            
        }
        #endregion
        [HttpPost("AddNewAccessories")]
        public async Task<IActionResult> AddNewAccessories(AccessoriesItem input, string mode)
        {

            return Ok(await _repo.Save(UserHelper.GetUser(User), mode, input));
        }
        [HttpGet("GetAccessoriesDetails")]
        public async Task<IActionResult> GetAccessoriesDetails(int ItemCode, string mode, string Type)
        {
            return Ok(await _repo.GetAccessoriesDetails(UserHelper.GetUser(User), ItemCode, mode, Type));
        }
        [HttpPost("DeleteAccessories")]
        public async Task<IActionResult> DeleteAccessories(AccessoriesItem accessoriesItem)
        {

            return Ok(await _repo.DeleteAccessories(UserHelper.GetUser(User), accessoriesItem));
        }
    }
}
