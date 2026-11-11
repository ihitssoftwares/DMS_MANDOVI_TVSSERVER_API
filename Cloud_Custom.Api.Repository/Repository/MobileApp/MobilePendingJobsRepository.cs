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
    public class MobilePendingJobsRepository : IMobilePendingJobsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;

        public MobilePendingJobsRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }



        public async Task<MobilePendingJobs> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_PENDING_JOBS_SERVICE_LIST]", sqlparameters);
                return PendingJobsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobilePendingJobs PendingJobsList(DataSet dataSet)
        {
            MobilePendingJobs model = new MobilePendingJobs();

            List<MobilePendingJobs> GetList = new List<MobilePendingJobs>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new MobilePendingJobs();

                    item.Slno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.Phone = MakeSafe.ToSafeString(row["Phone"]);
                    item.JCDateTime = MakeSafe.ToSafeDateTime(row["JCDateTime"]);
                    item.CheckIn = MakeSafe.ToSafeDateTime(row["CheckIn"]);
                    item.VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.ModeName = MakeSafe.ToSafeString(row["ModeName"]);
                    item.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);
                    item.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    item.MCare = MakeSafe.ToSafeInt32(row["MCare"]);

                    GetList.Add(item);
                }

                model.List = GetList;
            }

            return model;
        }
    }
}
