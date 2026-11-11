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
     public class VehicleOrderStatusRepository : IVehicleOrderStatusRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public VehicleOrderStatusRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<VehicleOrderStatus> GetList(UserBase user, string Fromdate, string ToDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@Fromdate",Fromdate),
                 new SqlParameter("@ToDate",ToDate),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_VEHICLE_ORDER_STATUS_LIST]", sqlparameters);
                return VehicleOrderStatusList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private VehicleOrderStatus VehicleOrderStatusList(DataSet dataSet)
        {
            VehicleOrderStatus model = new VehicleOrderStatus();
            List<VehicleOrderStatus> List = new List<VehicleOrderStatus>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                //model.Month = new Dropdown(); // bind once

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new VehicleOrderStatus();

                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.Address = MakeSafe.ToSafeString(row["Address"]);
                    item.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Varient = MakeSafe.ToSafeString(row["Variant"]);
                    item.OrderDate = MakeSafe.ToSafeString(row["OrderDate"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.Chasisno = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.Alloted = MakeSafe.ToSafeBool(row["Allotted"]);
                    item.Invoicegeneration = MakeSafe.ToSafeBool(row["InvoiceGeneration"]);
                    item.Registration = MakeSafe.ToSafeBool(row["Registration"]);
                    item.RegVerification = MakeSafe.ToSafeBool(row["Reg.Verification"]);
                    item.RegFinal = MakeSafe.ToSafeBool(row["Reg.FinalSubmit"]);
                    item.RTOProcessing = MakeSafe.ToSafeBool(row["RTOProcessing"]);
                    item.Delivery = MakeSafe.ToSafeBool(row["Delivery"]);
                    item.RegistrationCode = MakeSafe.ToSafeInt32(row["RegistrationCode"]);
                    item.OrdertrnCode = MakeSafe.ToSafeInt32(row["OrderTrnCode"]);

                    List.Add(item);
                }

                model.List = List;
            }

            return model;
        }
        public async Task<VehicleOrderStatus> Create(UserBase User, int RegistrationCode, int OrdertrnCode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@RegistrationCode",RegistrationCode),
                new SqlParameter("@OrdertrnCode",OrdertrnCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_VECHICLE_DELIVERY_DETAILS]", sqlParameters);
            return PopulateVehicleOrderStatus(dataSet);

        }

        private VehicleOrderStatus PopulateVehicleOrderStatus(DataSet dataSet)
        {
            VehicleOrderStatus model = new VehicleOrderStatus();

           
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0]; 

                model.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                model.Address = MakeSafe.ToSafeString(row["Address"]);
                model.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                model.Model = MakeSafe.ToSafeString(row["Model"]);
                model.Varient = MakeSafe.ToSafeString(row["Variant"]);
                
            }

            return model;
        }
    }
}
