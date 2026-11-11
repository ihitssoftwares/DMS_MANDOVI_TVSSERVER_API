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
  public  class OrderBookingRepository : IOrderBookingRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public OrderBookingRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<LeadEnquiryUpdate> GetList(UserBase user, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Month",Month),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_LEAD_ENQUIRY_UPDATE_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public LeadEnquiryUpdate PopulateGetList(DataSet ds)
        {
            LeadEnquiryUpdate model = new LeadEnquiryUpdate();
            model.LeadEnquiryUpdateList = new List<LeadEnquiryUpdate>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new LeadEnquiryUpdate
                    {
                        EnqCode = MakeSafe.ToSafeInt32(row["EnqCode"]),
                        LeadNo = MakeSafe.ToSafeString(row["LeadNo"]),
                        Date = MakeSafe.ToSafeString(row["Date"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),
                        ModelCode = MakeSafe.ToSafeInt32(row["ModelCode"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        SalesExecutive = MakeSafe.ToSafeString(row["SalesExecutive"]),
                        StoreName = MakeSafe.ToSafeString(row["StoreName"]),
                    };

                    model.LeadEnquiryUpdateList.Add(item);
                }
            }

            return model;
        }





        public async Task<OrderBooking> GetLeadEnquiryDetails(UserBase user, int EnqCode, string LeadNo)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@EnqCode",EnqCode),
                new SqlParameter("@LeadNo",LeadNo),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_LEAD_ENQUIRY_DETAILS]", sqlparameters);

            return PopulateGetOrderBookingDetails(ds);

        }
        public OrderBooking PopulateGetOrderBookingDetails(DataSet ds)
        {
            OrderBooking model = new OrderBooking();
            model.CostPriceList = new List<CostPrice>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
               
                DataRow row = ds.Tables[0].Rows[0];

                model = new OrderBooking
                {

                    LeadEnqCode = MakeSafe.ToSafeInt32(row["LeadEnqCode"]),
                    OrderNo = MakeSafe.ToSafeString(row["OrderNo"]),
                    OrderDate = MakeSafe.ToSafeDateTime(row["OrderDate"]),
                    LeadNo = MakeSafe.ToSafeString(row["LeadNo"]),
                    Name = MakeSafe.ToSafeString(row["Name"]),
                    MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),
                    EmailID = MakeSafe.ToSafeString(row["EmailID"]),
                    Executive = MakeSafe.ToSafeInt32(row["Executive"]),
                    Model = MakeSafe.ToSafeInt32(row["Model"]),
                    FuelType=MakeSafe.ToSafeString(row["FuelType"]),
                    Transmission=MakeSafe.ToSafeString(row["Transmission"]),

                };
            }
            if (ds.Tables[1]?.Rows.Count > 0)
            {
                model.CostPriceList = new List<CostPrice>();

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new CostPrice
                    {
                        CostCode = MakeSafe.ToSafeInt32(row["CostCode"]),
                        CostName = MakeSafe.ToSafeString(row["CostName"]),
                        Amount = MakeSafe.ToSafeDecimal(row["Amount"]),
                    };

                    model.CostPriceList.Add(item);
                }
            }

            return model;
        }

        public async Task<ResponseEntity> OrderBooking(UserBase user, OrderBooking model)
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
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_ORDER_BOOKING_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }


        public async Task<OrderBooking> GetExShowroomPrice(UserBase user, int Model, int Variant, int Color, string FuelType, string Transmission, string OrderDate)
        {
            IDbDataParameter[] sqlparameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGuid", user.UserGuid),
        new SqlParameter("@Model", Model),
        new SqlParameter("@Variant", Variant),
        new SqlParameter("@Color", Color),
        new SqlParameter("@FuelType", FuelType),
        new SqlParameter("@Transmission", Transmission),
        new SqlParameter("@OrderDate", OrderDate),
    };

            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_EXSHOWROOM_PRICE]", sqlparameters);

            OrderBooking model = new OrderBooking();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.ExactShowroomPrice = MakeSafe.ToSafeDecimal(ds.Tables[0].Rows[0]["ExShowroomPrice"]);
            }

            return model;
        }
    }
}
