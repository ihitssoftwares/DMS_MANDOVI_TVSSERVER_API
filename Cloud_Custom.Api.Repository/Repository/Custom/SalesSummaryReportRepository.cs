using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Repository.IRepository.General;
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
    public class SalesSummaryReportRepository : ISalesSummaryReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;

        public SalesSummaryReportRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }



        public async Task<SalesSummaryReport> GetList(UserBase user, DateTime FromDate, DateTime ToDate, int TypeCode,DateTime? Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate),
                 new SqlParameter("@TypeCode",TypeCode),
                  new SqlParameter("@Date", Date.HasValue ? (object)Date.Value : DBNull.Value),
        };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SALES_SUMMARY_REPORT]", sqlparameters);
                return BindDashboard(ds);

            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private SalesSummaryReport BindDashboard(DataSet ds)
        {
            SalesSummaryReport model = new SalesSummaryReport();

            model.List = new List<SalesSummaryReport>();

            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.Types = MakeSafe.ToSafeString(row["Types"]);
                
            }


            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.List.Add(new SalesSummaryReport
                    {
                        SlNo = MakeSafe.ToSafeInt32(row["Sl No"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        CarSales = MakeSafe.ToSafeInt32(row["No. of car sales"]),
                        SaleValue = MakeSafe.ToSafeDecimal(row["Sale Value"]),
                        Percentage = MakeSafe.ToSafeDecimal(row["Percentage"])
                        
                    });
                }
            }

            return model;
        }
    }
}