using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public class OrderBookingUploadRepository : IOrderBookingUploadRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public OrderBookingUploadRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ResponseEntity<List<BookingReportModel>>> OrderImportFromExcel(UserBase user, OrderBookingUpload model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),

                     new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };


            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_ORDER_BOOKING_UPLOAD_IMPORT_FROM_EXECL]", sqlParameters);
            var unmatchedDetails = PopulateUnmatchedDetails(ds);

            return new ResponseEntity<List<BookingReportModel>>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), unmatchedDetails);
        }
        public List<BookingReportModel> PopulateUnmatchedDetails(DataSet ds)
        {
            List<BookingReportModel> list = new List<BookingReportModel>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new BookingReportModel
                    {
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        CustomerCode = MakeSafe.ToSafeString(row["CustomerCode"]),
                        BookingNum = MakeSafe.ToSafeString(row["BookingNum"]),

                        Message = MakeSafe.ToSafeString(row["Message"]),
                    };

                    list.Add(item);
                }
            }

            return list;
        }

        public async Task<OrderBookingUpload> GetList(UserBase user, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_ORDER_BOOKING_UPLOAD_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public OrderBookingUpload PopulateGetList(DataSet ds)
        {
            OrderBookingUpload model = new OrderBookingUpload();
            List<OrderBookingUploadModel> List = new List<OrderBookingUploadModel>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new OrderBookingUploadModel
                    {
                        LeadNum = MakeSafe.ToSafeString(row["EnqNo"]),
                        OrderNo = MakeSafe.ToSafeString(row["OrderNo"]),
                        orderDate = MakeSafe.ToSafeString(row["Orderdate"]),
                        CustomerCode = MakeSafe.ToSafeString(row["CustomerNo"]),
                        Customer = MakeSafe.ToSafeString(row["Customer"]),
                        City = MakeSafe.ToSafeString(row["City"]),
                        State = MakeSafe.ToSafeString(row["State"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        
                        Color = MakeSafe.ToSafeString(row["Color"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        FuelType = MakeSafe.ToSafeString(row["Fuel"]),
                        Amount = MakeSafe.ToSafeString(row["Amount"]),
                        Branch = MakeSafe.ToSafeString(row["Branch"]),
                        OrderStatus=MakeSafe.ToSafeString(row["OrderStatus"])

                    };

                    List.Add(item);
                }
                model.OrderBookingUploadList = List;
            }

            return model;
        }
    }
}

