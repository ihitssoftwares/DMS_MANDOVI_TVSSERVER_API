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
    public class VehiclesDeliveryRepository: IVehiclesDeliveryRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public VehiclesDeliveryRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<VehiclesDelivery> GetList(UserBase user, int Month, int Branch)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@monthCode",Month),
                
                 new SqlParameter("@BranchCode",Branch)



                };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_VEHICLES_DELIVERY_LIST]", sqlparameters);
                return VehiclesDeliveryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private VehiclesDelivery VehiclesDeliveryList(DataSet dataSet)
        {
            VehiclesDelivery model = new VehiclesDelivery();
            List<VehiclesDelivery> List = new List<VehiclesDelivery>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new VehiclesDelivery();



                    item.InvoiceNumber = MakeSafe.ToSafeString(row["Invoice Number"]);
                    item.InvoiceDate = MakeSafe.ToSafeString(row["Invoice Date"]);

                    item.BranchCode = MakeSafe.ToSafeInt32(row["Branch Code"]);
                    item.BranchName = MakeSafe.ToSafeString(row["Branch Name"]);

                    item.Customer = MakeSafe.ToSafeString(row["Customer"]);

                    item.ModelCode = MakeSafe.ToSafeInt32(row["Model Code"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);

                    item.VarientCode = MakeSafe.ToSafeInt32(row["Variant Code"]);
                    item.Varient = MakeSafe.ToSafeString(row["Variant"]);

                    item.ColourCode = MakeSafe.ToSafeInt32(row["Colour Code"]);
                    item.Colour = MakeSafe.ToSafeString(row["Colour"]);

                    item.VinNo = MakeSafe.ToSafeString(row["VIN No"]);
                    item.Executive = MakeSafe.ToSafeString(row["Executive"]);

                    item.SalesAmount = MakeSafe.ToSafeDecimal(row["Sales Amount"]);

                    item.OrderBookingNo = MakeSafe.ToSafeString(row["Order Booking No"]);
                    item.OrderTrnCode = MakeSafe.ToSafeInt32(row["Order Trn Code"]);



                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }


        public async Task<VehiclesDelivery> GetPopUpDetails(UserBase User, int OrderTrnCode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@OrderTrnCode",OrderTrnCode),
               

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_VEHICLES_DELIVERY_DETAILS]", sqlParameters);
            return PopulatePopupDetails(dataSet);

        }

        private VehiclesDelivery PopulatePopupDetails(DataSet dataSet)
        {
            VehiclesDelivery model = new VehiclesDelivery();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.InvoiceNumber = MakeSafe.ToSafeString(row["Invoice Number"]);
                model.InvoiceDate = MakeSafe.ToSafeString(row["Invoice Date"]);

                model.BranchCode = MakeSafe.ToSafeInt32(row["Branch Code"]);
                model.BranchName = MakeSafe.ToSafeString(row["Branch Name"]);

                model.Customer = MakeSafe.ToSafeString(row["Customer"]);

                model.ModelCode = MakeSafe.ToSafeInt32(row["Model Code"]);
                model.Model = MakeSafe.ToSafeString(row["Model"]);

                model.VarientCode = MakeSafe.ToSafeInt32(row["Variant Code"]);
                model.Varient = MakeSafe.ToSafeString(row["Variant"]);

                model.ColourCode = MakeSafe.ToSafeInt32(row["Colour Code"]);
                model.Colour = MakeSafe.ToSafeString(row["Colour"]);

                model.VinNo = MakeSafe.ToSafeString(row["VIN No"]);

                model.Executive = MakeSafe.ToSafeString(row["Executive"]);

                model.SalesAmount = MakeSafe.ToSafeDecimal(row["Sales Amount"]);

                model.OrderBookingNo = MakeSafe.ToSafeString(row["Order Booking No"]);
                model.ActaulFileName = MakeSafe.ToSafeString(row["ActaulFileName"]);
                model.AbsoluteUrl = MakeSafe.ToSafeString(row["AbsoluteUrl"]);

                model.OrderTrnCode = MakeSafe.ToSafeInt32(row["Order Trn Code"]);
                if (row["Vehicle Delivery Date"] != DBNull.Value)
                {
                    model.VehicleDeliveryDate =
                        Convert.ToDateTime(row["Vehicle Delivery Date"]).ToString("yyyy-MM-dd");
                }
                else
                {
                    model.VehicleDeliveryDate = "";
                }



            }

            return model;
        }


        public async Task<ResponseEntity> PopupSave(UserBase user, VehiclesDelivery vehicleModel)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(vehicleModel)),
                // new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_VEHICLES_DELIVERY_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

    }
}
