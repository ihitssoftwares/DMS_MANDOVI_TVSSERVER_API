using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API_PLUS.Controllers.Custom
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        #region Private properties
        private readonly IServiceRepository _repo;
        #endregion
        #region Constructor        
        public ServiceController(IServiceRepository repo)
        {
            _repo = repo;
        }

        #endregion


        [HttpGet("GetBatteryList")]
        public async Task<IActionResult> GetBatteryList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetBatteryList(UserHelper.GetUser(User),Month,Type));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = ex.Message,
                    inner = ex.InnerException?.Message,
                    stack = ex.StackTrace
                });
            }
        }

    
        [HttpGet("GetCCpList")]
        public async Task<IActionResult> GetCCpList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetCCpList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        //// ---------------- EW ----------------
        [HttpGet("GetEWList")]
        public async Task<IActionResult> GetEWList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetEWList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        //// ---------------- LABOUR ----------------
        [HttpGet("GetLabourList")]
        public async Task<IActionResult> GetLabourList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetLabourList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        //// ---------------- LOAD ----------------
        [HttpGet("GetLoadList")]
        public async Task<IActionResult> GetLoadList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetLoadList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        //// ---------------- MCP ----------------
        [HttpGet("GetMCPList")]
        public async Task<IActionResult> GetMCPList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetMCPList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        //// ---------------- MGA ----------------
        [HttpGet("GetMGAList")]
        public async Task<IActionResult> GetMGAList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetMGAList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // ---------------- PMS20 ----------------
        [HttpGet("GetPMS20List")]
        public async Task<IActionResult> GetPMS20List(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetPMS20List(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // ---------------- PMS PARTS ----------------
        [HttpGet("GetPMSPartsList")]
        public async Task<IActionResult> GetPMSPartsList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetPMSPartsList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // ---------------- SPARES ----------------
        [HttpGet("GetSparesList")]
        public async Task<IActionResult> GetSparesList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetSparesList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // ---------------- SYNTHETIC OIL ----------------
        [HttpGet("GetSyntheticOilList")]
        public async Task<IActionResult> GetSyntheticOilList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetSyntheticOilList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // ---------------- TRUE VALUE ----------------
        [HttpGet("GetTrueValueList")]
        public async Task<IActionResult> GetTrueValueList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetTrueValueList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // ---------------- TYRE ----------------
        [HttpGet("GetTyreList")]
        public async Task<IActionResult> GetTyreList(int Month, int Type)
        {
            try
            {
                return Ok(await _repo.GetTyreList(UserHelper.GetUser(User), Month, Type));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // ---------------- COMMON ERROR HANDLER ----------------
        private IActionResult HandleException(Exception ex)
        {
            return StatusCode(500, new
            {
                error = ex.Message,
                inner = ex.InnerException?.Message,
                stack = ex.StackTrace
            });
        }



        //[HttpGet("GetLoadPopDetails")]
        //public async Task<IActionResult> GetLoadPopDetails(string Tab, string Name, int Code, int TypeCode, int Month)
        //{
        //    try
        //    {
        //        return Ok(await _repo.GetLoadPopDetails(UserHelper.GetUser(User), Tab, Name, Code, TypeCode, Month));
        //    }
        //    catch (Exception ex)
        //    {
        //        return HandleException(ex);
        //    }
        //}

        [HttpPost("GetLoadPopDetails")]
        public async Task<IActionResult> GetLoadPopDetails(Filter filter, string Tab, string Name, int Code, int TypeCode, int Month)
        {

            return Ok(await _repo.GetLoadPopDetails(UserHelper.GetUser(User), filter, Tab, Name, Code, TypeCode, Month));
        }

        [HttpPost("GetLabourPopDetails")]
        public async Task<IActionResult> GetLabourPopDetails(Filter filter, string Tab, string Name, int Code, int TypeCode, int Month)
        {

            return Ok(await _repo.GetLabourPopDetails(UserHelper.GetUser(User), filter, Tab, Name, Code, TypeCode, Month));
        }

        [HttpPost("GetMGAPopDetails")]
        public async Task<IActionResult> GetMGAPopDetails(Filter filter, string Tab, string Name, int Code, int TypeCode, int Month)
        {

            return Ok(await _repo.GetMGAPopDetails(UserHelper.GetUser(User), filter, Tab, Name, Code, TypeCode, Month));
        }


    }
}
