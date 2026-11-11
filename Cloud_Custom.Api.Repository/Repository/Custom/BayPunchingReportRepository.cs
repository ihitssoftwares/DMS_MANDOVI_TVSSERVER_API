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
    public class BayPunchingReportRepository : IBayPunchingReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public BayPunchingReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<DataSet> GetList(UserBase user, int MonthCode, int BranchCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                   
                 //new SqlParameter("@CompanyGI",user.CompanyGuid),
                 //new SqlParameter("@UserGuid",user.UserGuid),
               
                 new SqlParameter("@Month",MonthCode),
                 new SqlParameter("@BranchCode",BranchCode)

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_PUNCHING_DETAILS_REPORT]", sqlparameters);
                return (ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        //private BayPunchingReport EmpList(DataSet dataSet)
        //{
        //    BayPunchingReport model = new BayPunchingReport();
        //    List<BayPunchingReport> List = new List<BayPunchingReport>();

        //    if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
        //    {
        //        foreach (DataRow row in dataSet.Tables[0].Rows)
        //        {
        //            var item = new BayPunchingReport();



        //            item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
        //            item.UserCode = MakeSafe.ToSafeString(row["UserCode"]);
        //            item.EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]);
        //            item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
        //            item.EmpPosition = MakeSafe.ToSafeString(row["EmployeePosition"]);

        //            item.TeamLead = MakeSafe.ToSafeString(row["TeamLead"]);
        //            item.Branch = MakeSafe.ToSafeString(row["BranchName"]);
        //            item.DealerName = MakeSafe.ToSafeString(row["DealershipName"]);
        //            item.incentiveGroupname = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
        //            item.Status = MakeSafe.ToSafeString(row["Status"]);
        //            item.GrossPay = MakeSafe.ToSafeDecimal(row["GrossPay"]);
        //            item.MSPin = MakeSafe.ToSafeString(row["MSPin"]);
        //            item.Region = MakeSafe.ToSafeString(row["RegionName"]);
        //            item.active = MakeSafe.ToSafeInt32(row["ACTIVE"]);
        //            item.totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"]);

        //            List.Add(item);
        //        }
        //        model.List = List;
        //    }
        //    return model;

        //}
    }
}
