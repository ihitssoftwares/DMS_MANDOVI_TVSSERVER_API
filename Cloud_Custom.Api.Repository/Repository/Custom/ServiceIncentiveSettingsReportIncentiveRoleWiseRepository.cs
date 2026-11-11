using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
    public class ServiceIncentiveSettingsReportIncentiveRoleWiseRepository : IServiceIncentiveSettingsReportIncentiveRoleWiseRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceIncentiveSettingsReportIncentiveRoleWiseRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ServiceIncentiveSettingsReportIncentiveRoleWise> GetList(UserBase user, int Month, int IncentiveGroup, int Region,int BranchCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Month",Month),
                 new SqlParameter("@IncentiveGroupCode",IncentiveGroup),
                 new SqlParameter("@RegionCode",Region),
                 new SqlParameter("@branchCode",BranchCode),

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_INCENTIVE_ROLE_WISE_REPORT_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceIncentiveSettingsReportIncentiveRoleWise DesignationVsParameterList(DataSet dataSet)
        {
            ServiceIncentiveSettingsReportIncentiveRoleWise model = new ServiceIncentiveSettingsReportIncentiveRoleWise();
            List<ServiceIncentiveSettingsReportIncentiveRoleWise> List = new List<ServiceIncentiveSettingsReportIncentiveRoleWise>();
            List<ServiceIncentiveSettingsReportIncentiveRoleWise> List2 = new List<ServiceIncentiveSettingsReportIncentiveRoleWise>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceIncentiveSettingsReportIncentiveRoleWise();



                    item.RegionCode = MakeSafe.ToSafeInt32(row["RegionCode"]);
                    item.WorkShopName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
                    item.SlabType = MakeSafe.ToSafeString(row["SlabType"]);
                    item.IncentiveType = MakeSafe.ToSafeString(row["IncentiveType"]);
                    item.SlabFrom = MakeSafe.ToSafeDecimal(row["SlabFrom"]);
                    item.SlabTo = MakeSafe.ToSafeDecimal(row["SlabTo"]);
                    item.Incentive = MakeSafe.ToSafeDecimal(row["Incentive"]);
                    item.Colorcode = MakeSafe.ToSafeString(row["Colorcode"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                    item.employeeCount = MakeSafe.ToSafeInt32(row["employeeCount"]);


                    List.Add(item);
                }
                model.List = List;
            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new ServiceIncentiveSettingsReportIncentiveRoleWise();



                   
                    item.WorkShopName = MakeSafe.ToSafeString(row["RegionName"]);                   
                    item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);                  
                    item.Colorcode = MakeSafe.ToSafeString(row["Colorcode"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                    item.employeeCount = MakeSafe.ToSafeInt32(row["employeeCount"]);


                    List2.Add(item);
                }
                model.List2 = List2;
            }

            return model;
        }


        public async Task<ServiceIncentiveSettingsReportIncentiveRoleWise> GetEmployeedata(UserBase user, int IncentiveGroup, int Branch)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),                 
                 new SqlParameter("@IncentiveGroupCode",IncentiveGroup),              
                 new SqlParameter("@branchCode",Branch),

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_GET_EMPLOYEE_DATA]", sqlparameters);
                return PopulateList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceIncentiveSettingsReportIncentiveRoleWise PopulateList(DataSet dataSet)
        {
            ServiceIncentiveSettingsReportIncentiveRoleWise model = new ServiceIncentiveSettingsReportIncentiveRoleWise();
            List<EmployeeData> DataList = new List<EmployeeData>();
           

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new EmployeeData();



                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.UserCode = MakeSafe.ToSafeString(row["UserCode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.DepartmentName = MakeSafe.ToSafeString(row["DepartmentName"]);
                    item.MSPin = MakeSafe.ToSafeString(row["MSPin"]);
                    


                    DataList.Add(item);
                }
                model.DataList = DataList;
            }
            

            return model;
        }


    }
}
