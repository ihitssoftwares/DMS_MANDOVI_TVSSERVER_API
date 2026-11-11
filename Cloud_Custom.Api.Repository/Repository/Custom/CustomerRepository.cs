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
     public class CustomerRepository : ICustomerRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public CustomerRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Customer> GetList(UserBase user, Filter filter)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_CUSTOMER_LIST]", sqlparameters);
                return ModelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Customer ModelList(DataSet dataSet)
        {
            Customer model = new Customer();
            List<Customer> List = new List<Customer>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new Customer();
                    item.CarModel = new Dropdown();
                    item.Variant = new Dropdown();
                    item.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["Name"]);
                    item.City = MakeSafe.ToSafeString(row["City"]);
                    item.Address1 = MakeSafe.ToSafeString(row["Address"]);
                    item.ContactNo = MakeSafe.ToSafeString(row["Phone"]);
                    item.MailId = MakeSafe.ToSafeString(row["Email"]);
                    item.RegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.ModelName = MakeSafe.ToSafeString(row["Model"]);
                    item.VariantName = MakeSafe.ToSafeString(row["Variant"]);
                    item.VehicleStatus = MakeSafe.ToSafeString(row["VehicleStatus"]);
                    item.VinNo = MakeSafe.ToSafeString(row["VinNumber"]);
                    item.active = MakeSafe.ToSafeInt32(row["ACTIVE"]);
                    item.totalRecords = MakeSafe.ToSafeInt32(row["TotalCount"]);
                    List.Add(item);
                }
                model.List = List;
            }
            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, Customer input)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
                 new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_CUSTOMER_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<Customer> GetCustomerDetails(UserBase User, int CustomerCode, string mode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@CustomerCode",CustomerCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_CUSTOMER_DETAILS]", sqlParameters);
            return PopulateModelDetails(dataSet);

        }

        private Customer PopulateModelDetails(DataSet dataSet)
        {
            Customer model = new Customer();
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                model.CustomerName = MakeSafe.ToSafeString(row["Name"]);
                model.City = MakeSafe.ToSafeString(row["City"]);
                model.Address1 = MakeSafe.ToSafeString(row["Address1"]);
                model.Address2 = MakeSafe.ToSafeString(row["Address2"]);
                model.Address3 = MakeSafe.ToSafeString(row["Address3"]);
                model.ContactNo = MakeSafe.ToSafeString(row["Phone"]);
                model.MailId = MakeSafe.ToSafeString(row["Email"]);
                model.RegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                model.Sold = MakeSafe.ToSafeBool(row["IsSold"]);
                model.ModelName = MakeSafe.ToSafeString(row["Model"]);
                model.VariantName = MakeSafe.ToSafeString(row["Variant"]);
                model.CarModel = new Dropdown { Code = MakeSafe.ToSafeInt32(row["ModelCode"]) };
                model.Variant = new Dropdown { Code = MakeSafe.ToSafeInt32(row["VariantCode"]) };
            }
            return model;
        }
        public async Task<ResponseEntity> DeleteCustomer(UserBase user, Customer model)
        {
            try
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_CUSTOMER_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


        public async Task<ResponseEntity<List<Customer>>> CustomerImportFromExcel(UserBase user, Customer model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),

                     new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };


            var ds = await _sql.GetDataSetAsync("[DMS].[SP_CUSTOMER_IMPORT_FROM_EXCEL]", sqlParameters);
            var unmatchedDetails = PopulateUnmatchedDetails(ds);

            return new ResponseEntity<List<Customer>>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), unmatchedDetails);
        }
        public List<Customer> PopulateUnmatchedDetails(DataSet ds)
        {
            List<Customer> list = new List<Customer>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new Customer
                    {
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        ContactNo = MakeSafe.ToSafeString(row["ContactNo"]),
                        MailId = MakeSafe.ToSafeString(row["MailId"]),
                        RegNo = MakeSafe.ToSafeString(row["RegNo"]),
                        VinNo = MakeSafe.ToSafeString(row["VinNumber"]),
                        ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]),
                        EngineNo = MakeSafe.ToSafeString(row["EngineNo"]),
                        Message = MakeSafe.ToSafeString(row["Message"])

                    };

                    list.Add(item);
                }
            }

            return list;
        }


    }
}
