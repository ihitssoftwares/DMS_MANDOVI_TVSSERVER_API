using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.General;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.General
{
    public class DropdownRepository : IDropdownRepository
    {
        private ISqlConnectionProvider _sql;

        public DropdownRepository(ISqlConnectionProvider sqlConnectionProvider)
        {
            this._sql = sqlConnectionProvider;
        }
        public async Task<List<Dropdown>> GetCategoryDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =

          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_CATEGORY_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetTargetBranchDropdown(int? EmployeeCode, UserBase user)
        {
            IDbDataParameter[] sqlParameters =
       {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@EmployeeCode",EmployeeCode)
                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_INCENTIVE_TARGET_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);

            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetTargetRegionsettingsDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
       {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_TARGET_REGION_SETTINGS_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);

            return PopulateDropDownDetails(dataTable);
        }

        ///commit conflicted remedy
        ///
        public async Task<List<Dropdown>> GetServiceTypeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_TYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetUserRoleDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_USERROLE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetMonthDMS(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetServiceIncentiveProcessingMonthDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_INCENTIVE_PROCESSING_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetReportMonthDMS(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetGroubyDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetAppoinmentDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_APPOINMENT_STATUS_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetMonthToDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_TO_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetMonthFromDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_FROM_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetServiceSettingsMonth(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetSeviceincentiveMonthToDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetSeviceincentiveMonthFromDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetMonthTarget(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_TARGET_SETTINGS_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetTargetParameterDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_TARGET_PARAMETER_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetTargetRegionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_TARGET_REGION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetParameterDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_PARAMETER_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetWorkshopDropdown(UserBase user, int? id)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@id",id)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_WORKSHOP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetAgeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_AGEINGBUCKET_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetServiceIncentiveGroupSpecial(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_SPECIAL_GROUP_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetServiceIncentiveGroup(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_INCENTIVE_GROUP_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetDepartmentDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_DEPARTMENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetDesignationDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_DESIGNATION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetMonthDMSincentiveProcessed(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_DROPDOWN_INCENTIVE_PROCESSED]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetMonthDMSSettings(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_DROPDOWN_INCENTIVE_SETTINGS_MONTH]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetDivisionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_DIVISION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetLocationDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_LOCATION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);

        }
        public async Task<List<Dropdown>> GetEmploymentStatusDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_DEPARTMENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetEmploymentTypeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
         {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_DEPARTMENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetGenderDropDown(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlParameters =
                {
                    new SqlParameter("@CompanyGI",user.CompanyGuid),
                    new SqlParameter("@UserGI",user.UserGuid)
                };
                var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GENDER_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
                return PopulateDropDownDetails(dataTable);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<List<Dropdown>> GetIncentiveType(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlParameters =
                {
                    new SqlParameter("@CompanyGI",user.CompanyGuid),
                    new SqlParameter("@UserGI",user.UserGuid)
                };
                var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_INCENTIVE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
                return PopulateDropDownDetails(dataTable);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<List<Dropdown>> GetGradeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_GRADE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetParameterChecked(UserBase user, int designationCode)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@designationCode",designationCode)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_PARAMETER_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetPayrollGroupDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_PAYROLL_GROUP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetSectionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_SECTION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetStateDropDown(int? CountryCode, UserBase user)
        {
            IDbDataParameter[] sqlParameters =
       {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@CountryCode",CountryCode??null)
                };
            var dataTable = await _sql.GetDataTableAsync("[FIXED].[SP_STATE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetWageGradeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
         {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_WAGEGRADE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetWorkLocationDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
         {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_WORKLOCATION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetAttendanceStatusDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_ATTENDANCE_STATUS_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetMenuSearchDropdown(UserBase user, string LoginFrom)
        {
            try
            {
                IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@LoginFrom",LoginFrom),
            };
                var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_MENU_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
                return PopulateDropDownDetails(dataTable);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }

        }
        public async Task<List<Dropdown>> GetPaySheetTypeDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI),
                };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_PAY_SHEET_TYPE_COMBO]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetPaysheetDraftMonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI),
                };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_PAYSHEET_DRAFT_MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetAttendanceProcessedMonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid), new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_ATTENDANCE_PROCESSED_MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
      //  public async Task<List<Dropdown>> GetPaymentModeDropDown(UserBase user)
      //  {
      //      IDbDataParameter[] sqlParameters =
      //{
      //          new SqlParameter("@CompanyGI",user.CompanyGuid),
      //          new SqlParameter("@UserGI",user.UserGuid)
      //      };
      //      var dataTable = await _sql.GetDataTableAsync("[FIXED].[SP_PAYMENT_MODE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
      //      return PopulateDropDownDetails(dataTable);
      //  }
        public async Task<List<Dropdown>> GetPayrollReportMonthDropdown(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                  new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI),
            };
                var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_PAYROLL_REPORTS_MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
                return PopulateDropDownDetails(dataTable);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }

        }

        public async Task<List<Dropdown>> GetRegionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_REGION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetTypeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_TYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetTypeVsOthersDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_TYPE_OTHERS_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetBayTypeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_BAY_TYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetDealerDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_Dealer_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetBranchWiseIncentiveRegionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_REGION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetDealerCityDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_DEALERCITY_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetBranchstateDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_BRANCHSTATE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetBranchRegionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_BRANCHREGION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetMonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GetMonthDropdown_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetIncentiveDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GetIncentiveDropdown_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetServiceIncentiveGroupType(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GetServiceIncentiveGroupType_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetTeamLeaderDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_Get_TeamLeader_Dropdown_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetDSEEmployeeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_Get_DSEEmployee_Dropdown_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetWorkShopTypeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_WORKSHOPTYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetDepartmentTypeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_DEPARTMENTTYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetWHLocationDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_WH_Location_Dropdown_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetStoreManagerDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_WH_STORE_MANAGER_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetEmployeePositionDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_EMPLOYEE_POSITION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetFuelTypeList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_FUEL_TYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetTransmissionTypeList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_TRANSMISSION_TYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetWorkshopDropDownList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_WORKSHOPS_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetDMSStatusDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_MCP_STATUS_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        #region SalaryProcessing
        public async Task<List<Dropdown>> GetSalaryProcessing_MonthDropdown(UserBase user, int? PayrollGroupCode)
        {
            try
            {
                IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",user.CompanyGuid),  new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI),
                new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@PAYROLLGROUP",PayrollGroupCode)

            };
                var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_SALARY_PROCESSING_MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
                return PopulateDropDownDetails(dataTable);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<List<Dropdown>> GetSalaryProcessedMonth_Dropdown(UserBase user, int? PayrollGroupCode)
        {

            try
            {
                IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@PayrollGroup",PayrollGroupCode),
                new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI)
            };
                var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_GET_SALARY_PROCESSED _MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
                return PopulateDropDownDetails(dataTable);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }

        }
        public async Task<List<Dropdown>> GetSalaryProcessingAttenLockMonthDropdown(UserBase user, int? PayrollGroupCode)
        {
            try
            {
                IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",user.CompanyGuid),  new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI),
                new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@PAYROLLGROUP",PayrollGroupCode)

            };
                var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_SALARY_PROCESSING_ATTENDANCE_LOCK_MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
                return PopulateDropDownDetails(dataTable);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        #endregion

        #region ENCASH
        public async Task<List<Dropdown>> GetLeaveGroupFilterDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_LEAVE_GROUP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetLeavePeriodFilterDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_LEAVE_PERIOD_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetLeaveEncashment_LeaveDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_LEAVE_ENCASHMENT_LEAVE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetLeaveEncashmentHistory_MonthDropdown(UserBase user, int LeavePeriod)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@LeavePeriod",LeavePeriod)
            };
            var dataTable = await _sql.GetDataTableAsync("[CUSTOM].[SP_LEAVE_ENCASHMENT_HISTORY_MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        #endregion
        #region Monthly_AttendanceProcessing
        public async Task<List<Dropdown>> GetMonthly_AttendanceProcessing_MonthDropdown(UserBase user, int? PayrollGroupCode)
        {
            try
            {
                IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@PAYROLLGROUP",PayrollGroupCode),
                  new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI),
            };
                var dataTable = await _sql.GetDataTableAsync("[HRMS].[SP_MONTHLY_ATTENDANCE_PROCESSING_MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
                return PopulateDropDownDetails(dataTable);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        #endregion
        public async Task<List<Dropdown>> GetPerformanceAllowanceDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[CUSTOM].[SP_PERFOMANCE_ALLOWANCE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetDMSBranchDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetBranchDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_GET_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetTaxDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TAX_TYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetDMSMODELDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MODEL_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetTypeVSMODELDropdown(UserBase user,int Type)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                 new SqlParameter("@Type",Type),
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TypeVsMODEL_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetEmployeeBranchDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_EMPLOYEE_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetDMSEMPLOYEEDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_EMPLOYEE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetEMPLOYEEvsLocationDropdown(UserBase user, int LocationCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                 new SqlParameter("@LocationCode",LocationCode)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_EMPLOYEE_VS_LOCATION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetEMPLOYEEandLOCATIONDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_EMPLOYEE_AND_LOCATION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetTeamTargetEmployeeDropdown(UserBase user, int BranchCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                 new SqlParameter("@BranchCode",BranchCode)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TEAM_TARGET_EMPLOYEE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetServiceIncentiveRolereport(UserBase user, int Month, int region)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                 new SqlParameter("@monthCode",Month),
                  new SqlParameter("@regionCode",region)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_GetServiceIncentiveGroup_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetServiceIncentiveRoleBranchDropdown(UserBase user, int Month, int region, int IncentiveGroup)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                 new SqlParameter("@monthCode",Month),
                  new SqlParameter("@regionCode",region),
                  new SqlParameter("@incnetiveGroupCode",IncentiveGroup),
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_GetBranch_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetTeamIncentiveGroupDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TEAM_TARGET_INCENTIVEGROUP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetServiceBranchDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetBranchTargetEmployeeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_BRANCH_TARGET_EMPLOYEE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetRegionTargetEmployeeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_REGION_TARGET_EMPLOYEE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetCalculationTypeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_CALCULATION_TYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetWorkshopregionDropDown(UserBase user, int? id)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@id",id)

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_WORKSHOP_REGION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetServiceAdvisorDropDown(UserBase user, int? id)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@id",id)
                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_ADVISOR_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        private List<Dropdown> PopulateDropDownDetails(DataTable dt)
        {

            List<Dropdown> DropList = new List<Dropdown>();
            foreach (DataRow dr in dt.Rows)
            {
                DropList.Add(new Dropdown
                {
                    Code = MakeSafe.ToSafeInt32(dr["Code"]),
                    Name = MakeSafe.ToSafeString(dr["Name"])
                });
            }
            return DropList;
        }

        #region IncentiveSettings    
        public async Task<List<Dropdown>> GetSalesDesignationDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
        {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SALES_DESIGNATION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        #endregion
        #region CRM    
        public async Task<List<Dropdown>> GetSaleExecutives(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SALES_EXECUTIVES_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetVariant(UserBase user, int Model)
        {
            IDbDataParameter[] sqlParameters =
            {

                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@Model",Model)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_MODEL_VARIANT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetPaymentModeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_PAYMENT_TYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetVariantList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_VARIANT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetMcarePlanDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GETMCAREPLANDROPDOWN_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetBankList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_BANK_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetPayModeList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_PAYMODE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetColorList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_COLOR_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetRemarksList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GetGetRemarksDropDown_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetDMSSoureOfEnqDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GetGetDMSSoureOfEnqDropDown_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetMonthCRM(UserBase user)

        {
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_CRM_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetYearsList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_CRM_INSURANCE_YEARS_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetInsuranceTypeList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_CRM_INSURANCE_TYPE_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetInsuranceCompanyList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_CRM_INSURANCE_COMPANY_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetAccessoriesList(UserBase user, int Model)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@Model",Model)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_CRM_ACCESSORIES_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        #endregion
        #region TestDrive
        public async Task<List<Dropdown>> GetTimeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_Time_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetPurchaseTimeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_PURCHASE_TIME_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetCustomerList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_CUSTOMER_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> Getvehicle(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_VEHICLE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        #endregion
        public async Task<List<Dropdown>> GetDMSLeadTypeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_LEAD_TYPE_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetWareHouseropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GetWareHouseropdown_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetServiceDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GetServiceDropdown_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetAllotmentStatus(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GetAllotmentStatusCOMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetFinancier(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_FINANCIER_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetAllotmentDropDown(UserBase user, int Model, int variant)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@Model",Model),
                new SqlParameter("@Variant",variant)

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GetAllotmentDropDownCOMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetBatchCode(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlParameters =
                {
                    new SqlParameter("@CompanyGI",user.CompanyGuid),
                    new SqlParameter("@UserGuid",user.UserGuid)
                };
                var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GET_BATCHCODE_LIST]", sqlParameters, CommandType.StoredProcedure);
                return PopulateDropDownDetails(dataTable);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<List<Dropdown>> GetDmsDistrictDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
               


                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GET_DISTRICT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetDistrictDropdown(UserBase user, int State)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@StateCode",State),


                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GET_DISTRICT_BY_STATE]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetRtoOffice(UserBase user, int State, int District)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGI", user.UserGuid),
        new SqlParameter("@StateCode",State),
        new SqlParameter("@DistrictCode",District),
    };

            var dataTable = await _sql.GetDataTableAsync(
                "[DMS].[SP_RTO_OFFICE_COMBOFILL]",
                sqlParameters,
                CommandType.StoredProcedure
            );

            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetRegistrationType(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGI", user.UserGuid)
    };

            var dataTable = await _sql.GetDataTableAsync(
                "[DMS].[SP_REGISTRATION_TYPE_COMBOFILL]",
                sqlParameters,
                CommandType.StoredProcedure
            );

            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetRegistrationCategory(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGI", user.UserGuid)
    };

            var dataTable = await _sql.GetDataTableAsync(
                "[DMS].[SP_REGISTRATION_CATEGORY_COMBOFILL]",
                sqlParameters,
                CommandType.StoredProcedure
            );

            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetYesOrNoDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_DECISIONMAKING_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetTimeSlotDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_TIMESLOT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetCallStatusropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_CALLSTATUS_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetTypeDmsDropdown(UserBase user, string Tab)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@ParticularTypeCode",Tab),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_FILTER_TYPE]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetMonthServiceDMS(UserBase user, string Tab)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@ParticularTypeCode",Tab),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GET_SERVICE_DASHBOARD_MONTH_COMBO]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetDMSRegionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_REGION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetDMSBranchwiseDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_LOCATIONWISE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetTeamLeaderByDeptAndPosition(UserBase user, int departmentCode, int positionCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@DepartmentCode",departmentCode),
        new SqlParameter("@positionCode",positionCode)
            };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_TEAMLEADER_BY_DEPARTMENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetEmployeePositionByDepartment(UserBase user, int departmentCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@DepartmentCode",departmentCode)
              };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_EMPLOYEE_POSITION_BY_DEPARTMENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetDMSBranchByDepartment(UserBase user, int departmentCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@DepartmentCode",departmentCode)
              };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_BRANCH_BY_DEPARTMENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetIncentiveByDepartment(UserBase user, int departmentCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@DepartmentCode",departmentCode)
              };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_INCENTIVE_BY_DEPARTMENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetSalesDesignationByDepartment(UserBase user, int departmentCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@DepartmentCode",departmentCode)
             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SALES_DESIGNATION_BY_DEPARTMENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetBayDropDown(UserBase user, int? WorkShopCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@WorkShopCode",WorkShopCode)
             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_BAY_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetLabourTypeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_LABOURTYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetLabourGroupDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_LABOURGROUP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetServiceGroupDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICEGROUP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetServiceOilGroupDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVICEOILGROUP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetServiceAccessoriesGroupDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_SERVIVESACCESSORIESGROUP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetWorkShopMobileDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_MOBILE_WORKSHOP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetWorkshopReportDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
          {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_WORKSHOPREPORT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetJobCardStatusDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_JOBCARD_STATUS_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetJobCard(UserBase user, int? WorkShopCode, int? JobCardNo)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@WorkShopCode",WorkShopCode),
                new SqlParameter("@JobCardNo",JobCardNo),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_JOBCARD_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetDriverListDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_DRIVERLIST_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetIncentiveBasedonDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_INCENTIVEBASEDON_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetTech(UserBase user, int? WorkShopCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                    new SqlParameter("@WorkShopCode",WorkShopCode),

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_BAY_VS_TECHNICIAN_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetBayJobDropDown(UserBase user, int WorkShopCode, int Bay)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@WorkShopCode",WorkShopCode),
        new SqlParameter("@Bay",Bay),

             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_BAY_VS_JOBCARD_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetBayTechDropDown(UserBase user, int WorkShopCode, string Date, int techCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@WorkShopCode",WorkShopCode),
        new SqlParameter("@Date",Date),
        new SqlParameter("@techCode",techCode)
             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_BAY_TECH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetRegNoDropDown(UserBase user, int? WorkShopCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@WorkShopCode",WorkShopCode)
             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_REGISTRAION_NUMBER_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }



        public async Task<List<Dropdown>> GetIncentiveGroupBasedonDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_INCENTIVEGROUPBASED_ON_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetBranchTargetIncentiveDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_BRANCH_TARGET_INCENTIVEGROUP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetOnlyThreeMonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_ONLY_THREE_MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetParameterByGroupDropDown(UserBase user, int IncentiveGroup)
        {
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@Model",IncentiveGroup)
            };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_PARAMETER_BY_INCENTIVEGROUP_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetDMSBranchwiseRegionDropdown(UserBase user, int Branch)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@Branch",Branch)
             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_BRANCH_WISE_REGION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

        public async Task<List<Dropdown>> GetOutSourceWorkCombofill(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),

             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_OUTSOURCE_WORK_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetTargetBranchssDropdown(UserBase user, int IncentiveGroupCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
               
                new SqlParameter("@IncentiveGroupCode",IncentiveGroupCode)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TARGGET_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }



        //public async Task<List<Dropdown>> GetTeamTargetEmployeessDropdown(UserBase user, int BranchCode, int IncentiveGroupCode)
        //{
        //    IDbDataParameter[] sqlParameters =
        //      {
        //        new SqlParameter("@COMPANYGI",user.CompanyGuid),
        //        new SqlParameter("@USERGI",user.UserGuid),
        //          new SqlParameter("@BranchCode",BranchCode),
        //          new SqlParameter("@BranchCode",BranchCode),
        //          new SqlParameter("@IncentiveGroupCode",IncentiveGroupCode)

        //    };


        //}
        public async Task<List<Dropdown>> GetTeamTargetEmployeessDropdown(UserBase user, int BranchCode, int IncentiveGroupCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
               
                 new SqlParameter("@BranchCode",BranchCode),
                new SqlParameter("@IncentiveGroupCode",IncentiveGroupCode)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_BRANCH_TARGET_EMPLOYEE_COMBOFILL_NEW]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }



        public async Task<List<Dropdown>> GetWarrentyPlanDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_WARRENTY_PLAN_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetAllotmentVariantDropdown(UserBase user,int Status, int Model)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@Model",Model),
                new SqlParameter("@Status",Status)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MODEL_VARIANT_ALLOTMENT_PENDING_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetAllotmentModelDropdown(UserBase user,int Status)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@Status",Status)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MODEL_ALLOTMENT_PENDING_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> getpendingBayJOBdropdown(UserBase user, int WorkShopCode,int BayCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@WorkShopCode",WorkShopCode),
        //new SqlParameter("@BayCode",BayCode),

             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_Pending_Bay_JobCard_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }

         public async Task<List<Dropdown>> GetDMSUserRoleDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),

             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_DMS_USER_ROLE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetWorkShopAdvisor(UserBase user,int WorkShopCode )
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@WorkShopCode",WorkShopCode),

             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_WORKSHOP_VS_ADVISOR_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }



        public async Task<List<Dropdown>> GetMonthWorkShop(UserBase user, int WorkShopCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),
        new SqlParameter("@WorkShopCode",WorkShopCode),

             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_WORKSHOP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }




        public async Task<List<Dropdown>> GetRegionEDDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGI",user.UserGuid),

             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_REGION_ED_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }


        public async Task<List<Dropdown>> GetWorkshopFSDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
            new SqlParameter("@CompanyGI",user.CompanyGuid),
            new SqlParameter("@UserGI",user.UserGuid),

             };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_WORKSHOP_FS_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);

        }

        public async Task<List<Dropdown>> GetWorkshopBayMovementDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
            new SqlParameter("@CompanyGI",user.CompanyGuid),
            new SqlParameter("@UserGI",user.UserGuid),

            };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_WORKSHOP_BM_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetEmployeeNotInUserDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
            {
            new SqlParameter("@CompanyGI",user.CompanyGuid),
            new SqlParameter("@UserGI",user.UserGuid),

            };

            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_EMPLOYEE_NOT_IN_USER]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetModelVariantvsColorDropdown(UserBase user, int Model, int Varient)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@Model",Model),
                new SqlParameter("@Varient",Varient)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SP_MODEL_VARIANT_VS_COLOR_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        } 
        public async Task<List<Dropdown>> GetSecurity(UserBase user, int WorkShopCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@WorkShopCode",WorkShopCode),
    
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SP_SECURITY_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetMCarePlanDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
               

            };
            var dt = await _sql.GetDataTableAsync("[MCARE].[SP_SP_PLAN_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetMcareActivePlanDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_ACTIVE_PLAN_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetMCareRegistrationStatusDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[MCARE].[SP_MCARE_REG_STATUS_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
       

        public async Task<List<Dropdown>> GetMCareDuration(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[MCARE].[SP_MCARE_DURATION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetModelVariantBranch(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TESTDRIVE_MODEL-VARIANT-BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }






        public async Task<List<Dropdown>> GetSeviceAchivementvsTarget_MonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetSeviceAchivementvsTarget_ParameterDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT_PARAMETER_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetSeviceAchivementvsTarget_RegionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT_REGION_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetEmployeeVSTargetReport_BranchDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_EMPLOYEE_VS_TARGET_REPORT_BRANCH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetEmployeeVSTargetReport_MonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetEmployeeVSTargetReport_ParameterDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT_PARAMETER_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetEmployeeVSTargetReport_RegionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_TARGET_VS_ACHIEVMENT_REPORT_REGION_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetAllotmentColorDropdown(UserBase user,int Status, int Model, int Varient)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@Status",Status),
                new SqlParameter("@Model",Model),
                new SqlParameter("@Varient",Varient)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_ALLOTMENT_COLOR_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetSalesBranchDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SALES_UPDATE_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetSalesVarientDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SALES_UPDATE_VARIENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetMCareServiceAdvisorDropDown(UserBase user, int? id)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@id",id)
                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_MCARE_SERVICE_ADVISOR_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetSalesBranch(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),


            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SALES_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetModeOfPaymentDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MODE_OF_PAYMENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetDMSRegionWiseBranchDropdown(UserBase user,int BranchCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@BranchCode",BranchCode)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_REGION_WISE_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetMcareCancelPaymentModeDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_PAYMENT_TYPE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetServiceAdvisorMobileDropdown(UserBase user, int WorkshopCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@WorkshopCode",WorkshopCode)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_WORKSHOP_VS_ADVISOR_MOBILE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
         public async Task<List<Dropdown>> GetMcareCancellationReasonDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
     
            };
            var dt = await _sql.GetDataTableAsync("MCARE.[SP_REASON_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetMcareServiceDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MCARE_SERVICE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }



        public async Task<List<Dropdown>> GetSourceEnquiryDrodown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_GetGetDMSSoureOfEnqDropDown_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetServiceAdvisorLoadDropdown(UserBase user, int Month, int Region, int branch)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@COMPANYGI", user.CompanyGuid),
        new SqlParameter("@USERGI", user.UserGuid),
        new SqlParameter("@MONTH", Month),
        new SqlParameter("@REGION", Region),
        new SqlParameter("@BRANCH", branch),
    };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SA_LOAD_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetNewServiceAdvisorDropdown(UserBase user, int Month, int Region, int branch)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@COMPANYGI", user.CompanyGuid),
        new SqlParameter("@USERGI", user.UserGuid),
        new SqlParameter("@MONTH", Month),
        new SqlParameter("@REGION", Region),
        new SqlParameter("@BRANCH", branch),
    };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SA_BASED_MONTH_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetServiceAdvisorLabourDropdown(UserBase user, int Month, int Region, int branch)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@COMPANYGI", user.CompanyGuid),
        new SqlParameter("@USERGI", user.UserGuid),
        new SqlParameter("@MONTH", Month),
        new SqlParameter("@REGION", Region),
        new SqlParameter("@BRANCH", branch),
    };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SA_LABOUR_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetServiceAdvisorMGADropdown(UserBase user, int Month, int Region, int branch)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@COMPANYGI", user.CompanyGuid),
        new SqlParameter("@USERGI", user.UserGuid),
        new SqlParameter("@MONTH", Month),
        new SqlParameter("@REGION", Region),
        new SqlParameter("@BRANCH", branch),
    };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SA_BASED_MONTH_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetLoadMonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SA_LOAD_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetLabourRegionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SA_LOAD_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetLabourMonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SA_LABOUR_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetLoadRegionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SA_REGION_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetLoadRegionWiseBranchDropdown(UserBase user, int BranchCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                 new SqlParameter("@BranchCode",BranchCode)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_LOAD_REGION_WISE_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetMcareregModel(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MCARE_REG_MODEL_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
         public async Task<List<Dropdown>> GetModelSegment(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SEGMENT_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetColdFollowUpStatusDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
                  {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_ColdFollowUp_Status_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetModuleDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_UPLOADED_FILES_REPORT_MODULE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetOutletModel(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_OUTLET_MODEL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
         public async Task<List<Dropdown>> GetOutletEnquiryDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_OUTLET_SOURCE_OF_ENQUIRY]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetLabourRegionWiseBranchDropdown(UserBase user, int RegionCode, int MonthCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@RegionCode",RegionCode),
                new SqlParameter("@MonthCode",MonthCode)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SA_LABOUR_REGION_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetDsewithiddropdown(UserBase user, int branch, int Region)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@RegionCode",Region),
                new SqlParameter("@branch",branch)
            };
            var dt = await _sql.GetDataTableAsync("[MCARE].[SP_DSE_WITH_ID_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetEmployeeDesignationDropdown(UserBase user, int DesignationCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@DesignationCode",DesignationCode),


            };
            var dt = await _sql.GetDataTableAsync("[MCARE].[SP_GET_BRANCH_WISE_EMPLOYEE_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetBranchWiseEmployeeDropdown(UserBase user, int BranchCode)
        {
            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@COMPANYGI", user.CompanyGuid),
        new SqlParameter("@USERGI", user.UserGuid),
        new SqlParameter("@BranchCode", BranchCode),
    };
            var dt = await _sql.GetDataTableAsync("[MCARE].[SP_GET_BRANCH_WISE_EMPLOYEE_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetTeamManagerWiseEnquiryStatusEnquiryDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_OUTLET_SOURCE_OF_ENQUIRY]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetTeamManagerWiseEnquiryStatusModelDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TM_BASED_MODEL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetTeamManagerWiseEnquiryStatusMonthDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TM_BASED_MONTH]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetSalesDateDropdown(UserBase user, DateTime FromDate, DateTime ToDate)
        {
            IDbDataParameter[] sqlParameters =
       {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@From",FromDate),
                new SqlParameter("@To",ToDate)
                };
            var dataTable = await _sql.GetDataTableAsync("[DMS].[SP_GETDATE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);

            return PopulateDropDownDetails(dataTable);
        }
        public async Task<List<Dropdown>> GetDMSMCARERegionWiseBranchDropdown(UserBase user, int BranchCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@BranchCode",BranchCode)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MCARE_REGION_WISE_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetSeniorRegionalManagerDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SRM_RM_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetPlanNotSetMODELDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MCARE_PLAN_MODEL_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetSalesMonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SALES_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetServiceAchivementAdjustmentIncentiveRoleDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_ACHIEVEMENT_ADJUSTMENT_INCENTIVEROLE_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetServiceAchivementAdjustmentMonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_ACHIEVEMENT_ADJUSTMENT_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetServiceAchivementAdjustmentBRANCHDropdown(UserBase user, int Monthcode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                new SqlParameter("@Monthcode",Monthcode)
            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SERVICE_ACHIEVEMENT_ADJUSTMENT_BRANCH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }



        public async Task<List<Dropdown>> GetModelDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MODEL_REPORT_COMPO]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetTlDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TL_REPORT_COMPO]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetDseDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_DSE_REPORT_COMP0]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetSourceOfEnqDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SOURCE_OF_ENQUIRY_REPORT_COMPO]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetSalesperBranch(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_GET_SALES_FINANCIAL_BRANCH]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetFinancialYearDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_GET_FINANCIAL_YEAR_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetSalesIncentiveApplicationDesignationDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SALES_INCENTIVE_APPLICATION_DESIGNATION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetTeamLeaderByBranchDropDown(UserBase user,int EmpCode)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid),
                 new SqlParameter("@EmpCode",EmpCode)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TEAMLEADER_BY_BRANCH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetMonthOrderUpdate(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_ORDER_UPDATE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetMonthOBU(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_ORDER_UPLOAD_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetMonthLeadEnquiry(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_LEAD_ENQUIRY_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetMonthSalesUpdate(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@COMPANYGI",user.CompanyGuid),
                new SqlParameter("@USERGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_SALES_UPDATE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetStockStatusDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_STOCK_STATUS__COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetChannelDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_CHANNEL_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetAllRegionDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_All_REGION_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetAllDMSMCARERegionWiseBranchDropdown(UserBase user, int Region)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@Region",Region)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_All_REGION_WISE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetAllSaleExecutives(UserBase user,int Region,int Branch)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                  new SqlParameter("@Region",Region),
                    new SqlParameter("@Branch",Branch)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_All_EXECUTIVE_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetAllModelDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_All_MODEL_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetPercarProfitMonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_PER_CAR_MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetFinanceUpdateBranchDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_DMS_FINANCE_BRANCH_LIST]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetFinancialYearMonthDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_DMS_FINACIALYEAR_MONTH_LIST]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetEnquiryFollowUpReportMonth(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP__ENQUIRY_FOLLOWUP_MONTH_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetDiscontinuedModelList(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_DISCONTINUED_MODEL_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetModelGroupDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MODEL_GROUP_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetDiscontinuedModelListDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_DISCONTINUED_MODEL_LIST_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetOrgMonthDropDown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_SALES_ORG_MONTH_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }



        public async Task<List<Dropdown>> GetMOnthwiseSalesDealerDropDown(UserBase user, int Month)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@Month",Month)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MONTH_WISE_DEALER_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }
        public async Task<List<Dropdown>> GetDseenquiryRegionWisebranchDropDown(UserBase user, int Region)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@region",Region)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_DSE_ENQUIRY_REGION_WISE_COMBOFILE]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetDashboardMonth(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("DMS.SP_DASHBOARD_MONTH_COMBOFILL", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


        public async Task<List<Dropdown>> GetTypeSTOCKDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_TYPE_STOCKAGING_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetAccessoriespartCategoryDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_ACCESSORIES_PART_CATEGORY_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetContinuedModelDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_CONTINUED_MODEL_LIST_COMBOFILL]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }

        public async Task<List<Dropdown>> GetActiveModuleDropdown(UserBase user)
        {
            IDbDataParameter[] sqlParameters =
              {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid)

            };
            var dt = await _sql.GetDataTableAsync("[DMS].[SP_MODULE_DROPDOWN]", sqlParameters, CommandType.StoredProcedure);
            return PopulateDropDownDetails(dt);
        }


    }


}

    