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
 public   class CustomerDocRepository : ICustomerDocRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public CustomerDocRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<CustomerDoc> GetList(UserBase user)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_CUSTOMER_DOCUMENTS_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public CustomerDoc PopulateGetList(DataSet ds)
        {
            CustomerDoc model = new CustomerDoc();
            model.CustomerDocsList= new List<CustomerDoc>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new CustomerDoc
                    {

                        TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]),
                        CusttomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        Address = MakeSafe.ToSafeString(row["Address"]),
                        MobileNo = MakeSafe.ToSafeString(row["Mobile"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        Aadhar = MakeSafe.ToSafeBool(row["Aadhar"]),
                        Status = MakeSafe.ToSafeString(row["AllotedStatus"]),
                        PAN = MakeSafe.ToSafeBool(row["Pan"]),
                        Passport = MakeSafe.ToSafeBool(row["Passport"]),
                        Photo = MakeSafe.ToSafeBool(row["Photo"]),
                        Insurance = MakeSafe.ToSafeBool(row["Insurance"]),
                        Form20 = MakeSafe.ToSafeBool(row["Form20"]),
                        Form21 = MakeSafe.ToSafeBool(row["Form21"]),
                        Form22 = MakeSafe.ToSafeBool(row["Form22"]),
                        Form34 = MakeSafe.ToSafeBool(row["Form34"]),
                        BankAccount = MakeSafe.ToSafeBool(row["BankAccount"]),

                    };

                    model.CustomerDocsList.Add(item);
                }
            }

            return model;
        }


        public async Task<CustomerDocItem> GetEmployeeDetails(UserBase user, int OrderNo)
        {
            
                IDbDataParameter[] sqlparameters =
               {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),
                new SqlParameter("@ORDERTRNCODE",OrderNo)


            };
               var ds = await _sql.GetDataSetAsync("[DMS].[SP_CUSTOMER_DOCUMENTS_DETAILS]", sqlparameters);

                return PopulateGetEmployeeDetails(ds);
            
        }
        public CustomerDocItem PopulateGetEmployeeDetails(DataSet ds)
        {

            CustomerDocItem model = new CustomerDocItem();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
               model = new CustomerDocItem
                  {

                        TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]),
                        CusttomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        EmailId = MakeSafe.ToSafeString(row["EmailId"]),
                        MobileNo = MakeSafe.ToSafeString(row["Mobile"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                   Status = MakeSafe.ToSafeString(row["AllotedStatus"]),


               };

                    
            }
            model.CustomerDocItemList = new List<CustomerDocItem>();
            if ((ds.Tables[1]?.Rows?.Count ?? 1) > 0)
            {

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new CustomerDocItem
                    {

                        DocCode = MakeSafe.ToSafeInt32(row["DOCUMENTCODE"]),
                        DocName = MakeSafe.ToSafeString(row["DOCUMENTNAME"]),
                        AbsoluteUrl = MakeSafe.ToSafeString(row["ABSOLUTEURI"]),
                        ActaulFileName = MakeSafe.ToSafeString(row["ACTUALFILENAME"]),

                    };

                    model.CustomerDocItemList.Add(item);
                }
            }


            return model;
        }
        public async Task<ResponseEntity> Save(UserBase user, CustomerDoc model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SAVE_CUSTOMER_DOCUMENTS]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }

}