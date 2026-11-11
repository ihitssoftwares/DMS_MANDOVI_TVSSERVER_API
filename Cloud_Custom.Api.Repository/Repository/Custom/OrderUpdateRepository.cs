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
  public  class OrderUpdateRepository : IOrderUpdateRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public OrderUpdateRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<OrderBooking> GetList(UserBase user, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Month",Month),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_ORDER_BOOKING_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public OrderBooking PopulateGetList(DataSet ds)
        {
            OrderBooking model = new OrderBooking();
            model.OrderBookingList = new List<OrderBooking>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new OrderBooking
                    {
                        OrderTrnCode = MakeSafe.ToSafeInt32(row["OrderTrnCode"]),
                        OrderNo = MakeSafe.ToSafeString(row["OrderNo"]),
                        OrderDate = MakeSafe.ToSafeDateTime(row["OrderDate"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),
                        ModelName = MakeSafe.ToSafeString(row["ModelName"]),
                        SalesExecutive = MakeSafe.ToSafeString(row["SalesExecutive"]),
                    };

                    model.OrderBookingList.Add(item);
                }
            }

            return model;
        }





        public async Task<OrderBooking> GetOrderBookingDetails(UserBase user, int OrderTrnCode, string OrderNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@OrderTrnCode",OrderTrnCode),
                new SqlParameter("@OrderNo",OrderNo),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_ORDER_BOOKING_DETAILS]", sqlparameters);

            return PopulateGetOrderBookingDetails(ds);

        }
        public OrderBooking PopulateGetOrderBookingDetails(DataSet ds)
        {
            OrderBooking model = new OrderBooking
            {
                CostPriceList = new List<CostPrice>(),
                AccessoriesList = new List<Accessories>()
            };

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.OrderTrnCode = MakeSafe.ToSafeInt32(row["OrderTrnCode"]);
                model.LeadEnqCode = MakeSafe.ToSafeInt32(row["LeadEnqCode"]);
                model.OrderNo = MakeSafe.ToSafeString(row["OrderNo"]);
                model.OrderDate = MakeSafe.ToSafeDateTime(row["OrderDate"]);
                model.LeadNo = MakeSafe.ToSafeString(row["LeadNo"]);
                model.Name = MakeSafe.ToSafeString(row["Name"]);
                model.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                model.EmailID = MakeSafe.ToSafeString(row["EmailID"]);
                model.Executive = MakeSafe.ToSafeInt32(row["Executive"]);
                model.FatherOrSpouse = MakeSafe.ToSafeString(row["FatherOrSpouse"]);
                model.AlternateMobileNo = MakeSafe.ToSafeString(row["AlternateMobileNo"]);
                model.Address1 = MakeSafe.ToSafeString(row["Address1"]);
                model.Address2 = MakeSafe.ToSafeString(row["Address2"]);
                model.Address3 = MakeSafe.ToSafeString(row["Address3"]);
                model.PinCode = MakeSafe.ToSafeInt32(row["PinCode"]);
                model.PanNo = MakeSafe.ToSafeString(row["PanNo"]);
                model.AadharNo = MakeSafe.ToSafeString(row["AadharNo"]);
                model.GstNo = MakeSafe.ToSafeString(row["GstNo"]);

                model.Model = MakeSafe.ToSafeInt32(row["Model"]);
                model.Variant = MakeSafe.ToSafeInt32(row["Variant"]);
                model.FuelType = MakeSafe.ToSafeString(row["FuelType"]);
                model.Transmission = MakeSafe.ToSafeString(row["Transmission"]);
                model.Color = MakeSafe.ToSafeInt32(row["Color"]);
                model.ExactShowroomPrice = MakeSafe.ToSafeDecimal(row["ExactShowroomPrice"]);
                model.ExpectedDeliveryDate = MakeSafe.ToSafeDateTime(row["ExpectedDeliveryDate"]);
                model.BookingAmountPaid = MakeSafe.ToSafeDecimal(row["BookingAmountPaid"]);
                model.PaymentMode = MakeSafe.ToSafeInt32(row["PaymentMode"]);
                model.ChequeOrTransNo = MakeSafe.ToSafeString(row["ChequeOrTransNo"]);
                model.BalanceAmount = MakeSafe.ToSafeDecimal(row["BalanceAmount"]);
                model.FianceRequired = MakeSafe.ToSafeBool(row["FianceRequired"]);
                model.BankOrNBFC = MakeSafe.ToSafeInt32(row["BankOrNBFC"]);
                model.LoanAmount = MakeSafe.ToSafeDecimal(row["LoanAmount"]);
                model.ExchangeModel = MakeSafe.ToSafeString(row["ExchangeModel"]);
                model.RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]);
                model.Year = MakeSafe.ToSafeInt32(row["Year"]);
                model.ExchangeAmount = MakeSafe.ToSafeDecimal(row["ExchangeAmount"]);
                model.WarrantyYears = MakeSafe.ToSafeInt32(row["WarrantyYears"]);
                model.InsuranceType = MakeSafe.ToSafeInt32(row["InsuranceType"]);
                model.InsuranceCompany = MakeSafe.ToSafeInt32(row["InsuranceCompany"]);
            }

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.CostPriceList.Add(new CostPrice
                    {
                        CostCode = MakeSafe.ToSafeInt32(row["CostCode"]),
                        CostName = MakeSafe.ToSafeString(row["CostName"]),
                        Amount = MakeSafe.ToSafeDecimal(row["Amount"])
                    });
                }
            }

            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    model.AccessoriesList.Add(new Accessories
                    {
                        ItemCode = MakeSafe.ToSafeInt32(row["ItemCode"]),
                        Amount = MakeSafe.ToSafeDecimal(row["Amount"]),
                        Quantity = MakeSafe.ToSafeInt32(row["Quantity"])
                    });
                }
            }

            return model;
        }

        public async Task<ResponseEntity> OrderBookingUpdate(UserBase user, OrderBooking model)
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
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_ORDER_BOOKING_UPDATE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
 
        public async Task<ResponseEntity<Decimal>> GetRatePerItem(UserBase user, int ItemCode)
        {
          
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            SqlParameter Amount = new SqlParameter { ParameterName = "@Amount", SqlDbType = SqlDbType.Decimal, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
                                new SqlParameter("@ItemCode", ItemCode),


                 ResponseKey,ResponseStatus,Amount
            };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_GET_ITEM_AMOUNT_BY_CODE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity<Decimal>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), Convert.ToDecimal(Amount.Value));
            
        }
    }
}
