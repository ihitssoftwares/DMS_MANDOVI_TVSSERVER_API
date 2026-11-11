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
    public class BookingAndRetailReportRepository: IBookingAndRetailReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public BookingAndRetailReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<BookingAndRetailReport> GetList(UserBase user,string Type, string FromDate , string ToDate, int Month)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                    new SqlParameter("@Type",Type),
                    new SqlParameter("@FromDate",FromDate),
                    new SqlParameter("@ToDate",ToDate),
                    new SqlParameter("@Month",Month)

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BOOKING_RETAIL_SUMMARY]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private BookingAndRetailReport SummeryList(DataSet ds)
        {
           
            BookingAndRetailReport model = new BookingAndRetailReport();
            model.List = new List<BookingAndRetailReport>();
            if (ds.Tables.Count > 0 && (ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new BookingAndRetailReport();

                    //item.GroupKey = MakeSafe.ToSafeInt32(row["GroupKey"]);
                    item.GroupName = MakeSafe.ToSafeString(row["GroupName"]);
                    item.TotalBooking = MakeSafe.ToSafeInt32(row["TotalBooking"]);
                    item.BookingCancel = MakeSafe.ToSafeInt32(row["BookingCancel"]);
                    item.NetBooking = MakeSafe.ToSafeInt32(row["NetBooking"]);
                    item.TotalRetail = MakeSafe.ToSafeInt32(row["TotalRetail"]);
                    item.RetailCancel = MakeSafe.ToSafeInt32(row["RetailCancel"]);
                    item.NetRetail = MakeSafe.ToSafeInt32(row["NetRetail"]);
                    item.PendingBooking = MakeSafe.ToSafeInt32(row["PendingBooking"]);
                    item.Retailance = MakeSafe.ToSafeInt32(row["RetailCancel"]);
                    model.List.Add(item);
                }
            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                var d = ds.Tables[1].Rows[0];
                model.FromDate = d["FromDate"] == DBNull.Value ? (DateTime?)null : MakeSafe.ToSafeDateTime(d["FromDate"]);
                model.ToDate = d["ToDate"] == DBNull.Value ? (DateTime?)null : MakeSafe.ToSafeDateTime(d["ToDate"]);
            }

            return model;
        }
    }
}
