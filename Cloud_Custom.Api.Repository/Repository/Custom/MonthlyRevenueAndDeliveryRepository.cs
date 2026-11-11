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
   public  class MonthlyRevenueAndDeliveryRepository : IMonthlyRevenueAndDeliveryRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MonthlyRevenueAndDeliveryRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MonthlyRevenueAndDelivery> GetList(UserBase user, int WorkShop)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                    new SqlParameter("@WorkShop",WorkShop)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MONTHLYREVENUE_AND_DELIVERY_LIST]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MonthlyRevenueAndDelivery SummeryList(DataSet ds)
        {
            MonthlyRevenueAndDelivery model = new MonthlyRevenueAndDelivery();
            List<MonthlyRevenueAndDelivery> List = new List<MonthlyRevenueAndDelivery>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MonthlyRevenueAndDelivery();



                    item.MonthName = MakeSafe.ToSafeString(row["MonthName"]);
                    item.MonthNo = MakeSafe.ToSafeInt32(row["MonthNo"]);
                    
                    item.TotalBooking = MakeSafe.ToSafeInt32(row["TotalBookings"]);
                    
                    item.DeliveredVehicles = MakeSafe.ToSafeInt32(row["DeliveredVehicles"]);
                    
                    item.Revenue = MakeSafe.ToSafeDecimal(row["Revenue"]);



                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }
    }
}
