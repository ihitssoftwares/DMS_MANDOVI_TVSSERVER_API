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
    public class ServiceIncentiveProccesingReportRepository : IServiceIncentiveProccesingReportRepository
    {
        private readonly ISqlConnectionProvider _sql;


        public ServiceIncentiveProccesingReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;

        }
        public async Task<ServiceIncentiveProccesingReport> GetIncentiveList(UserBase userBase, int MonthCode, int RegionCode,int BranchCode,int EmpCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
                    new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                    new SqlParameter("@UserGI",userBase.UserGuid),
                    new SqlParameter("@MonthCode",MonthCode),
                    new SqlParameter("@RegionCode",RegionCode),
                    new SqlParameter("@BranchCode",BranchCode),
                    new SqlParameter("@EmpCode",EmpCode),

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_PROCESING_REPORT]", sqlparameters);
                return IncentiveList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }



        private ServiceIncentiveProccesingReport IncentiveList(DataSet dataSet)
        {
            ServiceIncentiveProccesingReport model = new ServiceIncentiveProccesingReport();
            List<ServiceIncentiveProccesingReport> List = new List<ServiceIncentiveProccesingReport>();
            List<ServiceIncentiveProccesingReport> List2 = new List<ServiceIncentiveProccesingReport>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceIncentiveProccesingReport();



                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["Employee"]);
                    item.BranchName = MakeSafe.ToSafeString(row["Branch"]);
                    item.IncentiveGRoup = MakeSafe.ToSafeString(row["IncentiveGroup"]);
                    item.TotalIncentive = MakeSafe.ToSafeString(row["TotalIncentive"]);



                    List.Add(item);
                }
                model.MainList = List;
            }


            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new ServiceIncentiveProccesingReport();

                  item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                  item.EmployeeName = MakeSafe.ToSafeString(row["Employee"]);
                    item.BranchName = MakeSafe.ToSafeString(row["Branch"]);
                    item.incentiveCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                    item.IncentiveGRoup = MakeSafe.ToSafeString(row["IncentiveGroup"]);
                    item.parameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.Parametername = MakeSafe.ToSafeString(row["Parameter"]);
                    item.ParameterType = MakeSafe.ToSafeString(row["ParameterType"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.OrginalAcheivement = MakeSafe.ToSafeInt32(row["OriginalAchievment"]);
                    item.ActualAcheivement = MakeSafe.ToSafeInt32(row["ActualAchievment"]);
                    item.Slab = MakeSafe.ToSafeString(row["Slab"]);
                    item.Incentive = MakeSafe.ToSafeDecimal(row["Incentive"]);
                    item.IncentiveAmount = MakeSafe.ToSafeDecimal(row["IncentiveAmount"]);
                    item.TotalIncentive = MakeSafe.ToSafeString(row["TotalIncentive"]);


                    List2.Add(item);

                }
                model.ReportList = List2;
            }
            return model;
        } 
        public async Task<ServiceIncentiveProccesingReport> GetExcelProcessList(UserBase userBase, int MonthCode, int RegionCode,int BranchCode,string Type,int Employeecode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
                    new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                    new SqlParameter("@UserGI",userBase.UserGuid),
                    new SqlParameter("@MonthCode",MonthCode),
                    new SqlParameter("@RegionCode",RegionCode),
                    new SqlParameter("@BranchCode",BranchCode),
                    new SqlParameter("@Type",Type),
                    new SqlParameter("@EmpCode",Employeecode),

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_PROCESING_REPORT_EXECL]", sqlparameters);
                return ExportList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }



        private ServiceIncentiveProccesingReport ExportList(DataSet dataSet)
        {
            ServiceIncentiveProccesingReport model = new ServiceIncentiveProccesingReport();
            List<ServiceIncentiveProccesingReport> List = new List<ServiceIncentiveProccesingReport>();
            List<ServiceIncentiveProccesingReport> List2 = new List<ServiceIncentiveProccesingReport>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceIncentiveProccesingReport();



                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["Employee"]);
                    item.BranchName = MakeSafe.ToSafeString(row["Branch"]);
                    item.IncentiveGRoup = MakeSafe.ToSafeString(row["IncentiveGroup"]);
                    item.TotalIncentive = MakeSafe.ToSafeString(row["TotalIncentive"]);



                    List.Add(item);
                }
                model.MainList = List;
            }


            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new ServiceIncentiveProccesingReport();

                    item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["Employee"]);
                  
                    item.BranchName = MakeSafe.ToSafeString(row["Branch"]);
                    item.IncentiveGRoup = MakeSafe.ToSafeString(row["IncentiveGroup"]);
          
                    item.Parametername = MakeSafe.ToSafeString(row["Parameter"]);
                    item.ParameterType = MakeSafe.ToSafeString(row["ParameterType"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.OrginalAcheivement = MakeSafe.ToSafeInt32(row["OriginalAchievment"]);
                    item.ActualAcheivement = MakeSafe.ToSafeInt32(row["ActualAchievment"]);
                    item.Slab = MakeSafe.ToSafeString(row["Slab"]);
                    item.Incentive = MakeSafe.ToSafeDecimal(row["Incentive"]);
                    item.IncentiveAmount = MakeSafe.ToSafeDecimal(row["IncentiveAmount"]);
                    item.TotalIncentive = MakeSafe.ToSafeString(row["TotalIncentive"]);


                    List2.Add(item);

                }
                model.ReportList = List2;
            }
            return model;
        } 
        public async Task<DataSet> GetPopupList(UserBase userBase, int MonthCode, int Region, int branchCode, int EmpCode, int ParaCode, int InceCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
                    new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                    new SqlParameter("@UserGI",userBase.UserGuid),
                    new SqlParameter("@MonthCode",MonthCode),
                    new SqlParameter("@RegionCode",Region),
                    new SqlParameter("@BranchCode",branchCode),
                    new SqlParameter("@EmployeeCode",EmpCode),
                    new SqlParameter("@ParameterCode",ParaCode),
                    new SqlParameter("@IncentiveGroupCode",InceCode)

                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_PROCESING_REPORT_DETAIL]", sqlparameters);
                return (ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }




    }
}
