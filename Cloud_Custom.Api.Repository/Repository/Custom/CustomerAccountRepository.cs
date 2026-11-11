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
    public class CustomerAccountRepository : ICustomerAccountRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public CustomerAccountRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<CustomerAccount> GetList(UserBase user)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_CUSTOMERACCOUNT_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public CustomerAccount PopulateGetList(DataSet ds)
        {
            CustomerAccount model = new CustomerAccount();
            model.CustomerAccountList = new List<CustomerAccount>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new CustomerAccount
                    {
                        OrderTrnCode = MakeSafe.ToSafeInt32(row["OrderTrnCode"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        Address = MakeSafe.ToSafeString(row["Address"]),
                        MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        AllotedStatus = MakeSafe.ToSafeString(row["AllotedStatus"]),
                        NetAmount = MakeSafe.ToSafeDecimal(row["NetAmount"]),
                        ReceivedAmount = MakeSafe.ToSafeDecimal(row["ReceivedAmount"]),
                        BalanceDue = MakeSafe.ToSafeDecimal(row["BalanceDue"]),
                        PerOfBalance = MakeSafe.ToSafeDecimal(row["PerOfBalance"])
                    };

                    model.CustomerAccountList.Add(item);
                }
            }

            return model;
        }
        public async Task<CustomeAccitem> GetAccList(UserBase user,int ordertrnCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@orderCode",ordertrnCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_CUSTOMERAccountReceipts_LIST]", sqlparameters);

            return PopulateGetAccList(ds);

        }
        public CustomeAccitem PopulateGetAccList(DataSet ds)
        {
            CustomeAccitem model = new CustomeAccitem();
            model.CustomeAccitemList = new List<CustomeAccitem>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new CustomeAccitem
                    {
                        TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]),
                        date = MakeSafe.ToSafeString(row["Date"]),
                        PaymentMode = MakeSafe.ToSafeString(row["paymentMode"]),
                        transactionNo = MakeSafe.ToSafeString(row["TransactionNo"]),
                        Amount = MakeSafe.ToSafeString(row["Amount"]),
                       
                    };

                    model.CustomeAccitemList.Add(item);
                }
            }

            return model;
        }

        public async Task<CustomerAccount> GetDetails(UserBase user, int OrderTrnCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@OrderTrnCode",OrderTrnCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_CUSTOMERACCOUNT_DETAILS]", sqlparameters);

            return PopulateGetCustomerOrderDetails(ds);

        }
        public CustomerAccount PopulateGetCustomerOrderDetails(DataSet ds)
        {

            CustomerAccount model = new CustomerAccount
            {
                CostPriceList = new List<CostPrice>()
            };
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {

                DataRow row = ds.Tables[0].Rows[0];
                model.OrderTrnCode = MakeSafe.ToSafeInt32(row["OrderTrnCode"]);
                model.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                model.Address = MakeSafe.ToSafeString(row["Address"]);
                model.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                model.Model = MakeSafe.ToSafeString(row["Model"]);
                model.Variant = MakeSafe.ToSafeString(row["Variant"]);
                model.AllotedStatus = MakeSafe.ToSafeString(row["AllotedStatus"]);
                model.NetAmount = MakeSafe.ToSafeDecimal(row["NetAmount"]);
                model.ReceivedAmount = MakeSafe.ToSafeDecimal(row["ReceivedAmount"]);
                model.BalanceDue = MakeSafe.ToSafeDecimal(row["BalanceDue"]);
                model.PerOfBalance = MakeSafe.ToSafeDecimal(row["PerOfBalance"]);
                model.ReceiptNo = MakeSafe.ToSafeString(row["ReceiptNo"]);

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


            return model;
        }



        public async Task<ResponseEntity> Save(UserBase user, CustomerAccount model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 1000, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_CUSTOMER_ACCOUNT_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}



