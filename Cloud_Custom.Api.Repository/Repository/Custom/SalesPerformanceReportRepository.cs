using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
    namespace Cloud_Custom.Api.Repository.Repository.Custom
    {
        public class SalesPerformanceReportRepository : ISalesPerformanceReportRepository
        {
            private readonly ISqlConnectionProvider _sql;

            public SalesPerformanceReportRepository(ISqlConnectionProvider sql)
            {
                _sql = sql;
            }

            public async Task<SalesPerformanceReport> GetList(UserBase user, int MonthCode)
            {
                try
                {
                    IDbDataParameter[] sqlparameters =
                    {
                    new SqlParameter("@CompanyGI", user.CompanyGuid),
                    new SqlParameter("@UserGuid", user.UserGuid),
                    new SqlParameter("@MonthCode", MonthCode)
                };

                    var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_SALES_PERFORMANCE_REPORT]", sqlparameters);

                    return MapList(ds);
                }
                catch (SqlException ex)
                {
                    var ErrorMsg = ex.Message.ToString();
                    throw new Exception(ErrorMsg, ex);
                }
            }

            private SalesPerformanceReport MapList(DataSet ds)
            {
                SalesPerformanceReport model = new SalesPerformanceReport
                {
                    DetailList = new List<SalesPerformanceDetail>(),
                    MonthProductivityList = new List<ChannelProductivity>(),
                    CumulativeProductivityList = new List<ChannelProductivity>()
                };

                if (ds == null || ds.Tables.Count == 0)
                    return model;

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.DetailList.Add(new SalesPerformanceDetail
                    {
                        ChannelName = MakeSafe.ToSafeString(row["ChannelName"]),
                        BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]),
                        BranchName = MakeSafe.ToSafeString(row["BranchName"]),
                        ChannelCode = MakeSafe.ToSafeInt32(row["ChannelCode"]),
                        SRM = MakeSafe.ToSafeInt32(row["SRM"]),
                        AboveThreeMonthsRM_A = MakeSafe.ToSafeInt32(row["AboveThreeMonthsRM_A"]),
                        BelowThreeMonthsRM_B = MakeSafe.ToSafeInt32(row["BelowThreeMonthsRM_B"]),
                        TotalAB = MakeSafe.ToSafeInt32(row["TotalAB"]),
                        CurrentMonthCount = MakeSafe.ToSafeInt32(row["CurrentMonthCount"]),
                        GrandTotalManpower = MakeSafe.ToSafeInt32(row["GrandTotalManpower"]),
                        RetTarget = MakeSafe.ToSafeInt32(row["RetTarget"]),
                        RetailAch = MakeSafe.ToSafeInt32(row["RetailAch"]),
                        RetPercent = MakeSafe.ToSafeDecimal(row["RetPercent"]),
                        RetPerRM_3MonthAbove = MakeSafe.ToSafeDecimal(row["RetPerRM_3MonthAbove"]),
                        RetPerRM_All = MakeSafe.ToSafeDecimal(row["RetPerRM_All"])
                    });
                }

                if (ds.Tables.Count > 1)
                {
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        model.MonthProductivityList.Add(new ChannelProductivity
                        {
                            ChannelCode = MakeSafe.ToSafeInt32(row["ChannelCode"]),
                            RM = MakeSafe.ToSafeInt32(row["RM"]),
                            SRM = MakeSafe.ToSafeInt32(row["SRM"]),
                            TotalSalesMPCount = MakeSafe.ToSafeInt32(row["TotalSalesMPCount"]),
                            RetailAch = MakeSafe.ToSafeInt32(row["RetailAch"]),
                            Productivity = MakeSafe.ToSafeDecimal(row["Productivity"])
                        });
                    }
                }

                if (ds.Tables.Count > 2)
                {
                    foreach (DataRow row in ds.Tables[2].Rows)
                    {
                        model.CumulativeProductivityList.Add(new ChannelProductivity
                        {
                            ChannelCode = MakeSafe.ToSafeInt32(row["ChannelCode"]),
                            RM = MakeSafe.ToSafeInt32(row["RM"]),
                            SRM = MakeSafe.ToSafeInt32(row["SRM"]),
                            TotalSalesMPCount = MakeSafe.ToSafeInt32(row["TotalSalesMPCount"]),
                            RetailAch = MakeSafe.ToSafeInt32(row["RetailAch"]),
                            Productivity = MakeSafe.ToSafeDecimal(row["Productivity"])
                        });
                    }
                }

                if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                {
                    model.Month = new Dropdown
                    {
                        Name = MakeSafe.ToSafeString(ds.Tables[3].Rows[0]["MonthName"])
                    };
                    model.CumulativeFromMonthName = MakeSafe.ToSafeString(ds.Tables[3].Rows[0]["CumulativeFromMonthName"]);
                }

                return model;
            }
        }
    }
}