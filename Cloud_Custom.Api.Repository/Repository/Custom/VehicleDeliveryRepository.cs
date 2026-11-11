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
     public class VehicleDeliveryRepository  : IVehicleDeliveryRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public VehicleDeliveryRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        //[DMS].[SP_VECHICLE_DELIVERY_LIST]  [DMS].[SP_VECHICLE_DELIVERY_DETAILS]
        public async Task<VehicleDelivery> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_VECHICLE_DELIVERY_LIST]", sqlparameters);
                return VehicleDeliveryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private VehicleDelivery VehicleDeliveryList(DataSet dataSet)
        {
            VehicleDelivery model = new VehicleDelivery();
            List<VehicleDelivery> List = new List<VehicleDelivery>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
        

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new VehicleDelivery();

                    item.RegistrationCode = MakeSafe.ToSafeInt32(row["REGISTRATIONCODE"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.Address = MakeSafe.ToSafeString(row["Address"]);
                    item.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                    //model.Model.Code = MakeSafe.ToSafeInt32(row["ModelId"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Varient = MakeSafe.ToSafeString(row["Variant"]);
                    item.ColorName = MakeSafe.ToSafeString(row["COLOR"]);
                    item.VehicleNo = MakeSafe.ToSafeString(row["VECHICLENO"]);
                    item.OrdertrnCode = MakeSafe.ToSafeInt32(row["ORDERTRNCODE"]);
                    List.Add(item);
                }

                model.List = List;
            }

            return model;
        }


        public async Task<VehicleDelivery> GetDetails(UserBase User, int RegistrationCode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@RegistrationCode",RegistrationCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_VECHICLE_DELIVERY_DETAILS]", sqlParameters);
            return PopulateVariantDetails(dataSet);

        }

        private VehicleDelivery PopulateVariantDetails(DataSet dataSet)
        {
            VehicleDelivery model = new VehicleDelivery();

            // -------- TABLE 0 (Vehicle Details) --------
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0]; // 👈 ONLY FIRST ROW

                model.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                model.Address = MakeSafe.ToSafeString(row["Address"]);
                model.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                model.Model = MakeSafe.ToSafeString(row["Model"]);
                model.Varient = MakeSafe.ToSafeString(row["Variant"]);
                model.ColorName = MakeSafe.ToSafeString(row["COLOR"]);
                model.VehicleNo = MakeSafe.ToSafeString(row["VECHICLENO"]);
                model.TransmissionName = MakeSafe.ToSafeString(row["TRANSMISSIONTYPE"]);
                model.FuelName = MakeSafe.ToSafeString(row["FUELTYPE"]);
                model.EngineNo = MakeSafe.ToSafeString(row["ENGINENO"]);
                model.ChasisNo = MakeSafe.ToSafeString(row["CHASSISNO"]);
                model.MODELCODE = MakeSafe.ToSafeInt32(row["MODELCODE"]);
                model.VARIANTCODE = MakeSafe.ToSafeInt32(row["VARIANTCODE"]);
                model.COLORCODE = MakeSafe.ToSafeInt32(row["COLORCODE"]);
                model.TRANSMISSIONCODE = MakeSafe.ToSafeInt32(row["TRANSMISSIONCODE"]);
                model.FUELTYPECODE = MakeSafe.ToSafeInt32(row["FUELTYPECODE"]);
                model.OrdertrnCode = MakeSafe.ToSafeInt32(row["ORDERTRNCODE"]);
            }

            // -------- TABLE 1 (Checklist) --------
            List<VehicleDelivery> checklistList = new List<VehicleDelivery>();

            if (dataSet.Tables.Count > 1)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    checklistList.Add(new VehicleDelivery
                    {
                        CheckListCode = MakeSafe.ToSafeInt32(row["CODE"]),
                        ChecklistName = MakeSafe.ToSafeString(row["NAME"]),
                        IsAppplicable = MakeSafe.ToSafeInt32(row["APPLICABLITY"]) == 1
                    });
                }
            }

            model.Checklist = checklistList;

            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, VehicleDelivery model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
               new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_VECHICLE_DELIVERY_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
