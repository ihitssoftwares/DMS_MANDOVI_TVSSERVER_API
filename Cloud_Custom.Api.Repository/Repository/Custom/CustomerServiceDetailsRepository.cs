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
     public class CustomerServiceDetailsRepository : ICustomerServiceDetailsRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public CustomerServiceDetailsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<CustomerServiceDetails> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_CUSTOMER_SERVICE_LIST]", sqlparameters);
                return ModelList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private CustomerServiceDetails ModelList(DataSet dataSet)
        {
            CustomerServiceDetails model = new CustomerServiceDetails();
            List<CustomerServiceDetails> List = new List<CustomerServiceDetails>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new CustomerServiceDetails();
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
                    item.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                    List.Add(item);
                }
                model.List = List;
            }
            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, CustomerServiceDetails input)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_CUSTOMER_SERVICE_DETAILS_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<CustomerServiceDetails> GetCustomerDetails(UserBase User, int CustomerCode )
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@CustomerCode",CustomerCode),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_CUSTOMER_SERVICE_DETAILS]", sqlParameters);
            return PopulateModelDetails(dataSet);

        }

        private CustomerServiceDetails PopulateModelDetails(DataSet dataSet)
        {
            CustomerServiceDetails model = new CustomerServiceDetails();
            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                model.CustomerName = MakeSafe.ToSafeString(row["Name"]);
                model.City = MakeSafe.ToSafeString(row["City"]);
                model.Address1 = MakeSafe.ToSafeString(row["Address1"]);
                model.ContactNo = MakeSafe.ToSafeString(row["Phone"]);
                model.MailId = MakeSafe.ToSafeString(row["Email"]);
                model.RegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                model.ModelName = MakeSafe.ToSafeString(row["Model"]);
                model.VariantName = MakeSafe.ToSafeString(row["Variant"]);
                model.CarModel = new Dropdown { Code = MakeSafe.ToSafeInt32(row["ModelCode"]) };
                model.Variant = new Dropdown { Code = MakeSafe.ToSafeInt32(row["VariantCode"]) };
            }
            if (dataSet.Tables.Count > 1 && dataSet.Tables[1].Rows.Count > 0)
            {
                model.List = new List<CustomerServiceDetails>();
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    model.List.Add(new CustomerServiceDetails
                    {
                        
                        DtCode = MakeSafe.ToSafeInt32(row["DtCode"]),
                        CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]),
                        LastServiceDate = MakeSafe.ToSafeDateTime(row["LastServiceDate"]),
                        LastServiceType = MakeSafe.ToSafeString(row["LastServiceType"]),
                        RunningKM = MakeSafe.ToSafeString(row["RunningKM"]),
                        WorkShopName = MakeSafe.ToSafeString(row["WorkShopName"]),
                        ServiceAdvisorName = MakeSafe.ToSafeString(row["ServiceAdvisorName"]),
                        BillAmt = MakeSafe.ToSafeString(row["BillAmount"])
                    });
                }
            }
            return model;
        }
        public async Task<ResponseEntity> Delete(UserBase user, CustomerServiceDetails model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_ENTRY_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
