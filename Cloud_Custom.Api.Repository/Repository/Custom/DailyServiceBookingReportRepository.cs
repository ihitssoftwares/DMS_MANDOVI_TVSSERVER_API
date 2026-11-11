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
    public class DailyServiceBookingReportRepository : IDailyServiceBookingReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public DailyServiceBookingReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<DailyServiceBookingReport> GetList(UserBase user, int BranchCode,DateTime PreferredDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI", user.CompanyGuid),
                 new SqlParameter("@UserGuid", user.UserGuid),
                 new SqlParameter("@BranchCode", BranchCode),
                 new SqlParameter("@PreferredDate", PreferredDate),



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_DAILYSERVICEBOOKINGREPORT_LIST]", sqlparameters);
                return DailyservicebookingList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private DailyServiceBookingReport DailyservicebookingList(DataSet dataSet)
        {
            DailyServiceBookingReport model = new DailyServiceBookingReport();
            List<DailyServiceBookingReport> List = new List<DailyServiceBookingReport>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    DailyServiceBookingReport item = new DailyServiceBookingReport();

                    item.BookingNumber = MakeSafe.ToSafeString(row["BookingNo"]);
                    item.BookingDate = MakeSafe.ToSafeDateTime(row["BookingDate"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.MobileNumber = MakeSafe.ToSafeString(row["MobileNo"]);
                    item.RegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNo"]);
                    item.CustomerAddress = MakeSafe.ToSafeString(row["CustomerAddress"]);

                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Varient = MakeSafe.ToSafeString(row["Varient"]);
                    item.Odometer = MakeSafe.ToSafeInt32(row["Odometer"]);

                    item.BookingStatus = MakeSafe.ToSafeString(row["BookingStatus"]);
                    item.PreferredDate = MakeSafe.ToSafeDateTime(row["PreferredDate"]);
                    item.EstimatedCost = MakeSafe.ToSafeDecimal(row["EstimatedCost"]);



                    List.Add(item);
                }
                model.List = List;
            }

            return model;
        }
    }
}
