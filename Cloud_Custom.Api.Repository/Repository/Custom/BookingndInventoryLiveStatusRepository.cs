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
  public   class BookingndInventoryLiveStatusRepository : IBookingndInventoryLiveStatusRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public BookingndInventoryLiveStatusRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<BookingndInventoryLiveStatus> GetList(UserBase user,int Type,int ModelCode, int RegionCode,int BranchCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Type",Type),
                new SqlParameter("@ModelCode",ModelCode),
                new SqlParameter("@RegionCode",RegionCode),
                new SqlParameter("@BranchCode",BranchCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_VEHICLE_STOCK_BOOKING_SUMMARY]", sqlparameters);

            return PopulateGetList(ds);

        }
        public BookingndInventoryLiveStatus PopulateGetList(DataSet ds)
        {
            BookingndInventoryLiveStatus model = new BookingndInventoryLiveStatus();
            model.BookingList = new List<BookingndInventoryLiveStatus>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new BookingndInventoryLiveStatus
                    {
                        ModelCode = MakeSafe.ToSafeInt32(row["modelCode"]),
                        ModelName = MakeSafe.ToSafeString(row["Model"]),
                        VariantCode = MakeSafe.ToSafeInt32(row["VariantCode"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        ColourCode = MakeSafe.ToSafeInt32(row["ColorCode"]),
                        Colour = MakeSafe.ToSafeString(row["color"]),
                       
                        PendingBokking = MakeSafe.ToSafeInt32(row["TotalBooking"]),
                        Instock = MakeSafe.ToSafeInt32(row["Instock"]),
                        Intransit = MakeSafe.ToSafeInt32(row["InTransit"]),
                        TotalStock = MakeSafe.ToSafeInt32(row["TotalStock"]),
                        Allotted = MakeSafe.ToSafeInt32(row["Alloted"]),
                        FreeStock = MakeSafe.ToSafeInt32(row["FreeStock"])
                    };

                    model.BookingList.Add(item);
                }
            }

            return model;
        }

        public async Task<DataSet> GetDetails(UserBase userBase,string Type, int ModelCode, int Variant, int Color,int Region,int Branch,int GroupBy)
        {
            IDbDataParameter[] sqlparameters =
           {
    
                new SqlParameter("@Type",Type),
                new SqlParameter("@ModelCode",ModelCode),
                new SqlParameter("@VariantCode",Variant),
                new SqlParameter("@ColorCode",Color),
                new SqlParameter("@RegionCode",Region),
                new SqlParameter("@BranchCode",Branch),
                new SqlParameter("@GroupBy",GroupBy),
            };
            var ds = await _sql.GetDataSetAsync("DMS.[SP_VEHICLE_STOCK_BOOKING_DETAIL]", sqlparameters);
            return ds;
        }
    }
}
