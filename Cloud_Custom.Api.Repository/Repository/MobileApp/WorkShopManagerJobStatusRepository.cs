using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.General;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.MobileApp
{
    public class WorkShopManagerJobStatusRepository : IWorkShopManagerJobStatusRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;

        public WorkShopManagerJobStatusRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }



        public async Task<WorkShopManagerJobStatus> GetList(UserBase user,string Type)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",Type),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_DASHBOARD_WORKSHOP_MANAGER_JOB_STATUS]", sqlparameters);
                return BindDashboard(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkShopManagerJobStatus BindDashboard(DataSet dataSet)
        {
            WorkShopManagerJobStatus model = new WorkShopManagerJobStatus();

            model.List = new List<WorkShopManagerJobStatus>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    WorkShopManagerJobStatus item = new WorkShopManagerJobStatus
                    {
                        JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]),

                        JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]),

                        JCDateTime = MakeSafe.ToSafeDateTime(row["JCDateTime"]),

                        Customer = MakeSafe.ToSafeString(row["Customer"]),

                        Phone = MakeSafe.ToSafeString(row["Phone"]),

                        VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),

                        ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]),

                        EngineNo = MakeSafe.ToSafeString(row["EngineNo"]),

                        Address = MakeSafe.ToSafeString(row["Address"]),

                        Status = MakeSafe.ToSafeString(row["Status"])
                    };

                    model.List.Add(item);
                }
            }

            return model;
        }
    }
}
