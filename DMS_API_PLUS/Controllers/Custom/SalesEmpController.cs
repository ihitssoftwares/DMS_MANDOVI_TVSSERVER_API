using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
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
    public class SalesEmpController : ControllerBase
    {
        #region Private properties
        private readonly ISalesEmpRepository _repo;
        #endregion
        #region Constructor        
        public SalesEmpController(ISalesEmpRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get
        [HttpPost("List")]
        public async Task<IActionResult> List(Filter filter, int Dealer,int Branch,int SalesDes,int Incentive,int Department,int Region,int SeniorRegManager)
        {

            return Ok(await _repo.GetList(UserHelper.GetUser(User),filter,Dealer,Branch,SalesDes, Incentive,Department, Region, SeniorRegManager));
        }
        #endregion
        [HttpPost("AddnewEmployee")]
        public async Task<IActionResult> AddNewEmployee(SalesEmp input, string mode)
        {
            
            return Ok(await _repo.Save(UserHelper.GetUser(User),mode,input));
        }
        [HttpGet("GetEmployeeDetails")]
        public async Task<IActionResult> GetCompanyDetails(int EmployeeCode, string mode)
        {
            return Ok(await _repo.GetEmployeeDetails(UserHelper.GetUser(User), EmployeeCode,mode));
        }
        [HttpPost("DeleteSalesEmp")]
        public async Task<IActionResult> DeleteSalesEmp(SalesEmp model)
        {

            return Ok(await _repo.DeleteSalesEmp(UserHelper.GetUser(User), model));
        }

        [HttpPost("PopupSave")]
        public async Task<IActionResult> PopupSave(SalesEmp model)
        {

            return Ok(await _repo.PopupSave(UserHelper.GetUser(User), model));
        }

        #region Get
        [HttpGet("GetPopupList")]
        public async Task<IActionResult> GetPopupList(int EmployeeCode)
        {

            return Ok(await _repo.GetPopupList(UserHelper.GetUser(User), EmployeeCode));
        }
        #endregion


        [HttpGet("DeletePopup")]
        public async Task<IActionResult> DeletePopup(int EmployeeCode, int DtCode)
        {

            return Ok(await _repo.DeletePopup(UserHelper.GetUser(User), EmployeeCode, DtCode));
        }
        [HttpGet("GetExportToExcel")]
        public async Task<IActionResult> GetExportToExcel(int Dealer, int Branch, int SalesDes, int Incentive, int Department, int Region)
        {
            return Ok(await _repo.GetExportToExcel(UserHelper.GetUser(User), Dealer, Branch, SalesDes, Incentive, Department, Region));
        }
    }
}
