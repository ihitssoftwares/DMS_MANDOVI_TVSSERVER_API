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
   public  class AllotmentRepository : IAllotmentRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public AllotmentRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<Allotment> GetList(UserBase user,int Model,int Variant,string Status)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Model",Model),
                new SqlParameter("@Variant",Variant),
                //new SqlParameter("@Color",Color),
                new SqlParameter("@Status",Status),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_ALLOTMENT_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public Allotment PopulateGetList(DataSet ds)
        {
            Allotment model = new Allotment();
            model.AllotmentList = new List<Allotment>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new Allotment
                    {
                        OrderTrnCode = MakeSafe.ToSafeInt32(row["OrderTrnCode"]),
                        OrderNo = MakeSafe.ToSafeString(row["OrderNo"]),

                        OrderDate = MakeSafe.ToSafeString(row["OrderDate"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),                   
                        SalesExecutive = MakeSafe.ToSafeString(row["SalesExecutive"]),
                        EngineNo = MakeSafe.ToSafeString(row["EngineNo"]),
                        ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]),
                        color = MakeSafe.ToSafeString(row["Color"]),

                        Model = new Dropdown
                        {
                            Name = MakeSafe.ToSafeString(row["Model"]),
                            Code=MakeSafe.ToSafeInt32(row["ModelCode"])
                        },
                        variant = new Dropdown
                        {
                            Name = MakeSafe.ToSafeString(row["Variant"]),
                            Code = MakeSafe.ToSafeInt32(row["VariantCode"])
                        },
                        FuelType = MakeSafe.ToSafeString(row["FuelType"]),
                        Transmission = MakeSafe.ToSafeString(row["Transmission"]),
                        BookingAmountPaid = MakeSafe.ToSafeDecimal(row["BookingAmountPaid"]),
                        Address= MakeSafe.ToSafeString(row["Address"])

                    };

                    model.AllotmentList.Add(item);
                }
            }

            return model;
        }

        public async Task<AllotmentItem> GetDetails(UserBase user, int OrderTrnCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@OrderTrnCode",OrderTrnCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_ALLOTMENT_DETAILS]", sqlparameters);

            return PopulateGetEmployeeDetails(ds);

        }
        public AllotmentItem PopulateGetEmployeeDetails(DataSet ds)
        {

            AllotmentItem model = new AllotmentItem();
    
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {

                DataRow row = ds.Tables[0].Rows[0];

                model.Allotment = new Dropdown();
                model = new AllotmentItem

                {

                    OrderTrnCode = MakeSafe.ToSafeInt32(row["OrderTrnCode"]),
                    Model = MakeSafe.ToSafeString(row["Model"]),

                    variant = MakeSafe.ToSafeString(row["Variant"]),
                    Color = MakeSafe.ToSafeString(row["Color"]),
                    FuelType = MakeSafe.ToSafeString(row["FuelType"]),
                    Transmission = MakeSafe.ToSafeString(row["Transmission"]),
                    Allotment = new Dropdown
                    {
                        Name = MakeSafe.ToSafeString(row["Allotment"])
                    },
                    InvoiceNo = MakeSafe.ToSafeString(row["VinNo"]),
                    OrderNo = MakeSafe.ToSafeString(row["OrderNo"]),
                    OrderDate = MakeSafe.ToSafeDateTime(row["OrderDate"]),
                    CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),



                };

            }
            
            return model;
        }


        public async Task<AllotmentItem> GetInvoice(UserBase user, int Model, int Variant)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Model",Model),
                new SqlParameter("@Variant",Variant),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_INVOICE]", sqlparameters);

            return PopulateDetails(ds);

        }
        public AllotmentItem PopulateDetails(DataSet ds)
        {

            AllotmentItem model = new AllotmentItem();
            model.AllotmentItemList = new List<AllotmentItem>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new AllotmentItem
                    {


                        InvoiceNo = MakeSafe.ToSafeString(row["InvoiceNo"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),

                        variant = MakeSafe.ToSafeString(row["variant"]),
                        Color = MakeSafe.ToSafeString(row["color"]),
                        VehinNo = MakeSafe.ToSafeString(row["NewVehVin"]),


                    };
                    model.AllotmentItemList.Add(item);




                };

            }

            return model;
        }

        public async Task<ResponseEntity> Save(UserBase user, Allotment model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_ALLOTMENT_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
