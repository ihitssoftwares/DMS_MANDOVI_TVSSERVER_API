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
    public class StockAgeingSummaryRepository : IStockAgeingSummaryRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public StockAgeingSummaryRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<StockAgeingSummary> GetList(UserBase user, string Type, string Status, string Groupby,int Model,int Variant,int Color)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                    new SqlParameter("@Type",Type),
                    new SqlParameter("@Status",Status),
                    new SqlParameter("@Groupby",Groupby),
                    new SqlParameter("@Model",Model),
                    new SqlParameter("@Variant",Variant),
                    new SqlParameter("@Color",Color),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_STOCK_AGEING_SUMMERY_LIST]", sqlparameters);
                return ModelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private StockAgeingSummary ModelList(DataSet dataSet)
        {
            var model = new StockAgeingSummary
            {
                StockAgeingSummaryList = new List<StockAgeingSummary>(),
                GrandTotalList = new List<GrandTotal>()
            };

            // ✅ Table 0 → Main Data
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new StockAgeingSummary
                    {
                        Particular = MakeSafe.ToSafeString(row["Particular"]),
                        Metric = MakeSafe.ToSafeString(row["Metric"]),
                        ZeroTo15 = MakeSafe.ToSafeDecimal(row["0-15"]),
                        SixteenTo30 = MakeSafe.ToSafeDecimal(row["16-30"]),
                        ThirtyOneTo60 = MakeSafe.ToSafeDecimal(row["31-60"]),
                        SixtyOneTo90 = MakeSafe.ToSafeDecimal(row["61-90"]),
                        NinetyTo180 = MakeSafe.ToSafeDecimal(row["91-180"]),
                        GreaterThan180 = MakeSafe.ToSafeDecimal(row[">180"]),
                        TotalAmount = MakeSafe.ToSafeDecimal(row["Value"])
                    };

                    model.StockAgeingSummaryList.Add(item); // ✅ IMPORTANT
                }
            }

            // ✅ Table 1 → Grand Total
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new GrandTotal
                    {
                        Particular = MakeSafe.ToSafeString(row["Particular"]),
                        Metric = MakeSafe.ToSafeString(row["Metric"]),
                        ZeroTo15 = MakeSafe.ToSafeDecimal(row["0-15"]),
                        SixteenTo30 = MakeSafe.ToSafeDecimal(row["16-30"]),
                        ThirtyOneTo60 = MakeSafe.ToSafeDecimal(row["31-60"]),
                        SixtyOneTo90 = MakeSafe.ToSafeDecimal(row["61-90"]),
                        NinetyTo180 = MakeSafe.ToSafeDecimal(row["91-180"]),
                        GreaterThan180 = MakeSafe.ToSafeDecimal(row[">180"]),
                        TotalAmount = MakeSafe.ToSafeDecimal(row["Value"])
                    };

                    model.GrandTotalList.Add(item);
                }
            }

            return model;
        }
    }
}
