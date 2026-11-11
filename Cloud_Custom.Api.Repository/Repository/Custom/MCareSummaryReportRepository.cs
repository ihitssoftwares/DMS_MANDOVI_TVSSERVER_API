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
    public class MCareSummaryReportRepository : IMCareSummaryReportRepository
    {
        private readonly ISqlConnectionProvider _sql;

        public MCareSummaryReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<MCareSummaryReport> GetList(UserBase user, string FromDate, string ToDate, int DivisionCode, int RegionCode, int BranchCode, int EmployeeCode, string SalesFilter, int Year)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
                    new SqlParameter("@CompanyGI", user.CompanyGuid),
                    new SqlParameter("@UserGuid", user.UserGuid),
                    new SqlParameter("@FromDate", FromDate),
                    new SqlParameter("@ToDate", ToDate),
                    new SqlParameter("@DivisionCode", DivisionCode),
                    new SqlParameter("@RegionCode", RegionCode),
                    new SqlParameter("@BranchCode", BranchCode),
                    new SqlParameter("@EmployeeCode", EmployeeCode),
                    new SqlParameter("@SalesFilter", SalesFilter),
                    new SqlParameter("@Year", Year)
                };

                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_SUMMARY_REPORT]", sqlparameters);

                return SummaryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private MCareSummaryReport SummaryList(DataSet ds)
        {
            MCareSummaryReport model = new MCareSummaryReport
            {
                SummaryList = new List<MCareSummaryReportDetail>(),
                DetailList = new List<MCareSummaryReportDetail>()
            };

            if (ds == null || ds.Tables.Count == 0)
                return model;

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.SummaryList.Add(new MCareSummaryReportDetail
                    {
                        RegionName = MakeSafe.ToSafeString(row["RegionName"]),
                        // CityName = MakeSafe.ToSafeString(row["CityName"]),
                        MCareNos = MakeSafe.ToSafeInt32(row["MCareNos"]),
                        MCareRevenue = MakeSafe.ToSafeDecimal(row["MCareRevenue"]),
                        SilverNos = MakeSafe.ToSafeInt32(row["SilverNos"]),
                        SilverRevenue = MakeSafe.ToSafeDecimal(row["SilverRevenue"]),
                        GoldNos = MakeSafe.ToSafeInt32(row["GoldNos"]),
                        GoldRevenue = MakeSafe.ToSafeDecimal(row["GoldRevenue"]),
                        PlatinumNos = MakeSafe.ToSafeInt32(row["PlatinumNos"]),
                        PlatinumRevenue = MakeSafe.ToSafeDecimal(row["PlatinumRevenue"]),
                        TotalNos = MakeSafe.ToSafeInt32(row["TotalNos"]),
                        TotalRevenue = MakeSafe.ToSafeDecimal(row["TotalRevenue"]),
                        IsGrandTotal = MakeSafe.ToSafeInt32(row["IsGrandTotal"]),
                        IsRegionTotal = MakeSafe.ToSafeInt32(row["IsRegionTotal"]),
                    });
                }
            }

            if (ds.Tables.Count > 1)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.DetailList.Add(new MCareSummaryReportDetail
                    {
                        RegionName = MakeSafe.ToSafeString(row["RegionName"]),
                        CityName = MakeSafe.ToSafeString(row["CityName"]),
                        MCareNos = MakeSafe.ToSafeInt32(row["MCareNos"]),
                        MCareRevenue = MakeSafe.ToSafeDecimal(row["MCareRevenue"]),

                        SilverNos = MakeSafe.ToSafeInt32(row["SilverNos"]),
                        SilverRevenue = MakeSafe.ToSafeDecimal(row["SilverRevenue"]),
                        GoldNos = MakeSafe.ToSafeInt32(row["GoldNos"]),
                        GoldRevenue = MakeSafe.ToSafeDecimal(row["GoldRevenue"]),
                        PlatinumNos = MakeSafe.ToSafeInt32(row["PlatinumNos"]),
                        PlatinumRevenue = MakeSafe.ToSafeDecimal(row["PlatinumRevenue"]),
                        TotalNos = MakeSafe.ToSafeInt32(row["TotalNos"]),
                        TotalRevenue = MakeSafe.ToSafeDecimal(row["TotalRevenue"]),
                        IsGrandTotal = MakeSafe.ToSafeInt32(row["IsGrandTotal"]),
                        IsRegionTotal = MakeSafe.ToSafeInt32(row["IsRegionTotal"]),
                    });
                }
            }

            return model;
        }
    }
}