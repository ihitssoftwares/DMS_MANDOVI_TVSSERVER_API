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
    public class EmployeeVSTargetReportRepository : IEmployeeVSTargetReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public EmployeeVSTargetReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<EmployeeVSTargetReport> GetList(UserBase user, int Month, int Region, int Branch, int Parameter)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Month",Month),
                 new SqlParameter("@RegionCode",Region),
                 new SqlParameter("@Branch",Branch),
                 new SqlParameter("@Parameter",Parameter),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_EMPLOYEE_VS_TARGET_REPORT_LIST]", sqlparameters);
                return EmployeeVSTargetReportList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private EmployeeVSTargetReport EmployeeVSTargetReportList(DataSet dataSet)
        {
            EmployeeVSTargetReport model = new EmployeeVSTargetReport();
            List<EmployeeVSTargetReport> List = new List<EmployeeVSTargetReport>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new EmployeeVSTargetReport();


                    item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
                    item.Targets = MakeSafe.ToSafeInt32(row["Target"]);
                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                    item.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.IncentiveGroupName = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                    item.PreTarget = MakeSafe.ToSafeInt32(row["Prev Target"]);
                    item.Designation = MakeSafe.ToSafeString(row["Designation"]);
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.RegionCode = MakeSafe.ToSafeInt32(row["RegionCode"]);

                    List.Add(item);
                }
                model.List = List;
            }


            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {

                    model.PendingCount = MakeSafe.ToSafeInt32(row["PendingCount"]);

                }
            }
            return model;
        }
    }
}
