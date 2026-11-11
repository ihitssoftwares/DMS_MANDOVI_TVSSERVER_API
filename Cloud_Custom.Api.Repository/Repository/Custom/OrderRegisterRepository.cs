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
  public  class OrderRegisterRepository : IOrderRegisterRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public OrderRegisterRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<OrderBooking> GetList(UserBase user,string DateFilterType, string FromDate, string ToDate,string Status)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@DateFilterType",DateFilterType),
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                new SqlParameter("@Status",Status),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_ORDER_REGISTER_LIST]", sqlparameters);

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
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_ORDER_REGISTER_DETAILS]", sqlparameters);

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
                model.SalesExecutive = MakeSafe.ToSafeString(row["SalesExecutive"]);
                model.FatherOrSpouse = MakeSafe.ToSafeString(row["FatherOrSpouse"]);
                model.AlternateMobileNo = MakeSafe.ToSafeString(row["AlternateMobileNo"]);
                model.Address1 = MakeSafe.ToSafeString(row["Address1"]);
                model.Address2 = MakeSafe.ToSafeString(row["Address2"]);
                model.Address3 = MakeSafe.ToSafeString(row["Address3"]);
                model.PinCode = MakeSafe.ToSafeInt32(row["PinCode"]);
                model.PanNo = MakeSafe.ToSafeString(row["PanNo"]);
                model.AadharNo = MakeSafe.ToSafeString(row["AadharNo"]);
                model.GstNo = MakeSafe.ToSafeString(row["GstNo"]);

                model.ModelName = MakeSafe.ToSafeString(row["ModelName"]);
                model.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
                model.FuelType = MakeSafe.ToSafeString(row["FuelType"]);
                model.Transmission = MakeSafe.ToSafeString(row["Transmission"]);
                model.ColorName = MakeSafe.ToSafeString(row["ColorName"]);
                model.ExactShowroomPrice = MakeSafe.ToSafeDecimal(row["ExactShowroomPrice"]);
                model.ExpectedDeliveryDate = MakeSafe.ToSafeDateTime(row["ExpectedDeliveryDate"]);
                model.BookingAmountPaid = MakeSafe.ToSafeDecimal(row["BookingAmountPaid"]);
                model.PaymentType = MakeSafe.ToSafeString(row["PaymentType"]);
                model.ChequeOrTransNo = MakeSafe.ToSafeString(row["ChequeOrTransNo"]);
                model.BalanceAmount = MakeSafe.ToSafeDecimal(row["BalanceAmount"]);
                model.FianceRequired = MakeSafe.ToSafeBool(row["FianceRequired"]);
                model.BankName = MakeSafe.ToSafeString(row["BankName"]);
                model.LoanAmount = MakeSafe.ToSafeDecimal(row["LoanAmount"]);
                model.ExchangeModel = MakeSafe.ToSafeString(row["ExchangeModel"]);
                model.RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]);
                model.Year = MakeSafe.ToSafeInt32(row["Year"]);
                model.ExchangeAmount = MakeSafe.ToSafeDecimal(row["ExchangeAmount"]);
                model.YearsOfWarranty = MakeSafe.ToSafeString(row["YearsOfWarranty"]);
                model.InsuranceName = MakeSafe.ToSafeString(row["InsuranceName"]);
                model.InsuranceTypeName = MakeSafe.ToSafeString(row["InsuranceTypeName"]);
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
                        ItemName = MakeSafe.ToSafeString(row["ItemName"]),
                        Amount = MakeSafe.ToSafeDecimal(row["Amount"]),
                        Quantity = MakeSafe.ToSafeInt32(row["Quantity"])
                    });
                }
            }

            return model;
        }

      
    }
}
