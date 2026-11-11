using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cloud_Custom.Api.Repository.IRepository.General;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAMPLE_API_PLUS.Controllers.General
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {

        private IDropdownRepository _repo;

        public DropdownController(IDropdownRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("GetMenuSearchDropdown")]
        public async Task<IActionResult> GetMenuSearchDropdown(string LoginFrom)
        {
            return Ok(await _repo.GetMenuSearchDropdown(UserHelper.GetUser(User), LoginFrom));
        }


        [HttpGet("GetTargetBranchDropdown")]
        public async Task<IActionResult> GetTargetBranchDropdown(int? EmployeeCode)
        {
            return Ok(await _repo.GetTargetBranchDropdown(EmployeeCode, UserHelper.GetUser(User)));
        }

        [HttpGet("GetTargetRegionsettingsDropdown")]
        public async Task<IActionResult> GetTargetRegionsettingsDropdown()
        {
            return Ok(await _repo.GetTargetRegionsettingsDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetIncentiveType")]
        public async Task<IActionResult> GetIncentiveType()
        {
            return Ok(await _repo.GetIncentiveType(UserHelper.GetUser(User)));
        }

        [HttpGet("GetGenderDropDown")]
        public async Task<IActionResult> GetGenderDropDown()
        {
            return Ok(await _repo.GetGenderDropDown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetLocationDropdown")]
        public async Task<IActionResult> GetLocationDropdown()
        {
            return Ok(await _repo.GetLocationDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetCategoryDropdown")]
        public async Task<IActionResult> GetCategoryDropdown()
        {
            return Ok(await _repo.GetCategoryDropdown(UserHelper.GetUser(User)));

        }

        [HttpGet("GetMonthDMS")]
        public async Task<IActionResult> GetMonthDMS()
        {
            return Ok(await _repo.GetMonthDMS(UserHelper.GetUser(User)));

        }
        [HttpGet("GetServiceIncentiveProcessingMonthDropDown")]
        public async Task<IActionResult> GetServiceIncentiveProcessingMonthDropDown()
        {
            return Ok(await _repo.GetServiceIncentiveProcessingMonthDropDown(UserHelper.GetUser(User)));

        }
        [HttpGet("GetReportMonthDMS")]
        public async Task<IActionResult> GetReportMonthDMS()
        {
            return Ok(await _repo.GetReportMonthDMS(UserHelper.GetUser(User)));

        }
        [HttpGet("GetGroubyDropDown")]
        public async Task<IActionResult> GetGroubyDropDown()
        {
            return Ok(await _repo.GetGroubyDropDown(UserHelper.GetUser(User)));

        }
        [HttpGet("GetAppoinmentDropdown")]
        public async Task<IActionResult> GetAppoinmentDropdown()
        {
            return Ok(await _repo.GetAppoinmentDropdown(UserHelper.GetUser(User)));

        }


        [HttpGet("GetParameterDropDown")]
        public async Task<IActionResult> GetParameterDropDown()
        {
            return Ok(await _repo.GetParameterDropDown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetMonthToDropdown")]
        public async Task<IActionResult> GetMonthToDropdown()
        {
            return Ok(await _repo.GetMonthToDropdown(UserHelper.GetUser(User)));

        }

        [HttpGet("GetMonthFromDropdown")]
        public async Task<IActionResult> GetMonthFromDropdown()
        {
            return Ok(await _repo.GetMonthFromDropdown(UserHelper.GetUser(User)));

        }
        [HttpGet("GetServiceSettingsMonth")]
        public async Task<IActionResult> GetServiceSettingsMonth()
        {
            return Ok(await _repo.GetServiceSettingsMonth(UserHelper.GetUser(User)));

        }
        [HttpGet("GetSeviceincentiveMonthToDropdown")]
        public async Task<IActionResult> GetSeviceincentiveMonthToDropdown()
        {
            return Ok(await _repo.GetSeviceincentiveMonthToDropdown(UserHelper.GetUser(User)));

        }

        [HttpGet("GetSeviceincentiveMonthFromDropdown")]
        public async Task<IActionResult> GetSeviceincentiveMonthFromDropdown()
        {
            return Ok(await _repo.GetSeviceincentiveMonthFromDropdown(UserHelper.GetUser(User)));

        }

        [HttpGet("GetWorkshopDropdownList")]
        public async Task<IActionResult> GetWorkshopDropdown(int? id)
        {
            return Ok(await _repo.GetWorkshopDropdown(UserHelper.GetUser(User),id));

        }
        [HttpGet("GetUserRoleDropdown")]
        public async Task<IActionResult> GetUserRoleDropdown()
        {
            return Ok(await _repo.GetUserRoleDropdown(UserHelper.GetUser(User)));

        }
        [HttpGet("GetAgeDropdown")]
      public async Task<IActionResult> GetAgeDropdown()
      {
        return Ok(await _repo.GetAgeDropdown(UserHelper.GetUser(User)));

      }
      [HttpGet("GetDepartmentTypeDropdown")]
        public async Task<IActionResult> GetDepartmentTypeDropdown()
        {
            return Ok(await _repo.GetDepartmentTypeDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetWorkShopTypeDropdown")]
        public async Task<IActionResult> GetWorkShopTypeDropdown()
        {
            return Ok(await _repo.GetWorkShopTypeDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetLabourTypeDropdown")]
        public async Task<IActionResult> GetLabourTypeDropdown()
        {
            return Ok(await _repo.GetLabourTypeDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetLabourGroupDropdown")]
        public async Task<IActionResult> GetLabourGroupDropdown()
        {
            return Ok(await _repo.GetLabourGroupDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetServiceGroupDropdown")]
        public async Task<IActionResult> GetServiceGroupDropdown()
        {
            return Ok(await _repo.GetServiceGroupDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetServiceOilGroupDropdown")]
        public async Task<IActionResult> GetServiceOilGroupDropdown()
        {
            return Ok(await _repo.GetServiceOilGroupDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetServiceAccessoriesGroupDropdown")]
        public async Task<IActionResult> GetServiceAccessoriesGroupDropdown()
        {
            return Ok(await _repo.GetServiceAccessoriesGroupDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetServiceIncentiveGroup")]
        public async Task<IActionResult> GetServiceIncentiveGroup()
        {
            return Ok(await _repo.GetServiceIncentiveGroup(UserHelper.GetUser(User)));

        }


        [HttpGet("GetMonthDMSincentiveProcessed")]
    public async Task<IActionResult> GetMonthDMSincentiveProcessed()
    {
        return Ok(await _repo.GetMonthDMSincentiveProcessed(UserHelper.GetUser(User)));

    }

    [HttpGet("GetMonthDMSSettings")]
    public async Task<IActionResult> GetMonthDMSSettings()
    {
        return Ok(await _repo.GetMonthDMSSettings(UserHelper.GetUser(User)));

    }
    [HttpGet("GetStateDropDown")]
        public async Task<IActionResult> GetStateDropDown(int? CountryCode)
        {
            return Ok(await _repo.GetStateDropDown(CountryCode,UserHelper.GetUser(User)));
        }
        [HttpGet("GetGradeDropdown")]
        public async Task<IActionResult> GetGradeDropdown()
        {
            return Ok(await _repo.GetGradeDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetPayrollGroupDropdown")]
        public async Task<IActionResult> GetPayrollGroupDropdown()
        {
            return Ok(await _repo.GetPayrollGroupDropdown(UserHelper.GetUser(User)));
        }
      
        [HttpGet("GetDepartmentDropdown")]
        public async Task<IActionResult> GetDepartmentDropdown()
        {
            return Ok(await _repo.GetDepartmentDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetDesignationDropdown")]
        public async Task<IActionResult> GetDesignationDropdown()
        {
            return Ok(await _repo.GetDesignationDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetSectionDropdown")]
        public async Task<IActionResult> GetSectionDropdown()
        {
            return Ok(await _repo.GetSectionDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetDivisionDropdown")]
        public async Task<IActionResult> GetDivisionDropdown()
        {
            return Ok(await _repo.GetDivisionDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetWorkLocationDropdown")]
        public async Task<IActionResult> GetWorkLocationDropdown()
        {
            return Ok(await _repo.GetWorkLocationDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetWageGradeDropdown")]
        public async Task<IActionResult> GetWageGradeDropdown()
        {
            return Ok(await _repo.GetWageGradeDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetEmploymentStatusDropdown")]
        public async Task<IActionResult> GetEmploymentStatusDropdown()
        {
            return Ok(await _repo.GetEmploymentStatusDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetEmploymentTypeDropdown")]
        public async Task<IActionResult> GetEmploymentTypeDropdown()
        {
            return Ok(await _repo.GetEmploymentTypeDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetAttendanceStatusDropdown")]
        public async Task<IActionResult> GetAttendanceStatusDropdown()
        {
            return Ok(await _repo.GetAttendanceStatusDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetBranchWiseIncentiveRegionDropdown")]
        public async Task<IActionResult> GetBranchWiseIncentiveRegionDropdown()
        {
            return Ok(await _repo.GetBranchWiseIncentiveRegionDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetPaySheetTypeDropDown")]
        public async Task<IActionResult> GetPaySheetTypeDropDown()
        {
            return Ok(await _repo.GetPaySheetTypeDropDown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetPaysheetDraftMonthDropdown")]
        public async Task<IActionResult> GetPaysheetDraftMonthDropdown()
        {
            return Ok(await _repo.GetPaysheetDraftMonthDropdown(UserHelper.GetUser(User)));
        }

        
        [HttpGet("GetAttendanceProcessedMonthDropdown")]
        public async Task<IActionResult> GetAttendanceProcessedMonthDropdown()
        {
            return Ok(await _repo.GetAttendanceProcessedMonthDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetRegionDropdown")]
        public async Task<IActionResult> GetRegionDropdown()
        {
            return Ok(await _repo.GetRegionDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetPayrollReportMonthDropdown")]
        public async Task<IActionResult> GetPayrollReportMonthDropdown()
        {
            return Ok(await _repo.GetPayrollReportMonthDropdown(UserHelper.GetUser(User)));
        }
        //[HttpGet("GetPaymentModeDropDown")]
        //public async Task<IActionResult> GetPaymentModeDropDown()
        //{
        //    return Ok(await _repo.GetPaymentModeDropDown(UserHelper.GetUser(User)));
        //}
        [HttpGet("GetTypeDropdown")]
        public async Task<IActionResult> GetTypeDropdown()
        {
            return Ok(await _repo.GetTypeDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTypeVsOthersDropdown")]
        public async Task<IActionResult> GetTypeVsOthersDropdown()
        {
            return Ok(await _repo.GetTypeVsOthersDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetBayTypeDropdown")]
        public async Task<IActionResult> GetBayTypeDropdown()
        {
            return Ok(await _repo.GetBayTypeDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetDealerDropdown")]
        public async Task<IActionResult> GetDealerDropdown()
        {
            return Ok(await _repo.GetDealerDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetDealerCityDropdown")]
        public async Task<IActionResult> GetDealerCityDropdown()
        {
            return Ok(await _repo.GetDealerCityDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetBranchstateDropdown")]
        public async Task<IActionResult> GetBranchstateDropdown()
        {
            return Ok(await _repo.GetBranchstateDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetBranchRegionDropdown")]
        public async Task<IActionResult> GetBranchRegionDropdown()
        {
            return Ok(await _repo.GetBranchRegionDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetMonthDropdown")]
        public async Task<IActionResult> GetMonthDropdown()
        {
            return Ok(await _repo.GetMonthDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetIncentiveDropdown")]
        public async Task<IActionResult> GetIncentiveDropdown()
        {
            return Ok(await _repo.GetIncentiveDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetServiceIncentiveGroupType")]
        public async Task<IActionResult> GetServiceIncentiveGroupType()
        {
            return Ok(await _repo.GetServiceIncentiveGroupType(UserHelper.GetUser(User)));
        }

        [HttpGet("GetTeamLeaderDropdown")]
        public async Task<IActionResult> GetTeamLeaderDropdown()
        {
            return Ok(await _repo.GetTeamLeaderDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetDSEEmployeeDropdown")]
        public async Task<IActionResult> GetDSEEmployeeDropdown()
        {
            return Ok(await _repo.GetDSEEmployeeDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetWHLocationDropdown")]
        public async Task<IActionResult> GetWHLocationDropdown()
        {
            return Ok(await _repo.GetWHLocationDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetStoreManagerDropDown")]
        public async Task<IActionResult> GetStoreManagerDropDown()
        {
            return Ok(await _repo.GetStoreManagerDropDown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetEmployeePositionDropDown")]
        public async Task<IActionResult> GetEmployeePositionDropDown()
        {
            return Ok(await _repo.GetEmployeePositionDropDown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetFuelTypeList")]
        public async Task<IActionResult> GetFuelTypeList()
        {
            return Ok(await _repo.GetFuelTypeList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTransmissionTypeList")]
        public async Task<IActionResult> GetTransmissionTypeList()
        {
            return Ok(await _repo.GetTransmissionTypeList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetWorkshopDropDown")]
        public async Task<IActionResult> GetWorkshopDropDownList()
        {
            return Ok(await _repo.GetWorkshopDropDownList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetServiceTypeDropdown")]
        public async Task<IActionResult> GetServiceTypeDropdown()
        {
            return Ok(await _repo.GetServiceTypeDropdown(UserHelper.GetUser(User)));
        }


        #region SalaryProcessing
        [HttpGet("GetSalaryProcessing_MonthDropdown")]
        public async Task<IActionResult> GetSalaryProcessing_MonthDropdown(int? PayrollGroupCode)
        {
            return Ok(await _repo.GetSalaryProcessing_MonthDropdown(UserHelper.GetUser(User), PayrollGroupCode));
        }

        [HttpGet("GetSalaryProcessedMonth_Dropdown")]
        public async Task<IActionResult> GetSalaryProcessedMonth_Dropdown(int? PayrollGroup)
        {
            return Ok(await _repo.GetSalaryProcessedMonth_Dropdown(UserHelper.GetUser(User), PayrollGroup));
        }
        [HttpGet("GetSalaryProcessingAttenLockMonthDropdown")]
        public async Task<IActionResult> GetSalaryProcessingAttenLockMonthDropdown(int? PayrollGroupCode)
        {
            return Ok(await _repo.GetSalaryProcessingAttenLockMonthDropdown(UserHelper.GetUser(User), PayrollGroupCode));
        }
        #endregion

        #region ENCASH      
        [HttpGet("GetLeaveGroupFilterDropdown")]
        public async Task<IActionResult> GetLeaveGroupFilterDropdown()
        {
            return Ok(await _repo.GetLeaveGroupFilterDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetLeaveEncashment_LeaveDropdown")]
        public async Task<IActionResult> GetLeaveEncashment_LeaveDropdown()
        {
            return Ok(await _repo.GetLeaveEncashment_LeaveDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetLeavePeriodFilterDropdown")]
        public async Task<IActionResult> GetLeavePeriodFilterDropdown()
        {
            return Ok(await _repo.GetLeavePeriodFilterDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetLeaveEncashmentHistory_MonthDropdown")]
        public async Task<IActionResult> GetLeaveEncashmentHistory_MonthDropdown(int LeavePeriod)
        {
            return Ok(await _repo.GetLeaveEncashmentHistory_MonthDropdown(UserHelper.GetUser(User), LeavePeriod));
        }      
        #endregion

        #region MONTHLY ATTENDANCE PROCESSING
        [HttpGet("GetMonthly_AttendanceProcessing_MonthDropdown")]
        public async Task<IActionResult> GetMonthly_AttendanceProcessing_MonthDropdown(int? PayrollGroupCode)
        {
            return Ok(await _repo.GetMonthly_AttendanceProcessing_MonthDropdown(UserHelper.GetUser(User), PayrollGroupCode));
        }
        #endregion

        [HttpGet("GetPerformanceAllowanceDropdown")]
        public async Task<IActionResult> GetPerformanceAllowanceDropdown()
        {
            return Ok(await _repo.GetPerformanceAllowanceDropdown(UserHelper.GetUser(User)));
        }


        [HttpGet("GetWorkshopregionDropDown")]
        public async Task<IActionResult> GetWorkshopregionDropDown(int? id)
        {
            return Ok(await _repo.GetWorkshopregionDropDown(UserHelper.GetUser(User), id));
        }

        [HttpGet("GetServiceAdvisorDropDown")]
        public async Task<IActionResult> GetServiceAdvisorDropDown(int? id)
        {
            return Ok(await _repo.GetServiceAdvisorDropDown(UserHelper.GetUser(User), id));
        }
         [HttpGet("GetBayDropDown")]
        public async Task<IActionResult> GetBayDropDown(int? WorkShopCode)
        {
            return Ok(await _repo.GetBayDropDown(UserHelper.GetUser(User), WorkShopCode));
        }


        [HttpGet("GetCalculationTypeDropdown")]
        public async Task<IActionResult> GetCalculationTypeDropdown()
        {
            return Ok(await _repo.GetCalculationTypeDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetDMSBranchDropdown")]
        public async Task<IActionResult> GetDMSBranchDropdown()
        {
            return Ok(await _repo.GetDMSBranchDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetBranchDropdown")]
        public async Task<IActionResult> GetBranchDropdown()
        {
            return Ok(await _repo.GetBranchDropdown(UserHelper.GetUser(User)));
        }


        [HttpGet("GetTeamTargetEmployeeDropdown")]
        public async Task<IActionResult> GetTeamTargetEmployeeDropdown(int BranchCode)
        {
            return Ok(await _repo.GetTeamTargetEmployeeDropdown(UserHelper.GetUser(User), BranchCode));
        }
        [HttpGet("GetServiceIncentiveRolereport")]
        public async Task<IActionResult> GetServiceIncentiveRolereport(int Month, int region)
        {
            return Ok(await _repo.GetServiceIncentiveRolereport(UserHelper.GetUser(User), Month,region));
        }
        [HttpGet("GetServiceIncentiveRoleBranchDropdown")]
        public async Task<IActionResult> GetServiceIncentiveRoleBranchDropdown(int Month, int region,int IncentiveGroup)
        {
            return Ok(await _repo.GetServiceIncentiveRoleBranchDropdown(UserHelper.GetUser(User), Month, region, IncentiveGroup));
        }
        [HttpGet("GetTeamIncentiveGroupDropdown")]
        public async Task<IActionResult> GetTeamIncentiveGroupDropdown()
        {
            return Ok(await _repo.GetTeamIncentiveGroupDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetServiceBranchDropdown")]
        public async Task<IActionResult> GetServiceBranchDropdown()
        {
            return Ok(await _repo.GetServiceBranchDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetBranchTargetEmployeeDropdown")]
        public async Task<IActionResult> GetBranchTargetEmployeeDropdown()
        {
            return Ok(await _repo.GetBranchTargetEmployeeDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetRegionTargetEmployeeDropdown")]
        public async Task<IActionResult> GetRegionTargetEmployeeDropdown()
        {
            return Ok(await _repo.GetRegionTargetEmployeeDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetDMSMODELDropdown")]
        public async Task<IActionResult> GetDMSMODELDropdown()
        {
            return Ok(await _repo.GetDMSMODELDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTypeVSMODELDropdown")]
        public async Task<IActionResult> GetTypeVSMODELDropdown(int Type)
        {
            return Ok(await _repo.GetTypeVSMODELDropdown(UserHelper.GetUser(User),Type));
        }

        [HttpGet("GetEmployeeBranchDropdown")]
        public async Task<IActionResult> GetEmployeeBranchDropdown()
        {
            return Ok(await _repo.GetEmployeeBranchDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetTaxDropdown")]
        public async Task<IActionResult> GetTaxDropdown()
        {
            return Ok(await _repo.GetTaxDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetPaymentModeDropdown")]
        public async Task<IActionResult> GetPaymentModeDropdown()
        {
            return Ok(await _repo.GetPaymentModeDropdown(UserHelper.GetUser(User)));
        }


        [HttpGet("GetDMSEMPLOYEEDropdown")]
        public async Task<IActionResult> GetDMSEMPLOYEEDropdown()
        {
            return Ok(await _repo.GetDMSEMPLOYEEDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetEMPLOYEEvsLocationDropdown")]
        public async Task<IActionResult> GetEMPLOYEEvsLocationDropdown(int LocationCode)
        {
            return Ok(await _repo.GetEMPLOYEEvsLocationDropdown(UserHelper.GetUser(User), LocationCode));
        }
        [HttpGet("GetEMPLOYEEandLOCATIONDropdown")]
        public async Task<IActionResult> GetEMPLOYEEandLOCATIONDropdown()
        {
            return Ok(await _repo.GetEMPLOYEEandLOCATIONDropdown(UserHelper.GetUser(User)));
        }
        #region IncentiveSettings    
        [HttpGet("GetSalesDesignationDropdown")]
        public async Task<IActionResult> GetSalesDesignationDropdown()
        {
            return Ok(await _repo.GetSalesDesignationDropdown(UserHelper.GetUser(User)));
        }
        #endregion
        #region CRM    
        [HttpGet("GetSaleExecutives")]
        public async Task<IActionResult> GetSaleExecutives()
        {
            return Ok(await _repo.GetSaleExecutives(UserHelper.GetUser(User)));
        }
        [HttpGet("GetVariant")]
        public async Task<IActionResult> GetVariant(int Model)
        {
            return Ok(await _repo.GetVariant(UserHelper.GetUser(User), Model));
        }

        [HttpGet("GetVariantList")]
        public async Task<IActionResult> GetVariantList()
        {
            return Ok(await _repo.GetVariantList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetBankList")]
        public async Task<IActionResult> GetBankList()
        {
            return Ok(await _repo.GetBankList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetPayModeList")]
        public async Task<IActionResult> GetPayModeList()
        {
            return Ok(await _repo.GetPayModeList(UserHelper.GetUser(User)));
        }

        [HttpGet("GetColorList")]
        public async Task<IActionResult> GetColorList()
        {
            return Ok(await _repo.GetColorList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetMonthCRM")]
        public async Task<IActionResult> GetMonthCRM()
        {
            return Ok(await _repo.GetMonthCRM(UserHelper.GetUser(User)));
        }
        [HttpGet("GetYearsList")]
        public async Task<IActionResult> GetYearsList()
        {
            return Ok(await _repo.GetYearsList(UserHelper.GetUser(User)));

        }
        [HttpGet("GetInsuranceTypeList")]
        public async Task<IActionResult> GetInsuranceTypeList()
        {
            return Ok(await _repo.GetInsuranceTypeList(UserHelper.GetUser(User)));

        }
        [HttpGet("GetInsuranceCompanyList")]
        public async Task<IActionResult> GetInsuranceCompanyList()
        {
            return Ok(await _repo.GetInsuranceCompanyList(UserHelper.GetUser(User)));

        }

       

        [HttpGet("GetRemarksList")]
        public async Task<IActionResult> GetRemarksList()
        {
            return Ok(await _repo.GetRemarksList(UserHelper.GetUser(User)));
        }

        [HttpGet("GetDMSSoureOfEnqDropDown")]
        public async Task<IActionResult> GetDMSSoureOfEnqDropDown()
        {
            return Ok(await _repo.GetDMSSoureOfEnqDropDown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetAccessoriesList")]
        public async Task<IActionResult> GetAccessoriesList(int Model)
        {
            return Ok(await _repo.GetAccessoriesList(UserHelper.GetUser(User), Model));

        }

        #endregion
        #region TestDeive
        [HttpGet("GetTimeDropdown")]
        public async Task<IActionResult> GetTimeDropdown()
        {
            return Ok(await _repo.GetTimeDropdown(UserHelper.GetUser(User)));
        }
         [HttpGet("GetCustomerList")]
        public async Task<IActionResult> GetCustomerList()
        {
            return Ok(await _repo.GetCustomerList(UserHelper.GetUser(User)));
        }
        [HttpGet("Getvehicle")]
        public async Task<IActionResult> Getvehicle()
        {
            return Ok(await _repo.Getvehicle(UserHelper.GetUser(User)));
        }
         [HttpGet("GetPurchaseTimeDropdown")]
        public async Task<IActionResult> GetPurchaseTimeDropdown()
        {
            return Ok(await _repo.GetPurchaseTimeDropdown(UserHelper.GetUser(User)));
        }

        #endregion

        [HttpGet("GetBatchCode")]
        public async Task<IActionResult> GetBatchCode()
        {
            return Ok(await _repo.GetBatchCode(UserHelper.GetUser(User)));
        }
        [HttpGet("GetParameterChecked")]
        public async Task<IActionResult> GetParameterChecked(int designationCode)
        {
            return Ok(await _repo.GetParameterChecked(UserHelper.GetUser(User), designationCode));
        }
        //[HttpGet("GetMcarePlanDropdown")]
        //public async Task<IActionResult> GetMcarePlanDropdown()
        //{
        //    return Ok(await _repo.GetMcarePlanDropdown(UserHelper.GetUser(User)));
        //}


        [HttpGet("GetDMSLeadTypeDropdown")]
        public async Task<IActionResult> GetDMSLeadTypeDropdown()
        {
            return Ok(await _repo.GetDMSLeadTypeDropdown(UserHelper.GetUser(User)));


        }
        [HttpGet("GetServiceDropdown")]
        public async Task<IActionResult> GetServiceDropdown()
        {
            return Ok(await _repo.GetServiceDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetWareHouseropdown")]
        public async Task<IActionResult> GetWareHouseropdown()
        {
            return Ok(await _repo.GetWareHouseropdown(UserHelper.GetUser(User)));
        }

         [HttpGet("GetAllotmentDropDown")]
        public async Task<IActionResult> GetAllotmentDropDown(int Model,int Variant)
        {
            return Ok(await _repo.GetAllotmentDropDown(UserHelper.GetUser(User),Model, Variant));
        }

       
         [HttpGet("GetAllotmentStatus")]
        public async Task<IActionResult> GetAllotmentStatus()
        {
            return Ok(await _repo.GetAllotmentStatus(UserHelper.GetUser(User)));
        }
        [HttpGet("GetDmsDistrictDropdown")]
        public async Task<IActionResult> GetDmsDistrictDropdown()
        {
            return Ok(await _repo.GetDmsDistrictDropdown(UserHelper.GetUser(User) ));
        }
        [HttpGet("GetDistrictDropdown")]
        public async Task<IActionResult> GetDistrictDropdown(int State)
        {
            return Ok(await _repo.GetDistrictDropdown(UserHelper.GetUser(User), State));
        }

        [HttpGet("GetFinancier")]
        public async Task<IActionResult> GetFinancier()
        {
            return Ok(await _repo.GetFinancier(UserHelper.GetUser(User)));
        }

        [HttpGet("GetRtoOffice")]
        public async Task<IActionResult> GetRtoOffice(int State, int District)
        {
            return Ok(await _repo.GetRtoOffice(UserHelper.GetUser(User),State,District));
        }

        [HttpGet("GetRegistrationType")]
        public async Task<IActionResult> GetRegistrationType()
        {
            return Ok(await _repo.GetRegistrationType(UserHelper.GetUser(User)));
        }

        [HttpGet("GetRegistrationCategory")]
        public async Task<IActionResult> GetRegistrationCategory()
        {
            return Ok(await _repo.GetRegistrationCategory(UserHelper.GetUser(User)));
        }
        [HttpGet("GetDMSStatusDropdown")]
        public async Task<IActionResult> GetDMSStatusDropdown()
        {
            return Ok(await _repo.GetDMSStatusDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetCallStatusropdown")]
        public async Task<IActionResult> GetCallStatusropdown()
        {
            return Ok(await _repo.GetCallStatusropdown(UserHelper.GetUser(User)));
        }



        [HttpGet("GetYesOrNoDropdown")]
        public async Task<IActionResult> GetYesOrNoDropdown()
        {
            return Ok(await _repo.GetYesOrNoDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetTimeSlotDropDown")]
        public async Task<IActionResult> GetTimeSlotDropDown()
        {
            return Ok(await _repo.GetTimeSlotDropDown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTypeDmsDropdown")]
        public async Task<IActionResult> GetTypeDmsDropdown(String Tab)
        {
            return Ok(await _repo.GetTypeDmsDropdown(UserHelper.GetUser(User), Tab));
        }
        [HttpGet("GetMonthServiceDMS")]
        public async Task<IActionResult> GetMonthServiceDMS(string Tab)
        {
            return Ok(await _repo.GetMonthServiceDMS(UserHelper.GetUser(User), Tab));
        }
        [HttpGet("GetDMSRegionDropdown")]
        public async Task<IActionResult> GetDMSRegionDropdown()
        {
            return Ok(await _repo.GetDMSRegionDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetDMSBranchwiseDropdown")]
        public async Task<IActionResult> GetDMSBranchwiseDropdown()
        {
            return Ok(await _repo.GetDMSBranchwiseDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTeamLeaderByDeptAndPosition")]
        public async Task<IActionResult> GetTeamLeaderByDeptAndPosition(int departmentCode, int positionCode)
        {
            return Ok(await _repo.GetTeamLeaderByDeptAndPosition(UserHelper.GetUser(User), departmentCode, positionCode));

        }
        [HttpGet("GetDMSBranchByDepartment")]
        public async Task<IActionResult> GetDMSBranchByDepartment(int departmentCode)
        {
            return Ok(await _repo.GetDMSBranchByDepartment(UserHelper.GetUser(User), departmentCode));
        }

        [HttpGet("GetEmployeePositionByDepartment")]
        public async Task<IActionResult> GetEmployeePositionByDepartment(int departmentCode)
        {
            return Ok(await _repo.GetEmployeePositionByDepartment(UserHelper.GetUser(User), departmentCode));
        }


        [HttpGet("GetIncentiveByDepartment")]
        public async Task<IActionResult> GetIncentiveByDepartment(int departmentCode)
        {
            return Ok(await _repo.GetIncentiveByDepartment(UserHelper.GetUser(User), departmentCode));
        }
        [HttpGet("GetSalesDesignationByDepartment")]
        public async Task<IActionResult> GetSalesDesignationByDepartment(int departmentCode)
        {
            return Ok(await _repo.GetSalesDesignationByDepartment(UserHelper.GetUser(User), departmentCode));
        }
        [HttpGet("GetWorkShopMobileDropdown")]
        public async Task<IActionResult> GetWorkShopMobileDropdown()
        {
            return Ok(await _repo.GetWorkShopMobileDropdown(UserHelper.GetUser(User)));
        }


        [HttpGet("GetServiceIncentiveGroupSpecial")]
        public async Task<IActionResult> GetServiceIncentiveGroupSpecial()
        {
            return Ok(await _repo.GetServiceIncentiveGroupSpecial(UserHelper.GetUser(User)));

        }



        [HttpGet("GetMonthTarget")]
        public async Task<IActionResult> GetMonthTarget()
        {
            return Ok(await _repo.GetMonthTarget(UserHelper.GetUser(User)));


        }



        [HttpGet("GetTargetParameterDropDown")]
        public async Task<IActionResult> GetTargetParameterDropDown()
        {
            return Ok(await _repo.GetTargetParameterDropDown(UserHelper.GetUser(User)));
        }


        [HttpGet("GetTargetRegionDropdown")]
        public async Task<IActionResult> GetTargetRegionDropdown()
        {
            return Ok(await _repo.GetTargetRegionDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetWorkshopReportDropDown")]
        public async Task<IActionResult> GetWorkshopReportDropDown()
        {
            return Ok(await _repo.GetWorkshopReportDropDown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetJobCardStatusDropDown")]
        public async Task<IActionResult> GetJobCardStatusDropDown()
        {
            return Ok(await _repo.GetJobCardStatusDropDown(UserHelper.GetUser(User)));
        }


        [HttpGet("GetDriverListDropDown")]
        public async Task<IActionResult> GetDriverListDropDown()
        {
            return Ok(await _repo.GetDriverListDropDown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetIncentiveBasedonDropdown")]
        public async Task<IActionResult> GetIncentiveBasedonDropdown()
        {
            return Ok(await _repo.GetIncentiveBasedonDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetRegNoDropDown")]
        public async Task<IActionResult> GetRegNoDropDown(int? WorkShopCode)
        {
            return Ok(await _repo.GetRegNoDropDown(UserHelper.GetUser(User), WorkShopCode));
        }
        [HttpGet("GetTech")]
        public async Task<IActionResult> GetTech(int? WorkShopCode)
        {
            return Ok(await _repo.GetTech(UserHelper.GetUser(User), WorkShopCode));
        }

        [HttpGet("GetJobCard")]
        public async Task<IActionResult> GetJobCard(int? WorkShopCode, int? JobCardNo)
        {
            return Ok(await _repo.GetJobCard(UserHelper.GetUser(User), WorkShopCode, JobCardNo));
        }
        [HttpGet("GetBayJobDropDown")]
        public async Task<IActionResult> GetBayJobDropDown(int WorkShopCode, int Bay)
        {
            return Ok(await _repo.GetBayJobDropDown(UserHelper.GetUser(User), WorkShopCode, Bay));
        }

        [HttpGet("GetBayTechDropDown")]
        public async Task<IActionResult> GetBayTechDropDown(int WorkShopCode, string Date, int techcode)
        {
            return Ok(await _repo.GetBayTechDropDown(UserHelper.GetUser(User), WorkShopCode, Date, techcode));
        }

        [HttpGet("GetIncentiveGroupBasedonDropdown")]
        public async Task<IActionResult> GetIncentiveGroupBasedonDropdown()
        {
            return Ok(await _repo.GetIncentiveGroupBasedonDropdown(UserHelper.GetUser(User)));
        }

       

        [HttpGet("GetBranchTargetIncentiveDropdown")]
        public async Task<IActionResult> GetBranchTargetIncentiveDropdown()
        {
            return Ok(await _repo.GetBranchTargetIncentiveDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetOnlyThreeMonthDropdown")]
        public async Task<IActionResult> GetOnlyThreeMonthDropdown()
        {
            return Ok(await _repo.GetOnlyThreeMonthDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetParameterByGroupDropDown")]
        public async Task<IActionResult> GetParameterByGroupDropDown(int IncentiveGroup)
        {
            return Ok(await _repo.GetParameterByGroupDropDown(UserHelper.GetUser(User), IncentiveGroup));
        }



        [HttpGet("GetDMSBranchwiseRegionDropdown")]
        public async Task<IActionResult> GetDMSBranchwiseRegionDropdown(int Branch)
        {
            return Ok(await _repo.GetDMSBranchwiseRegionDropdown(UserHelper.GetUser(User), Branch));
        }
        [HttpGet("GetOutSourceWorkCombofill")]
        public async Task<IActionResult> GetOutSourceWorkCombofill()
        {
            return Ok(await _repo.GetOutSourceWorkCombofill(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTargetBranchssDropdown")]
        public async Task<IActionResult> GetTargetBranchssDropdown(int IncentiveGroupCode)
        {
            return Ok(await _repo.GetTargetBranchssDropdown(UserHelper.GetUser(User), IncentiveGroupCode));
        }
        [HttpGet("GetTeamTargetEmployeessDropdown")]
        public async Task<IActionResult> GetTeamTargetEmployeessDropdown(int BranchCode, int IncentiveGroupCode)
        {
            return Ok(await _repo.GetTeamTargetEmployeessDropdown(UserHelper.GetUser(User), BranchCode, IncentiveGroupCode));
        }


        [HttpGet("GetWarrentyPlanDropdown")]
        public async Task<IActionResult> GetWarrentyPlanDropdown()
        {
            return Ok(await _repo.GetWarrentyPlanDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetAllotmentVariantDropdown")]
        public async Task<IActionResult> GetAllotmentVariantDropdown(int Status,int Model)
        {
            return Ok(await _repo.GetAllotmentVariantDropdown(UserHelper.GetUser(User), Status,Model));
        }
        [HttpGet("GetAllotmentModelDropdown")]
        public async Task<IActionResult> GetAllotmentModelDropdown(int Status)
        {
            return Ok(await _repo.GetAllotmentModelDropdown(UserHelper.GetUser(User), Status));
        }
        [HttpGet("getpendingBayJOBdropdown")]
        public async Task<IActionResult> getpendingBayJOBdropdown(int WorkShopCode, int BayCode)
        {
            return Ok(await _repo.getpendingBayJOBdropdown(UserHelper.GetUser(User), WorkShopCode,BayCode));
        }
        [HttpGet("GetDMSUserRoleDropdown")]
        public async Task<IActionResult> GetDMSUserRoleDropdown()
        {
            return Ok(await _repo.GetDMSUserRoleDropdown(UserHelper.GetUser(User)));
        }

        #region ValuePassingDROPDOWN

        [HttpGet("GetMonthWorkShop")]
        public async Task<IActionResult> GetMonthWorkShop(int WorkShopCode)
        {
            return Ok(await _repo.GetMonthWorkShop(UserHelper.GetUser(User), WorkShopCode));
        }

        [HttpGet("GetRegionEDDropdown")]
        public async Task<IActionResult> GetRegionEDDropdown()
        {
            return Ok(await _repo.GetRegionEDDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetWorkshopFSDropDown")]
        public async Task<IActionResult> GetWorkshopFSDropDown()
        {
            return Ok(await _repo.GetWorkshopFSDropDown(UserHelper.GetUser(User)));
        }


        [HttpGet("GetWorkshopBayMovementDropDown")]
        public async Task<IActionResult> GetWorkshopBayMovementDropDown()
        {
            return Ok(await _repo.GetWorkshopBayMovementDropDown(UserHelper.GetUser(User)));
        }


        #endregion
        [HttpGet("GetWorkShopAdvisor")]
        public async Task<IActionResult> GetWorkShopAdvisor(int WorkShopCode)
        {
            return Ok(await _repo.GetWorkShopAdvisor(UserHelper.GetUser(User), WorkShopCode));
        }
        [HttpGet("GetEmployeeNotInUserDropdown")]
        public async Task<IActionResult> GetEmployeeNotInUserDropdown()
        {
            return Ok(await _repo.GetEmployeeNotInUserDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetModelVariantvsColorDropdown")]
        public async Task<IActionResult> GetModelVariantvsColorDropdown(int Model, int Varient)
        {
            return Ok(await _repo.GetModelVariantvsColorDropdown(UserHelper.GetUser(User), Model, Varient));
        }
        [HttpGet("GetSecurity")]
        public async Task<IActionResult> GetSecurity(int WorkShopCode)
        {
            return Ok(await _repo.GetSecurity(UserHelper.GetUser(User), WorkShopCode));
        }
        [HttpGet("GetMCarePlanDropdown")]
        public async Task<IActionResult> GetMCarePlanDropdown()
        {
            return Ok(await _repo.GetMCarePlanDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetMcareActivePlanDropdown")]
        public async Task<IActionResult> GetMcareActivePlanDropdown()
        {
            return Ok(await _repo.GetMcareActivePlanDropdown(UserHelper.GetUser(User)));
        }


        [HttpGet("GetMCareRegistrationStatusDropdown")]
        public async Task<IActionResult> GetMCareRegistrationStatusDropdown()
        {
            return Ok(await _repo.GetMCareRegistrationStatusDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetMCareDuration")]
        public async Task<IActionResult> GetMCareDuration()
        {
            return Ok(await _repo.GetMCareDuration(UserHelper.GetUser(User)));
        }
        [HttpGet("GetModelVariantBranch")]
        public async Task<IActionResult> GetModelVariantBranch()
        {
            return Ok(await _repo.GetModelVariantBranch(UserHelper.GetUser(User)));
        }





        [HttpGet("GetSeviceAchivementvsTarget_MonthDropdown")]
        public async Task<IActionResult> GetSeviceAchivementvsTarget_MonthDropdown()
        {
            return Ok(await _repo.GetSeviceAchivementvsTarget_MonthDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetSeviceAchivementvsTarget_ParameterDropdown")]
        public async Task<IActionResult> GetSeviceAchivementvsTarget_ParameterDropdown()
        {
            return Ok(await _repo.GetSeviceAchivementvsTarget_ParameterDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetSeviceAchivementvsTarget_RegionDropdown")]
        public async Task<IActionResult> GetSeviceAchivementvsTarget_RegionDropdown()
        {
            return Ok(await _repo.GetSeviceAchivementvsTarget_RegionDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetEmployeeVSTargetReport_BranchDropdown")]
        public async Task<IActionResult> GetEmployeeVSTargetReport_BranchDropdown()
        {
            return Ok(await _repo.GetEmployeeVSTargetReport_BranchDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetEmployeeVSTargetReport_MonthDropdown")]
        public async Task<IActionResult> GetEmployeeVSTargetReport_MonthDropdown()
        {
            return Ok(await _repo.GetEmployeeVSTargetReport_MonthDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetEmployeeVSTargetReport_ParameterDropdown")]
        public async Task<IActionResult> GetEmployeeVSTargetReport_ParameterDropdown()
        {
            return Ok(await _repo.GetEmployeeVSTargetReport_ParameterDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetEmployeeVSTargetReport_RegionDropdown")]
        public async Task<IActionResult> GetEmployeeVSTargetReport_RegionDropdown()
        {
            return Ok(await _repo.GetEmployeeVSTargetReport_RegionDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetAllotmentColorDropdown")]
        public async Task<IActionResult> GetAllotmentColorDropdown(int Status,int Model, int Varient)
        {
            return Ok(await _repo.GetAllotmentColorDropdown(UserHelper.GetUser(User),Status, Model, Varient));
        }


        [HttpGet("GetSalesBranchDropdown")]
        public async Task<IActionResult> GetSalesBranchDropdown()
        {
            return Ok(await _repo.GetSalesBranchDropdown(UserHelper.GetUser(User)));
        }


        [HttpGet("GetSalesVarientDropdown")]
        public async Task<IActionResult> GetSalesVarientDropdown()
        {
            return Ok(await _repo.GetSalesVarientDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetMCareServiceAdvisorDropDown")]
        public async Task<IActionResult> GetMCareServiceAdvisorDropDown(int? id)
        {
            return Ok(await _repo.GetMCareServiceAdvisorDropDown(UserHelper.GetUser(User), id));
        }
        [HttpGet("GetSalesBranch")]
        public async Task<IActionResult> GetSalesBranch()
        {
            return Ok(await _repo.GetSalesBranch(UserHelper.GetUser(User)));
        }


        [HttpGet("GetModeOfPaymentDropdown")]
        public async Task<IActionResult> GetModeOfPaymentDropdown()
        {
            return Ok(await _repo.GetModeOfPaymentDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetDMSRegionWiseBranchDropdown")]
        public async Task<IActionResult> GetDMSRegionWiseBranchDropdown(int BranchCode)
        {
            return Ok(await _repo.GetDMSRegionWiseBranchDropdown(UserHelper.GetUser(User),BranchCode));
        }

       [ HttpGet("GetMcareCancelPaymentModeDropdown")]
        public async Task<IActionResult> GetMcareCancelPaymentModeDropdown()
        {
            return Ok(await _repo.GetMcareCancelPaymentModeDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetServiceAdvisorMobileDropdown")]
        public async Task<IActionResult> GetServiceAdvisorMobileDropdown(int WorkshopCode)
        {
            return Ok(await _repo.GetServiceAdvisorMobileDropdown(UserHelper.GetUser(User), WorkshopCode));
        }
         [HttpGet("GetMcareCancellationReasonDropDown")]
        public async Task<IActionResult> GetMcareCancellationReasonDropDown()
        {
            return Ok(await _repo.GetMcareCancellationReasonDropDown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetMcareServiceDropdown")]
        public async Task<IActionResult> GetMcareServiceDropdown()
        {
            return Ok(await _repo.GetMcareServiceDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetSourceEnquiryDrodown")]
        public async Task<IActionResult> GetSourceEnquiryDrodown()
        {
            return Ok(await _repo.GetSourceEnquiryDrodown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetServiceAdvisorLoadDropdown")]
        public async Task<IActionResult> GetServiceAdvisorLoadDropdown(int Month, int Region, int branch)
        {
            return Ok(await _repo.GetServiceAdvisorLoadDropdown(UserHelper.GetUser(User), Month, Region, branch));
        }
        [HttpGet("GetNewServiceAdvisorDropdown")]
        public async Task<IActionResult> GetNewServiceAdvisorDropdown(int Month, int Region, int branch)
        {
            return Ok(await _repo.GetNewServiceAdvisorDropdown(UserHelper.GetUser(User), Month, Region, branch));
        }
        [HttpGet("GetServiceAdvisorLabourDropdown")]
        public async Task<IActionResult> GetServiceAdvisorLabourDropdown(int Month, int Region, int branch)
        {
            return Ok(await _repo.GetServiceAdvisorLabourDropdown(UserHelper.GetUser(User), Month, Region, branch));
        }
        [HttpGet("GetServiceAdvisorMGADropdown")]
        public async Task<IActionResult> GetServiceAdvisorMGADropdown(int Month, int Region, int branch)
        {
            return Ok(await _repo.GetServiceAdvisorMGADropdown(UserHelper.GetUser(User), Month, Region, branch));
        }
     
        [HttpGet("GetLoadMonthDropdown")]
        public async Task<IActionResult> GetLoadMonthDropdown()
        {
            return Ok(await _repo.GetLoadMonthDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetLabourMonthDropdown")]
        public async Task<IActionResult> GetLabourMonthDropdown()
        {
            return Ok(await _repo.GetLabourMonthDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetLabourRegionDropdown")]
        public async Task<IActionResult> GetLabourRegionDropdown()
        {
            return Ok(await _repo.GetLabourRegionDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetLoadRegionDropdown")]
        public async Task<IActionResult> GetLoadRegionDropdown()
        {
            return Ok(await _repo.GetLoadRegionDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetLoadRegionWiseBranchDropdown")]
        public async Task<IActionResult> GetLoadRegionWiseBranchDropdown(int BranchCode)
        {
            return Ok(await _repo.GetLoadRegionWiseBranchDropdown(UserHelper.GetUser(User), BranchCode));
        }
        [HttpGet("GetMcareregModel")]
        public async Task<IActionResult> GetMcareregModel()
        {
            return Ok(await _repo.GetMcareregModel(UserHelper.GetUser(User)));
        }
        [HttpGet("GetModelSegment")]
        public async Task<IActionResult> GetModelSegment()
        {
            return Ok(await _repo.GetModelSegment(UserHelper.GetUser(User)));
        }

        [HttpGet("GetColdFollowUpStatusDropdown")]
        public async Task<IActionResult> GetColdFollowUpStatusDropdown()
        {
            return Ok(await _repo.GetColdFollowUpStatusDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetModuleDropdown")]
        public async Task<IActionResult> GetModuleDropdown()
        {
            return Ok(await _repo.GetModuleDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetLabourRegionWiseBranchDropdown")]
        public async Task<IActionResult> GetLabourRegionWiseBranchDropdown(int MonthCode, int RegionCode)
        {
            return Ok(await _repo.GetLabourRegionWiseBranchDropdown(UserHelper.GetUser(User), RegionCode, MonthCode));
        }
         [HttpGet("GetDsewithiddropdown")]
        public async Task<IActionResult> GetDsewithiddropdown(int branch, int Region)
        {
            return Ok(await _repo.GetDsewithiddropdown(UserHelper.GetUser(User), branch, Region));
        }
        [HttpGet("GetEmployeeDesignationDropdown")]
        public async Task<IActionResult> GetEmployeeDesignationDropdown(int DesignationCode)
        {
            return Ok(await _repo.GetEmployeeDesignationDropdown(UserHelper.GetUser(User), DesignationCode));
        }
        [HttpGet("GetBranchWiseEmployeeDropdown")]
        public async Task<IActionResult> GetBranchWiseEmployeeDropdown(int BarnchCode)
        {
            return Ok(await _repo.GetBranchWiseEmployeeDropdown(UserHelper.GetUser(User), BarnchCode));
        }
         [HttpGet("GetOutletModel")]
        public async Task<IActionResult> GetOutletModel()
        {
            return Ok(await _repo.GetOutletModel(UserHelper.GetUser(User)));
        }
         [HttpGet("GetOutletEnquiryDropDown")]
        public async Task<IActionResult> GetOutletEnquiryDropDown()
        {
            return Ok(await _repo.GetOutletEnquiryDropDown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTeamManagerWiseEnquiryStatusMonthDropDown")]
        public async Task<IActionResult> GetTeamManagerWiseEnquiryStatusMonthDropDown()
        {
            return Ok(await _repo.GetTeamManagerWiseEnquiryStatusMonthDropDown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTeamManagerWiseEnquiryStatusModelDropDown")]
        public async Task<IActionResult> GetTeamManagerWiseEnquiryStatusModelDropDown()
        {
            return Ok(await _repo.GetTeamManagerWiseEnquiryStatusModelDropDown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTeamManagerWiseEnquiryStatusEnquiryDropDown")]
        public async Task<IActionResult> GetTeamManagerWiseEnquiryStatusEnquiryDropDown()
        {
            return Ok(await _repo.GetTeamManagerWiseEnquiryStatusEnquiryDropDown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetSalesDateDropdown")]
        public async Task<IActionResult> GetSalesDateDropdown(DateTime FromDate, DateTime ToDate)
        {
            return Ok(await _repo.GetSalesDateDropdown(UserHelper.GetUser(User), FromDate, ToDate));
        }
        [HttpGet("GetDMSMCARERegionWiseBranchDropdown")]
        public async Task<IActionResult> GetDMSMCARERegionWiseBranchDropdown(int BranchCode)
        {
            return Ok(await _repo.GetDMSMCARERegionWiseBranchDropdown(UserHelper.GetUser(User), BranchCode));
        }

        [HttpGet("GetSeniorRegionalManagerDropdown")]
        public async Task<IActionResult> GetSeniorRegionalManagerDropdown()
        {
            return Ok(await _repo.GetSeniorRegionalManagerDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetPlanNotSetMODELDropdown")]
        public async Task<IActionResult> GetPlanNotSetMODELDropdown()
        {
            return Ok(await _repo.GetPlanNotSetMODELDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetSalesMonthDropdown")]
        public async Task<IActionResult> GetSalesMonthDropdown()
        {
            return Ok(await _repo.GetSalesMonthDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetServiceAchivementAdjustmentMonthDropdown")]
        public async Task<IActionResult> GetServiceAchivementAdjustmentMonthDropdown()
        {
            return Ok(await _repo.GetServiceAchivementAdjustmentMonthDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetServiceAchivementAdjustmentIncentiveRoleDropdown")]
        public async Task<IActionResult> GetServiceAchivementAdjustmentIncentiveRoleDropdown()
        {
            return Ok(await _repo.GetServiceAchivementAdjustmentIncentiveRoleDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetServiceAchivementAdjustmentBRANCHDropdown")]
        public async Task<IActionResult> GetServiceAchivementAdjustmentBRANCHDropdown(int Monthcode)
        {
            return Ok(await _repo.GetServiceAchivementAdjustmentBRANCHDropdown(UserHelper.GetUser(User), Monthcode));
        }



        [HttpGet("GetModelDropdown")]
        public async Task<IActionResult> GetModelDropdown()
        {
            return Ok(await _repo.GetModelDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetTlDropdown")]
        public async Task<IActionResult> GetTlDropdown()
        {
            return Ok(await _repo.GetTlDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetDseDropdown")]
        public async Task<IActionResult> GetDseDropdown()
        {
            return Ok(await _repo.GetDseDropdown(UserHelper.GetUser(User)));
        }


        [HttpGet("GetSourceOfEnqDropdown")]
        public async Task<IActionResult> GetSourceOfEnqDropdown()
        {
            return Ok(await _repo.GetSourceOfEnqDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetSalesperBranch")]
        public async Task<IActionResult> GetSalesperBranch()
        {
            return Ok(await _repo.GetSalesperBranch(UserHelper.GetUser(User)));
        }

        [HttpGet("GetFinancialYearDropdown")]
        public async Task<IActionResult> GetFinancialYearDropdown()
        {
            return Ok(await _repo.GetFinancialYearDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetSalesIncentiveApplicationDesignationDropDown")]
        public async Task<IActionResult> GetSalesIncentiveApplicationDesignationDropDown()
        {
            return Ok(await _repo.GetSalesIncentiveApplicationDesignationDropDown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetTeamLeaderByBranchDropDown")]
        public async Task<IActionResult> GetTeamLeaderByBranchDropDown(int EmpCode)
        {
            return Ok(await _repo.GetTeamLeaderByBranchDropDown(UserHelper.GetUser(User),EmpCode));
        }
        [HttpGet("GetStockStatusDropdown")]
        public async Task<IActionResult> GetStockStatusDropdown()
        {
            return Ok(await _repo.GetStockStatusDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetMonthOrderUpdate")]
        public async Task<IActionResult> GetMonthOrderUpdate()
        {
            return Ok(await _repo.GetMonthOrderUpdate(UserHelper.GetUser(User)));
        }
        [HttpGet("GetMonthOBU")]
        public async Task<IActionResult> GetMonthOBU()
        {
            return Ok(await _repo.GetMonthOBU(UserHelper.GetUser(User)));
        }

        [HttpGet("GetMonthLeadEnquiry")]
        public async Task<IActionResult> GetMonthLeadEnquiry()
        {
            return Ok(await _repo.GetMonthLeadEnquiry(UserHelper.GetUser(User)));
        }
        [HttpGet("GetMonthSalesUpdate")]
        public async Task<IActionResult> GetMonthSalesUpdate()
        {
            return Ok(await _repo.GetMonthSalesUpdate(UserHelper.GetUser(User)));
        }



        [HttpGet("GetChannelDropdown")]
        public async Task<IActionResult> GetChannelDropdown()
        {
            return Ok(await _repo.GetChannelDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetAllRegionDropdown")]
        public async Task<IActionResult> GetAllRegionDropdown()
        {
            return Ok(await _repo.GetAllRegionDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetAllDMSMCARERegionWiseBranchDropdown")]
        public async Task<IActionResult> GetAllDMSMCARERegionWiseBranchDropdown(int Region)
        {
            return Ok(await _repo.GetAllDMSMCARERegionWiseBranchDropdown(UserHelper.GetUser(User), Region));
        }
        [HttpGet("GetAllSaleExecutives")]
        public async Task<IActionResult> GetAllSaleExecutives(int Region,int Branch)
        {
            return Ok(await _repo.GetAllSaleExecutives(UserHelper.GetUser(User),Region,Branch));
        }
        [HttpGet("GetAllModelDropdown")]
        public async Task<IActionResult> GetAllModelDropdown()
        {
            return Ok(await _repo.GetAllModelDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetPercarProfitMonthDropdown")]
        public async Task<IActionResult> GetPercarProfitMonthDropdown()
        {
            return Ok(await _repo.GetPercarProfitMonthDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetFinanceUpdateBranchDropdown")]
        public async Task<IActionResult> GetFinanceUpdateBranchDropdown()
        {
            return Ok(await _repo.GetFinanceUpdateBranchDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetFinancialYearMonthDropdown")]
        public async Task<IActionResult> GetFinancialYearMonthDropdown()
        {
            return Ok(await _repo.GetFinancialYearMonthDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetEnquiryFollowUpReportMonth")]
        public async Task<IActionResult> GetEnquiryFollowUpReportMonth()
        {
            return Ok(await _repo.GetEnquiryFollowUpReportMonth(UserHelper.GetUser(User)));
        }

        [HttpGet("GetDiscontinuedModelList")]
        public async Task<IActionResult> GetDiscontinuedModelList()
        {
            return Ok(await _repo.GetDiscontinuedModelList(UserHelper.GetUser(User)));
        }
        [HttpGet("GetModelGroupDropdown")]
        public async Task<IActionResult> GetModelGroupDropdown()
        {
            return Ok(await _repo.GetModelGroupDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetDiscontinuedModelListDropdown")]
        public async Task<IActionResult> GetDiscontinuedModelListDropdown()
        {
            return Ok(await _repo.GetDiscontinuedModelListDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetOrgMonthDropDown")]
        public async Task<IActionResult> GetOrgMonthDropDown()
        {
            return Ok(await _repo.GetOrgMonthDropDown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetMOnthwiseSalesDealerDropDown")]
        public async Task<IActionResult> GetMOnthwiseSalesDealerDropDown(int Month)
        {
            return Ok(await _repo.GetMOnthwiseSalesDealerDropDown(UserHelper.GetUser(User), Month));
        }
        
        [HttpGet("GetDseenquiryRegionWisebranchDropDown")]
        public async Task<IActionResult> GetDseenquiryRegionWisebranchDropDown(int Region)
        {
            return Ok(await _repo.GetDseenquiryRegionWisebranchDropDown(UserHelper.GetUser(User), Region));
        }
        [HttpGet("GetDashboardMonth")]
        public async Task<IActionResult> GetDashboardMonth()
        {
            return Ok(await _repo.GetDashboardMonth(UserHelper.GetUser(User)));
        }

        [HttpGet("GetTypeSTOCKDropdown")]
        public async Task<IActionResult> GetTypeSTOCKDropdown()
        {
            return Ok(await _repo.GetTypeSTOCKDropdown(UserHelper.GetUser(User)));
        }
        [HttpGet("GetAccessoriespartCategoryDropdown")]
        public async Task<IActionResult> GetAccessoriespartCategoryDropdown()
        {
            return Ok(await _repo.GetAccessoriespartCategoryDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetContinuedModelDropdown")]
        public async Task<IActionResult> GetContinuedModelDropdown()
        {
            return Ok(await _repo.GetContinuedModelDropdown(UserHelper.GetUser(User)));
        }

        [HttpGet("GetActiveModuleDropdown")]
        public async Task<IActionResult> GetActiveModuleDropdown()
        {
            return Ok(await _repo.GetActiveModuleDropdown(UserHelper.GetUser(User)));
        }
    }



}

