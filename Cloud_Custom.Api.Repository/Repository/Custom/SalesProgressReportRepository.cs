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
    public class SalesProgressReportRepository : ISalesProgressReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SalesProgressReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<SalesProgressReport> GetDetails(UserBase user, string monthStartDate, string monthEndDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@COMPANYGI",user.CompanyGuid),
                 new SqlParameter("@USERGI",user.UserGuid),
                    new SqlParameter("@MONTHSTARTDATE",monthStartDate),
                        new SqlParameter("@MONTHENDDATE",monthEndDate)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MIS_SALES_PROGRESS_REPORT]", sqlparameters);
                return PopulateSalesProgressReport(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private SalesProgressReport PopulateSalesProgressReport(DataSet dataSet)
        {
            SalesProgressReport report = new SalesProgressReport();

            // 1. KPI Summary (Table 0)
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                var row = dataSet.Tables[0].Rows[0];
                report.Kpi = new KpiSummary
                {
                    TotalRevenue = MakeSafe.ToSafeDecimal(row["TotalRevenue"]),
                    LastMonthRevenue = MakeSafe.ToSafeDecimal(row["LastMonthRevenue"]),
                    RevenueChangePercentage = MakeSafe.ToSafeDecimal(row["RevenueChangePercentage"]),

                    TotalSales = MakeSafe.ToSafeInt32(row["TotalSales"]),
                    LastMonthSales = MakeSafe.ToSafeInt32(row["LastMonthSales"]),
                    SalesChangePercentage = MakeSafe.ToSafeDecimal(row["SalesChangePercentage"]),

                    AvgTransaction = MakeSafe.ToSafeDecimal(row["AvgTransaction"]),
                    LastMonthAvgTransaction = MakeSafe.ToSafeDecimal(row["LastMonthAvgTransaction"]),
                    AvgTransactionChange = MakeSafe.ToSafeDecimal(row["AvgTransactionChange"]),

                    DailyRunRate = MakeSafe.ToSafeDecimal(row["DailyRunRate"]),
                    LastMonthDailyRunRate = MakeSafe.ToSafeDecimal(row["LastMonthDailyRunRate"]),
                    DailyRunRateChange = MakeSafe.ToSafeDecimal(row["DailyRunRateChange"])
                };
            }

            // 2. Last 5 Months Sales Trend (Table 1)
            report.Last5Months = new List<Last5MonthsSales>();
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    report.Last5Months.Add(new Last5MonthsSales
                    {
                        MonthName = MakeSafe.ToSafeString(row["MonthName"]),
                        TotalSales = MakeSafe.ToSafeInt32(row["TotalSales"])
                    });
                }
            }

            // 3. Model Share (Table 2)
            report.ModelShares = new List<ModelShare>();
            if ((dataSet.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[2].Rows)
                {
                    report.ModelShares.Add(new ModelShare
                    {
                        ModelName = MakeSafe.ToSafeString(row["ModelName"]),
                        UnitsSold = MakeSafe.ToSafeInt32(row["UnitsSold"]),
                        SharePercentage = MakeSafe.ToSafeDecimal(row["SharePercentage"])
                    });
                }
            }

            // 4. Top Branch (Table 3)
            if ((dataSet.Tables[3]?.Rows?.Count ?? 0) > 0)
            {
                var row = dataSet.Tables[3].Rows[0];
                report.TopBranch = new TopBranch
                {
                    BranchName = MakeSafe.ToSafeString(row["BranchName"]),
                    TotalRevenue = MakeSafe.ToSafeDecimal(row["TotalRevenue"]),
                    UnitsSold = MakeSafe.ToSafeInt32(row["UnitsSold"]),
                    RevenueChangePercentage = MakeSafe.ToSafeDecimal(row["RevenueChangePercentage"]),
                    UnitsChangePercentage = MakeSafe.ToSafeDecimal(row["UnitsChangePercentage"])
                };
            }

            // 5. Revenue Split (Table 4)
            report.RevenueSplits = new List<RevenueSplit>();
            if ((dataSet.Tables[4]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[4].Rows)
                {
                    report.RevenueSplits.Add(new RevenueSplit
                    {
                        RevenueType = MakeSafe.ToSafeString(row["RevenueType"]),
                        TotalRevenue = MakeSafe.ToSafeDecimal(row["TotalRevenue"]),
                        UnitsSold = MakeSafe.ToSafeInt32(row["UnitsSold"]),
                        RevenuePercentage = MakeSafe.ToSafeDecimal(row["RevenuePercentage"]),
                        UnitsPercentage = MakeSafe.ToSafeDecimal(row["UnitsPercentage"])
                    });
                }
            }

            // 6. Branch Performance (Table 5)
            report.BranchPerformances = new List<BranchPerformance>();
            if ((dataSet.Tables[5]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[5].Rows)
                {
                    report.BranchPerformances.Add(new BranchPerformance
                    {
                        BranchName = MakeSafe.ToSafeString(row["BranchName"]),
                        TotalRevenue = MakeSafe.ToSafeDecimal(row["TotalRevenue"]),
                        UnitsSold = MakeSafe.ToSafeInt32(row["UnitsSold"]),
                        AvgTransaction = MakeSafe.ToSafeDecimal(row["AvgTransaction"]),
                        ContributionPercentage = MakeSafe.ToSafeDecimal(row["ContributionPercentage"])
                    });
                }
            }

            // 7. Deal Type Percentage (Table 6)
            report.DealTypePercentages = new List<DealTypePercentage>();
            if ((dataSet.Tables[6]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[6].Rows)
                {
                    report.DealTypePercentages.Add(new DealTypePercentage
                    {
                        DealType = MakeSafe.ToSafeString(row["DealType"]),
                        Units = MakeSafe.ToSafeInt32(row["Units"]),
                        Percentage = MakeSafe.ToSafeDecimal(row["Percentage"])
                    });
                }
            }

            // 8. Target vs Achievement (Table 7) 
            if ((dataSet.Tables[7]?.Rows?.Count ?? 0) > 0)
            {
                var row = dataSet.Tables[7].Rows[0];
                report.Target = new TargetAchievement
                {
                    TotalTarget = MakeSafe.ToSafeInt32(row["TotalTarget"]),
                    TotalUnitsSold = MakeSafe.ToSafeInt32(row["TotalUnitsSold"]),
                    Percentage = MakeSafe.ToSafeDecimal(row["Percentage"])
                };
            }

            return report;
        }


    }
}
