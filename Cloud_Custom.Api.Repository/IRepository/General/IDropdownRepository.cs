using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.General
{
   public interface IDropdownRepository
    {
        Task<List<Dropdown>> GetMonthTarget(UserBase user);
        Task<List<Dropdown>> GetTargetBranchDropdown(int? EmployeeCode, UserBase user);
        Task<List<Dropdown>> GetTargetRegionsettingsDropdown( UserBase user);
        Task<List<Dropdown>> GetTargetParameterDropDown(UserBase user);
        Task<List<Dropdown>> GetSeviceincentiveMonthToDropdown(UserBase user);
        Task<List<Dropdown>> GetSeviceincentiveMonthFromDropdown(UserBase user);
        Task<List<Dropdown>> GetServiceSettingsMonth(UserBase user);
        Task<List<Dropdown>> GetTargetRegionDropdown(UserBase user);
        Task<List<Dropdown>> GetGenderDropDown(UserBase user);
        Task<List<Dropdown>> GetIncentiveType(UserBase user);
        Task<List<Dropdown>> GetCategoryDropdown(UserBase user);
        Task<List<Dropdown>> GetMonthDMS(UserBase user);
        Task<List<Dropdown>> GetServiceIncentiveProcessingMonthDropDown(UserBase user);
        Task<List<Dropdown>> GetReportMonthDMS(UserBase user);
        Task<List<Dropdown>> GetGroubyDropDown(UserBase user);
        Task<List<Dropdown>> GetMonthToDropdown(UserBase user);
        Task<List<Dropdown>> GetMonthFromDropdown(UserBase user);
        Task<List<Dropdown>> GetParameterDropDown(UserBase user);
        Task<List<Dropdown>> GetAppoinmentDropdown(UserBase user);
        Task<List<Dropdown>> GetWorkshopDropdown(UserBase user,int? id);
        Task<List<Dropdown>> GetServiceIncentiveGroup(UserBase user);
        Task<List<Dropdown>> GetLabourTypeDropdown(UserBase user);
        Task<List<Dropdown>> GetLabourGroupDropdown(UserBase user);
        Task<List<Dropdown>> GetUserRoleDropdown(UserBase user);

        Task<List<Dropdown>> GetServiceGroupDropdown(UserBase user);
        Task<List<Dropdown>> GetServiceOilGroupDropdown(UserBase user);
        Task<List<Dropdown>> GetServiceAccessoriesGroupDropdown(UserBase user);
        Task<List<Dropdown>> GetServiceIncentiveGroupSpecial(UserBase user);
        Task<List<Dropdown>> GetMonthDMSincentiveProcessed(UserBase user);
        Task<List<Dropdown>> GetMonthDMSSettings(UserBase user);
        Task<List<Dropdown>> GetLocationDropdown(UserBase user);
        Task<List<Dropdown>> GetStateDropDown(int? CountryCode, UserBase user);
        Task<List<Dropdown>> GetGradeDropdown(UserBase user);
        Task<List<Dropdown>> GetPayrollGroupDropdown(UserBase user);
        Task<List<Dropdown>> GetDepartmentDropdown(UserBase user);
        Task<List<Dropdown>> GetDesignationDropdown(UserBase user);
        Task<List<Dropdown>> GetSectionDropdown(UserBase user);
        Task<List<Dropdown>> GetDivisionDropdown(UserBase user);
        Task<List<Dropdown>> GetWorkLocationDropdown(UserBase user);
        Task<List<Dropdown>> GetWageGradeDropdown(UserBase user);
        Task<List<Dropdown>> GetEmploymentStatusDropdown(UserBase user);
        Task<List<Dropdown>> GetEmploymentTypeDropdown(UserBase user);
        Task<List<Dropdown>> GetPaySheetTypeDropDown(UserBase user);
        Task<List<Dropdown>> GetPaysheetDraftMonthDropdown(UserBase user);
        Task<List<Dropdown>> GetMenuSearchDropdown(UserBase user, string LoginFrom);
        Task<List<Dropdown>> GetAttendanceProcessedMonthDropdown(UserBase user);
        Task<List<Dropdown>> GetAttendanceStatusDropdown(UserBase user);
        //Task<List<Dropdown>> GetPaymentModeDropDown(UserBase user);
        Task<List<Dropdown>> GetPaymentModeDropdown(UserBase user);


        Task<List<Dropdown>> GetRegionDropdown(UserBase user);
        Task<List<Dropdown>> GetPayrollReportMonthDropdown(UserBase user);
        Task<List<Dropdown>> GetTypeDropdown(UserBase user);
        Task<List<Dropdown>> GetTypeVsOthersDropdown(UserBase user);
        Task<List<Dropdown>> GetBayTypeDropdown(UserBase user);
        Task<List<Dropdown>> GetDealerDropdown(UserBase user);
        Task<List<Dropdown>> GetWorkShopTypeDropdown(UserBase user);
        Task<List<Dropdown>> GetDealerCityDropdown(UserBase user);
        Task<List<Dropdown>> GetDepartmentTypeDropdown(UserBase user);
        Task<List<Dropdown>> GetAgeDropdown(UserBase user);
        Task<List<Dropdown>> GetBranchstateDropdown(UserBase user);
        Task<List<Dropdown>> GetBranchRegionDropdown(UserBase user);
        Task<List<Dropdown>> GetMonthDropdown(UserBase user);
        Task<List<Dropdown>> GetBranchWiseIncentiveRegionDropdown(UserBase user);
        Task<List<Dropdown>> GetIncentiveDropdown(UserBase user);
        Task<List<Dropdown>> GetTeamLeaderDropdown(UserBase user);
        Task<List<Dropdown>> GetDSEEmployeeDropdown(UserBase user);
        Task<List<Dropdown>> GetWHLocationDropdown(UserBase user);
        Task<List<Dropdown>> GetStoreManagerDropDown(UserBase user);
        Task<List<Dropdown>> GetEmployeePositionDropDown(UserBase user);
        Task<List<Dropdown>> GetFuelTypeList(UserBase user);
        Task<List<Dropdown>> GetTransmissionTypeList(UserBase user);
        Task<List<Dropdown>> GetWorkshopDropDownList(UserBase user);
        Task<List<Dropdown>> GetServiceIncentiveGroupType(UserBase user);
        Task<List<Dropdown>> GetServiceDropdown(UserBase user);
        Task<List<Dropdown>> GetTeamIncentiveGroupDropdown(UserBase user);
        Task<List<Dropdown>> GetTeamTargetEmployeeDropdown(UserBase user, int BranchCode);
        Task<List<Dropdown>> GetServiceIncentiveRolereport(UserBase user, int Month, int region);
        Task<List<Dropdown>> GetServiceIncentiveRoleBranchDropdown(UserBase user, int Month, int region,int IncentiveGroup);
        Task<List<Dropdown>> GetServiceBranchDropdown(UserBase user);
        Task<List<Dropdown>> GetBranchTargetEmployeeDropdown(UserBase user);
        Task<List<Dropdown>> GetRegionTargetEmployeeDropdown(UserBase user);

        Task<List<Dropdown>> GetMcarePlanDropdown(UserBase user);
        Task<List<Dropdown>> GetMcareActivePlanDropdown(UserBase user);
        Task<List<Dropdown>> GetCalculationTypeDropdown(UserBase user);
        Task<List<Dropdown>> GetServiceAdvisorDropDown(UserBase user, int? id);
        Task<List<Dropdown>> GetWorkshopregionDropDown(UserBase user, int? id);
        Task<List<Dropdown>> GetTaxDropdown(UserBase user);

        #region SalaryProcessing
        Task<List<Dropdown>> GetSalaryProcessing_MonthDropdown(UserBase user, int? PayrollGroupCode);
        Task<List<Dropdown>> GetSalaryProcessingAttenLockMonthDropdown(UserBase user, int? PayrollGroupCode);
        Task<List<Dropdown>> GetSalaryProcessedMonth_Dropdown(UserBase user, int? PayrollGroupCode);
        #endregion

        #region LEAVE ENCASH                
        Task<List<Dropdown>> GetLeaveGroupFilterDropdown(UserBase user);
        Task<List<Dropdown>> GetLeaveEncashment_LeaveDropdown(UserBase user);
        Task<List<Dropdown>> GetLeavePeriodFilterDropdown(UserBase user);
        Task<List<Dropdown>> GetLeaveEncashmentHistory_MonthDropdown(UserBase user,int LeavePeriod);
        #endregion
        #region Monthly_AttendanceProcessing
        Task<List<Dropdown>> GetMonthly_AttendanceProcessing_MonthDropdown(UserBase user,int? PayrollGroupCode);
        #endregion
        Task<List<Dropdown>> GetPerformanceAllowanceDropdown(UserBase user);
        Task<List<Dropdown>> GetDMSBranchDropdown(UserBase user);
        Task<List<Dropdown>> GetBranchDropdown(UserBase user);
        Task<List<Dropdown>> GetDMSMODELDropdown(UserBase user);
        Task<List<Dropdown>> GetTypeVSMODELDropdown(UserBase user,int Type);
        Task<List<Dropdown>> GetDMSEMPLOYEEDropdown(UserBase user);
        Task<List<Dropdown>> GetEMPLOYEEvsLocationDropdown(UserBase user, int LocationCode);
        Task<List<Dropdown>> GetEMPLOYEEandLOCATIONDropdown(UserBase user);
        Task<List<Dropdown>> GetEmployeeBranchDropdown(UserBase user);
        #region IncentiveSettings    
        Task<List<Dropdown>> GetSalesDesignationDropdown(UserBase user);
        #endregion
        #region CRM    
        Task<List<Dropdown>> GetSaleExecutives(UserBase user);
        Task<List<Dropdown>> GetVariant(UserBase user, int Model);

        Task<List<Dropdown>> GetVariantList(UserBase user);

        Task<List<Dropdown>> GetBankList(UserBase user);

        Task<List<Dropdown>> GetPayModeList(UserBase user);
        Task<List<Dropdown>> GetColorList(UserBase user);
        Task<List<Dropdown>> GetMonthCRM(UserBase user);
        Task<List<Dropdown>> GetYearsList(UserBase user);
        Task<List<Dropdown>> GetInsuranceTypeList(UserBase user);
        Task<List<Dropdown>> GetInsuranceCompanyList(UserBase user);

        //Task<List<Dropdown>> GetIncentiveDropdown(UserBase user);

        Task<List<Dropdown>> GetRemarksList(UserBase user);
        Task<List<Dropdown>> GetDMSSoureOfEnqDropDown(UserBase user);
        Task<List<Dropdown>> GetAccessoriesList(UserBase user, int Model);
        #endregion

        #region TestDrive
        Task<List<Dropdown>> GetTimeDropdown(UserBase user);
        Task<List<Dropdown>> GetPurchaseTimeDropdown(UserBase user);
        Task<List<Dropdown>> GetCustomerList(UserBase user);
        Task<List<Dropdown>> Getvehicle(UserBase user);
        #endregion
        Task<List<Dropdown>> GetBatchCode(UserBase user);

        Task<List<Dropdown>> GetDMSLeadTypeDropdown(UserBase user);

        Task<List<Dropdown>> GetWareHouseropdown(UserBase user);
        Task<List<Dropdown>> GetAllotmentStatus(UserBase user);
        Task<List<Dropdown>> GetFinancier(UserBase user);
        Task<List<Dropdown>> GetDmsDistrictDropdown(UserBase user);
        Task<List<Dropdown>> GetDistrictDropdown(UserBase user, int State);

        Task<List<Dropdown>> GetAllotmentDropDown(UserBase user,int Model,int variant);

        Task<List<Dropdown>> GetRtoOffice(UserBase user, int State, int District);
        Task<List<Dropdown>> GetRegistrationType(UserBase user);
        Task<List<Dropdown>> GetRegistrationCategory(UserBase user);
        Task<List<Dropdown>> GetParameterChecked(UserBase user, int designationCode);
        Task<List<Dropdown>> GetDMSStatusDropdown(UserBase user);
        Task<List<Dropdown>> GetServiceTypeDropdown(UserBase user);
        Task<List<Dropdown>> GetYesOrNoDropdown(UserBase user);
        Task<List<Dropdown>> GetTimeSlotDropDown(UserBase user);
        Task<List<Dropdown>> GetCallStatusropdown(UserBase user);
        Task<List<Dropdown>> GetTypeDmsDropdown(UserBase user,string Tab);
        Task<List<Dropdown>> GetMonthServiceDMS(UserBase user, string Tab);
        Task<List<Dropdown>> GetDMSRegionDropdown(UserBase user);
        Task<List<Dropdown>> GetDMSBranchwiseDropdown(UserBase user);

        Task<List<Dropdown>> GetTeamLeaderByDeptAndPosition(UserBase user, int departmentCode, int positionCode);
        Task<List<Dropdown>> GetEmployeePositionByDepartment(UserBase user, int departmentCode);
        Task<List<Dropdown>> GetDMSBranchByDepartment(UserBase user, int departmentCode);
        Task<List<Dropdown>> GetIncentiveByDepartment(UserBase user, int departmentCode);
        Task<List<Dropdown>> GetSalesDesignationByDepartment(UserBase user, int departmentCode);
        Task<List<Dropdown>> GetBayDropDown(UserBase user, int? WorkShopCode);
        Task<List<Dropdown>> GetWorkshopReportDropDown(UserBase user);
        Task<List<Dropdown>> GetDriverListDropDown(UserBase user);
        Task<List<Dropdown>> GetIncentiveBasedonDropdown(UserBase user);

        Task<List<Dropdown>> GetTech(UserBase user, int? WorkShopCode);
        Task<List<Dropdown>> GetJobCard(UserBase user, int? WorkShopCode, int? JobCardNo);
        Task<List<Dropdown>> GetBayJobDropDown(UserBase user, int WorkShopCode, int Bay);
        Task<List<Dropdown>> GetBayTechDropDown(UserBase user, int WorkShopCode, string Date, int techcode);
        Task<List<Dropdown>> GetRegNoDropDown(UserBase user, int? WorkShopCode);
        Task<List<Dropdown>> GetIncentiveGroupBasedonDropdown(UserBase use);
        Task<List<Dropdown>> GetBranchTargetIncentiveDropdown(UserBase use);
        Task<List<Dropdown>> GetOnlyThreeMonthDropdown(UserBase user);

        Task<List<Dropdown>> GetParameterByGroupDropDown(UserBase user, int IncentiveGroup);
        Task<List<Dropdown>> GetTargetBranchssDropdown(UserBase use, int IncentiveGroupCode);
        Task<List<Dropdown>> GetTeamTargetEmployeessDropdown(UserBase use, int BranchCode, int IncentiveGroupCode);
        Task<List<Dropdown>> GetDMSBranchwiseRegionDropdown(UserBase user, int Branch);
        Task<List<Dropdown>> GetOutSourceWorkCombofill(UserBase user);
        Task<List<Dropdown>> getpendingBayJOBdropdown(UserBase user, int WorkShopCode,int BayCode);
        Task<List<Dropdown>> GetWarrentyPlanDropdown(UserBase use);
        Task<List<Dropdown>> GetWorkShopAdvisor(UserBase use,int WorkShopCode );







        #region MOBILE APP
        Task<List<Dropdown>> GetWorkShopMobileDropdown(UserBase user);
        Task<List<Dropdown>> GetJobCardStatusDropDown(UserBase user);
        #endregion

        Task<List<Dropdown>> GetAllotmentVariantDropdown(UserBase use,int Status,int Model);
        Task<List<Dropdown>> GetAllotmentModelDropdown(UserBase use,int Status);
        Task<List<Dropdown>> GetDMSUserRoleDropdown(UserBase user);
        Task<List<Dropdown>> GetEmployeeNotInUserDropdown(UserBase user);

        #region  ValuePassingDROPDOWN

        Task<List<Dropdown>> GetMonthWorkShop(UserBase use, int WorkShopCode);

        Task<List<Dropdown>> GetRegionEDDropdown(UserBase user);
        Task<List<Dropdown>> GetWorkshopFSDropDown(UserBase user);
        Task<List<Dropdown>> GetWorkshopBayMovementDropDown(UserBase user);


        #endregion
        Task<List<Dropdown>> GetModelVariantvsColorDropdown(UserBase user, int Model, int Varient);

        Task<List<Dropdown>> GetSecurity(UserBase user, int WorkShopCode);
        Task<List<Dropdown>> GetMCarePlanDropdown(UserBase user);
        Task<List<Dropdown>> GetMCareRegistrationStatusDropdown(UserBase user);

        Task<List<Dropdown>> GetMCareDuration(UserBase user);
        Task<List<Dropdown>> GetModelVariantBranch(UserBase user);



        Task<List<Dropdown>> GetSeviceAchivementvsTarget_MonthDropdown(UserBase user);

        Task<List<Dropdown>> GetSeviceAchivementvsTarget_ParameterDropdown(UserBase user);
        Task<List<Dropdown>> GetSeviceAchivementvsTarget_RegionDropdown(UserBase user);
        Task<List<Dropdown>> GetEmployeeVSTargetReport_BranchDropdown(UserBase user);
        Task<List<Dropdown>> GetEmployeeVSTargetReport_MonthDropdown(UserBase user);
        Task<List<Dropdown>> GetEmployeeVSTargetReport_ParameterDropdown(UserBase user);
        Task<List<Dropdown>> GetEmployeeVSTargetReport_RegionDropdown(UserBase user);
        Task<List<Dropdown>> GetAllotmentColorDropdown(UserBase user,int Status, int Model, int Varient);

        Task<List<Dropdown>> GetSalesBranchDropdown(UserBase user);
        Task<List<Dropdown>> GetSalesVarientDropdown(UserBase user);

        Task<List<Dropdown>> GetMCareServiceAdvisorDropDown(UserBase user, int? id);

        Task<List<Dropdown>> GetSalesBranch(UserBase user);

        Task<List<Dropdown>> GetModeOfPaymentDropdown(UserBase user);
        Task<List<Dropdown>> GetDMSRegionWiseBranchDropdown(UserBase user ,int BranchCode);
        Task<List<Dropdown>> GetMcareCancelPaymentModeDropdown(UserBase user);
        Task<List<Dropdown>> GetMcareCancellationReasonDropDown(UserBase user);
        Task<List<Dropdown>> GetServiceAdvisorMobileDropdown(UserBase use, int WorkshopCode);
        Task<List<Dropdown>> GetMcareServiceDropdown(UserBase use);

        Task<List<Dropdown>> GetSourceEnquiryDrodown(UserBase use);
        Task<List<Dropdown>> GetServiceAdvisorLoadDropdown(UserBase user, int Month, int Region, int branch);
        Task<List<Dropdown>> GetNewServiceAdvisorDropdown(UserBase user, int Month, int Region, int branch);
        Task<List<Dropdown>> GetServiceAdvisorLabourDropdown(UserBase user, int Month, int Region, int branch);
        Task<List<Dropdown>> GetServiceAdvisorMGADropdown(UserBase user, int Month, int Region, int branch);
        Task<List<Dropdown>> GetLoadMonthDropdown(UserBase user);
        Task<List<Dropdown>> GetLabourRegionDropdown(UserBase user);
        Task<List<Dropdown>> GetLabourMonthDropdown(UserBase user);
        Task<List<Dropdown>> GetLoadRegionDropdown(UserBase user);
        Task<List<Dropdown>> GetLoadRegionWiseBranchDropdown(UserBase user, int BranchCode);
        Task<List<Dropdown>> GetMcareregModel(UserBase use);
        Task<List<Dropdown>> GetModelSegment(UserBase use);
        Task<List<Dropdown>> GetModuleDropdown(UserBase use);
        Task<List<Dropdown>> GetOutletModel(UserBase use);
        Task<List<Dropdown>> GetOutletEnquiryDropDown(UserBase use);

        Task<List<Dropdown>> GetColdFollowUpStatusDropdown(UserBase user);
        Task<List<Dropdown>> GetLabourRegionWiseBranchDropdown(UserBase user, int RegionCode, int MonthCode);
        Task<List<Dropdown>> GetDsewithiddropdown(UserBase user, int branch, int Region);
        Task<List<Dropdown>> GetEmployeeDesignationDropdown(UserBase user, int DesignationCode);
        Task<List<Dropdown>> GetBranchWiseEmployeeDropdown(UserBase user, int BarnchCode);
        Task<List<Dropdown>> GetTeamManagerWiseEnquiryStatusEnquiryDropDown(UserBase user);
        Task<List<Dropdown>> GetTeamManagerWiseEnquiryStatusModelDropDown(UserBase user);
        Task<List<Dropdown>> GetTeamManagerWiseEnquiryStatusMonthDropDown(UserBase user);
        Task<List<Dropdown>> GetSalesDateDropdown(UserBase user, DateTime FromDate, DateTime ToDate);
        Task<List<Dropdown>> GetDMSMCARERegionWiseBranchDropdown(UserBase user, int BranchCode);
        Task<List<Dropdown>> GetSeniorRegionalManagerDropdown(UserBase user);
        Task<List<Dropdown>> GetPlanNotSetMODELDropdown(UserBase user);
        Task<List<Dropdown>> GetSalesMonthDropdown(UserBase user);
        Task<List<Dropdown>> GetServiceAchivementAdjustmentIncentiveRoleDropdown(UserBase user);
        Task<List<Dropdown>> GetServiceAchivementAdjustmentMonthDropdown(UserBase user);
        Task<List<Dropdown>> GetServiceAchivementAdjustmentBRANCHDropdown(UserBase user, int Monthcode);
        Task<List<Dropdown>> GetModelDropdown(UserBase use);
        Task<List<Dropdown>> GetTlDropdown(UserBase use);
        Task<List<Dropdown>> GetDseDropdown(UserBase use);
        Task<List<Dropdown>> GetSourceOfEnqDropdown(UserBase use);
        Task<List<Dropdown>> GetSalesperBranch(UserBase user);
        Task<List<Dropdown>> GetFinancialYearDropdown(UserBase user);
        Task<List<Dropdown>> GetSalesIncentiveApplicationDesignationDropDown(UserBase user);
        Task<List<Dropdown>> GetTeamLeaderByBranchDropDown(UserBase user,int EmpCode);
        Task<List<Dropdown>> GetMonthOrderUpdate(UserBase user);
        Task<List<Dropdown>> GetMonthOBU(UserBase user);
        Task<List<Dropdown>> GetMonthLeadEnquiry(UserBase user);
        Task<List<Dropdown>> GetMonthSalesUpdate(UserBase user);
        Task<List<Dropdown>> GetStockStatusDropdown(UserBase user);
        Task<List<Dropdown>> GetChannelDropdown(UserBase user);
        Task<List<Dropdown>> GetAllModelDropdown(UserBase user);
        Task<List<Dropdown>> GetAllSaleExecutives(UserBase user,int Region,int Branch);
        Task<List<Dropdown>> GetAllDMSMCARERegionWiseBranchDropdown(UserBase user, int Region);
        Task<List<Dropdown>> GetAllRegionDropdown(UserBase user);
        Task<List<Dropdown>> GetPercarProfitMonthDropdown(UserBase user);
        Task<List<Dropdown>> GetFinanceUpdateBranchDropdown(UserBase user);
        Task<List<Dropdown>> GetFinancialYearMonthDropdown(UserBase user);
        Task<List<Dropdown>> GetEnquiryFollowUpReportMonth(UserBase user);
        Task<List<Dropdown>> GetDiscontinuedModelList(UserBase user);
        Task<List<Dropdown>> GetModelGroupDropdown(UserBase user);
        Task<List<Dropdown>> GetDiscontinuedModelListDropdown(UserBase user);
        Task<List<Dropdown>> GetOrgMonthDropDown(UserBase user);
        Task<List<Dropdown>> GetMOnthwiseSalesDealerDropDown(UserBase user, int Month);
        Task<List<Dropdown>> GetDseenquiryRegionWisebranchDropDown(UserBase user, int Region);
        Task<List<Dropdown>> GetDashboardMonth(UserBase user);
        Task<List<Dropdown>> GetTypeSTOCKDropdown(UserBase user);
        Task<List<Dropdown>> GetAccessoriespartCategoryDropdown(UserBase user);

        Task<List<Dropdown>> GetContinuedModelDropdown(UserBase user);
        Task<List<Dropdown>> GetActiveModuleDropdown(UserBase user);

    }
}
