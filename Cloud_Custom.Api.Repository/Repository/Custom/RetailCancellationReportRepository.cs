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
    public class RetailCancellationReportRepository : IRetailCancellationReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public RetailCancellationReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<RetailCancellationReport> GetList(UserBase user, string Type, string FromDate, string ToDate, int Month, int ReportType)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
                    new SqlParameter("@CompanyGI", user.CompanyGuid),
                    new SqlParameter("@UserGuid", user.UserGuid),
                    new SqlParameter("@Type", Type),
                    new SqlParameter("@FromDate", FromDate),
                    new SqlParameter("@ToDate", ToDate),
                    new SqlParameter("@Month", Month),
                    new SqlParameter("@ReportType", ReportType)
                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_RETAIL_CANCELLATION_REPORT]", sqlparameters);
                return BuildModel(ds, ReportType);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private RetailCancellationReport BuildModel(DataSet ds, int reportType)
        {
            RetailCancellationReport model = new RetailCancellationReport();
            model.ReportType = reportType;
            if (ds.Tables.Count > 0 && (ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (reportType == 1)
                    {
                        model.SummaryList.Add(new RetailCancellationSummary
                        {
                            GroupHeader = MakeSafe.ToSafeString(row["GroupHeader"]),
                            RetailCancel = MakeSafe.ToSafeInt32(row["RetailCancel"])
                        });
                    }
                    else
                    {
                        model.DetailList.Add(new RetailCancellationDetail
                        {
                            GroupHeader = MakeSafe.ToSafeString(row["GroupHeader"]),
                            BookingDate = row["BookingDate"] == DBNull.Value ? (DateTime?)null : MakeSafe.ToSafeDateTime(row["BookingDate"]),
                            FollowupCount = MakeSafe.ToSafeInt32(row["FollowupCount"]),
                            HasTakenTestDrive = MakeSafe.ToSafeInt32(row["HasTakenTestDrive"]) == 1,
                            HasTakenHomeVisit = MakeSafe.ToSafeInt32(row["HasTakenHomeVisit"]) == 1,
                            RetailDate = row["RetailDate"] == DBNull.Value ? (DateTime?)null : MakeSafe.ToSafeDateTime(row["RetailDate"]),
                            CancellationDate = row["CancellationDate"] == DBNull.Value ? (DateTime?)null : MakeSafe.ToSafeDateTime(row["CancellationDate"]),
                           // DaysBookingToCancel = MakeSafe.ToSafeInt32(row["DaysBookingToCancel"]),
                            DaysRetailToCancel = MakeSafe.ToSafeInt32(row["DaysRetailToCancel"])
                        });
                    }
                }
            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                var d = ds.Tables[1].Rows[0];
                model.FromDate = d["FromDate"] == DBNull.Value ? (string)null : MakeSafe.ToSafeString(d["FromDate"]);
                model.ToDate = d["ToDate"] == DBNull.Value ? (string)null : MakeSafe.ToSafeString(d["ToDate"]);
            }
            return model;
        }
    }
}
