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
    public class TodaysVehiclePickupReportRepository : ITodaysVehiclePickupReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public TodaysVehiclePickupReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<TodaysVehiclePickupReport> GetList(UserBase user, int BranchCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI", user.CompanyGuid),
                 new SqlParameter("@UserGuid", user.UserGuid),
                 new SqlParameter("@BranchCode", BranchCode),
                  



            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_TODAYVEHICLEPICKUPREPORT_LIST]", sqlparameters);
                return TodayvehiclepickupreportList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private TodaysVehiclePickupReport TodayvehiclepickupreportList(DataSet dataSet)
        {
            TodaysVehiclePickupReport model = new TodaysVehiclePickupReport();
            List<TodaysVehiclePickupReport> List = new List<TodaysVehiclePickupReport>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    TodaysVehiclePickupReport item = new TodaysVehiclePickupReport();
                    item.BookingCode = MakeSafe.ToSafeInt32(row["BookingCode"]);
                    item.BookingNumber = MakeSafe.ToSafeString(row["BookingNo"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.MobileNumber = MakeSafe.ToSafeString(row["MobileNo"]);
                    item.RegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNo"]);
                    item.PickUpDateTime = MakeSafe.ToSafeDateTime(row["PickupDateTime"]);
                    //item.VehicleCollectedTime = MakeSafe.ToSafeDateTime(row["VehicleCollectedTime"]);
                    item.WorkshopInTime = MakeSafe.ToSafeDateTime(row["WorkshopInTime"]);
                    item.StartKm = MakeSafe.ToSafeInt32(row["StartKm"]);
                    item.EndKm = MakeSafe.ToSafeInt32(row["EndKM"]);
                    item.PickUpAddress = MakeSafe.ToSafeString(row["PickUpAddress"]);
                    item.PickUpStatus = MakeSafe.ToSafeString(row["PickUpStatus"]);
                    item.DriverName = MakeSafe.ToSafeString(row["DriverName"]);
                    item.ModelName = MakeSafe.ToSafeString(row["ModeName"]);
                    item.VariantName = MakeSafe.ToSafeString(row["VariantName"]);

                    List.Add(item);
                }
                model.List = List;
            }

            return model;
        }




        public async Task<TodaysVehiclePickupReport> GetDetails(UserBase user, int Code)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Code",Code),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_TODAYSVEHICLE_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public TodaysVehiclePickupReport PopulateGetEmployeeDetails(DataSet ds)
        {

            TodaysVehiclePickupReport model = new TodaysVehiclePickupReport();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];


                model.BookingNumber = MakeSafe.ToSafeString(row["BookingNo"]);
                model.MobileNumber = MakeSafe.ToSafeString(row["MobileNo"]);

                model.RegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNo"]);
                model.PickUpDateTime = MakeSafe.ToSafeDateTime(row["PickUpDateTime"]);
                model.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                model.VehicleCollectedTime = MakeSafe.ToSafeDateTime(row["VehicleCollectedTime"]);
                model.WorkshopInTime = MakeSafe.ToSafeDateTime(row["WorkshopInTime"]);
                model.StartKm = MakeSafe.ToSafeInt32(row["StartKM"]);
                model.EndKm = MakeSafe.ToSafeInt32(row["EndKM"]);
                model.PickUpAddress = MakeSafe.ToSafeString(row["PickupAddress"]);
                model.PickUpStatus = MakeSafe.ToSafeString(row["PickupStatus"]);
                model.DriverName = MakeSafe.ToSafeString(row["DriverName"]);
                model.ModelName = MakeSafe.ToSafeString(row["ModeName"]);
                model.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
            }

            return model;
        }



    }


}
