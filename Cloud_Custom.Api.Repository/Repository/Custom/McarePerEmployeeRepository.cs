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
     public class McarePerEmployeeRepository : IMcarePerEmployeeRepositroy
    {
        private readonly ISqlConnectionProvider _sql;

        public McarePerEmployeeRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<McarePerEmployee> GetList(UserBase user, string FromDate, string ToDate, int DivisionCode, int RegionCode, int BranchCode, int EmployeeCode, int Year)
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
                    new SqlParameter("@Year", Year)
                };

                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_EMPLOYEE_REPORT]", sqlparameters);

                return SummaryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private McarePerEmployee SummaryList(DataSet ds)
        {
            McarePerEmployee model = new McarePerEmployee
            {
                SummaryList = new List<McarePerEmployeeDetail>(),
                DetailList = new List<McarePerEmployeeDetail>()
            };

            if (ds == null || ds.Tables.Count == 0)
                return model;

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.SummaryList.Add(new McarePerEmployeeDetail
                    {
                        RegionName = MakeSafe.ToSafeString(row["RegionName"]),
                        MCareNos = MakeSafe.ToSafeInt32(row["MCareNos"]),
                        MCareRevenue = MakeSafe.ToSafeDecimal(row["MCareRevenue"]),
                        SilverNos = MakeSafe.ToSafeInt32(row["SilverNos"]),
                        SilverRevenue = MakeSafe.ToSafeInt32(row["SilverRevenue"]),
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
                    model.DetailList.Add(new McarePerEmployeeDetail
                    {
                        RegionName = MakeSafe.ToSafeString(row["RegionName"]),
                        EmployeeCode = MakeSafe.ToSafeInt32(row["EmployeeCode"]),
                        EmployeeID = MakeSafe.ToSafeString(row["EmployeeID"]),
                        EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
                       Designation = MakeSafe.ToSafeString(row["Name"]),
                        Location = MakeSafe.ToSafeString(row["Location"]),
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
        public async Task<McarePerEmployee> GetEmployeeDetail(UserBase user, int EmployeeCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGuid", user.UserGuid),
            new SqlParameter("@EmployeeCode", EmployeeCode)
        };

                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_MCARE_EMPLOYEE_DETAIL]", sqlparameters);

                return EmployeeDetailList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private McarePerEmployee EmployeeDetailList(DataSet ds)
        {
            McarePerEmployee model = new McarePerEmployee
            {
                DetailList = new List<McarePerEmployeeDetail>()
            };

            if (ds == null || ds.Tables.Count == 0)
                return model;

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                model.DetailList.Add(new McarePerEmployeeDetail
                {
                    RegionName = MakeSafe.ToSafeString(row["RegionName"]),
                    EmployeeID = MakeSafe.ToSafeString(row["EmployeeID"]),
                    EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),
                    Designation = MakeSafe.ToSafeString(row["Designation"]),
                    Location = MakeSafe.ToSafeString(row["Location"]),
                    CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                    CustomerPhone = MakeSafe.ToSafeString(row["CustomerPhone"]),
                    CustomerCity = MakeSafe.ToSafeString(row["CustomerCity"]),
                    VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),
                    RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]),
                    PlanCode=MakeSafe.ToSafeInt32(row["PlanCode"]),
                    PlanName = MakeSafe.ToSafeString(row["PlanName"]),
                    //SilverNos = row["PlanCode"] != DBNull.Value && Convert.ToInt32(row["PlanCode"]) == 11 ? 1 : 0,
                    //GoldNos = row["PlanCode"] != DBNull.Value && Convert.ToInt32(row["PlanCode"]) == 12 ? 1 : 0,
                    //SilverRevenue = row["PlanCode"] != DBNull.Value && Convert.ToInt32(row["PlanCode"]) == 11 ? MakeSafe.ToSafeInt32(row["PlanAmount"]) : 0,
                    //GoldRevenue = row["PlanCode"] != DBNull.Value && Convert.ToInt32(row["PlanCode"]) == 12 ? MakeSafe.ToSafeInt32(row["PlanAmount"]) : 0,
                    PlanAmount = MakeSafe.ToSafeDecimal(row["PlanAmount"]),
                });
            }

            return model;
        }
    }
}
