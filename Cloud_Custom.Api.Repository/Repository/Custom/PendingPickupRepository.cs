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
  public   class PendingPickupRepository : IPendingPickupRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public PendingPickupRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<PendingPickup> GetList(UserBase user ,int WorkshopCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
           
                 new SqlParameter("@WorkshopCode",WorkshopCode)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_PICKUP_DUE_LIST]", sqlparameters);
                return GetList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private PendingPickup GetList(DataSet dataSet)
        {
            PendingPickup model = new PendingPickup();
            List<PendingPickup> List = new List<PendingPickup>();
            
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new PendingPickup();

                    item.BookingCode = MakeSafe.ToSafeInt32(row["BookingCode"]);
                    item.BookingNo = MakeSafe.ToSafeString(row["BookingNo"]);
                    item.BookingName = MakeSafe.ToSafeString(row["BookingDate"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.CustomerAdd = MakeSafe.ToSafeString(row["CustomerAdd"]);
                    item.Mobile = MakeSafe.ToSafeString(row["Mobile"]);
                   
                    item.RegNo = MakeSafe.ToSafeString(row["RegNo"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.ServiceTypeName = MakeSafe.ToSafeString(row["ServiceType"]);
                    item.PreferedDate = MakeSafe.ToSafeString(row["PrefeeredDate"]);
                    item.PreferedTime = MakeSafe.ToSafeString(row["PreferredTime"]);
                   

                    List.Add(item);
                }
                model.pickuplist = List;
            }
            return model;

        }
    }
}
