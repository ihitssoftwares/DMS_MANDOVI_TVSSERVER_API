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
     public class JobCardTrackingReportRepository : IJobCardTrackingReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public JobCardTrackingReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<JobCardTrackingReport> GetList(UserBase user, int WorkshopCode, string PickedDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@WorkshopCode",WorkshopCode),
                 new SqlParameter("@PickedDate",PickedDate),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_JOBCARD_STATUS_LIST]", sqlparameters);
                return ModelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private JobCardTrackingReport ModelList(DataSet dataSet)
        {
            JobCardTrackingReport model = new JobCardTrackingReport();
            List<JobCardTrackingReport> List = new List<JobCardTrackingReport>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new JobCardTrackingReport();

                    item.JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.JCDateTime = MakeSafe.ToSafeDateTime(row["JCDateTime"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.Phone = MakeSafe.ToSafeString(row["Phone"]);
                    item.Email = MakeSafe.ToSafeString(row["Email"]);
                    item.CheckIn = MakeSafe.ToSafeString(row["CheckIn"]);
                    item.CheckOut = MakeSafe.ToSafeString(row["CheckOut"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);
                    item.Ageing = MakeSafe.ToSafeString(row["AgeingDays"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;
        }
        public async Task<JobCardTrackingReport> GetBayDetails(UserBase user, int JobCardEntryCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGuid", user.UserGuid),
            new SqlParameter("@JobCardEntryCode", JobCardEntryCode),
        };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SERVICE_DASHBOARD_BAY_TRACKER]", sqlparameters);
                return ModelBayList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private JobCardTrackingReport ModelBayList(DataSet dataSet)
        {
            JobCardTrackingReport model = new JobCardTrackingReport();
            List<JobCardTrackingReport> bayList = new List<JobCardTrackingReport>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    bayList.Add(new JobCardTrackingReport
                    {
                        BayUserCode = MakeSafe.ToSafeString(row["BayUserCode"]),
                        BayName = MakeSafe.ToSafeString(row["BayDetails"]),
                        Technician = MakeSafe.ToSafeString(row["Technician"]),
                        InTime = MakeSafe.ToSafeString(row["InTime"]),
                        OutTime = MakeSafe.ToSafeString(row["OutTime"]),
                        BayTimeSpent = MakeSafe.ToSafeString(row["BayTimeSpent"]),
                        BayDuration = MakeSafe.ToSafeString(row["TotalMinutes"])
                    });
                }

                model.BayList = bayList;
            }

            return model;
        }
    }
}
