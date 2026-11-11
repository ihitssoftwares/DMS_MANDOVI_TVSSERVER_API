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
    public class RetailInvoiceExpenseAllocateRepository : IRetailInvoiceExpenseAllocateRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public RetailInvoiceExpenseAllocateRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<RetailInvoiceExpenseAllocate> GetList(UserBase user, int Month, string Status, string Branch)
        {
            IDbDataParameter[] sqlparameters =
            {
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                new SqlParameter("@UserGuid", user.UserGuid),
                new SqlParameter("@Month", Month),
                new SqlParameter("@Status", Status),
                new SqlParameter("@Branch",  Branch),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_EXPENSE_ALLOCATE_LIST]", sqlparameters);
            return PopulateGetList(ds);
        }

        public RetailInvoiceExpenseAllocate PopulateGetList(DataSet ds)
        {
            RetailInvoiceExpenseAllocate model = new RetailInvoiceExpenseAllocate();
            model.RetailInvoiceExpenseAllocateList = new List<RetailInvoiceExpenseAllocate>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.RetailInvoiceExpenseAllocateList.Add(new RetailInvoiceExpenseAllocate
                    {
                        HDCODE = MakeSafe.ToSafeInt32(row["SalesTrnCode"]),
                        InvNo = MakeSafe.ToSafeString(row["InvNo"]),
                        Date = MakeSafe.ToSafeString(row["Date"]),
                        StoreOrBranch = MakeSafe.ToSafeString(row["StoreOrBranch"]),
                        Executive = MakeSafe.ToSafeString(row["Executive"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        VariantColor = MakeSafe.ToSafeString(row["VariantColor"]),
                        EngineChasisNo = MakeSafe.ToSafeString(row["EngineChasisNo"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        SaleAmount = MakeSafe.ToSafeDecimal(row["SaleAmount"]),
                        ExpenseTotal = MakeSafe.ToSafeDecimal(row["ExpenseTotal"]),
                        NetAmount = MakeSafe.ToSafeDecimal(row["NetAmount"]),
                        //IsAllocated = Convert.ToBoolean(row["IsAllocated"]),
                        //AllocateStatus = MakeSafe.ToSafeString(row["AllocateStatus"]),
                        VehiclePurchaseCost = MakeSafe.ToSafeDecimal(row["VehiclePurchaseCost"]),
                    });
                }
            }

            return model;
        }

        public async Task<RetailInvoiceExpenseAllocate> GetPopupDetails(UserBase user, int SalesTrnCode)
        {
            IDbDataParameter[] sqlparameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGuid", user.UserGuid),
        new SqlParameter("@SalesTrnCode", SalesTrnCode),
    };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_EXPENSE_ALLOCATE_DETAILS]", sqlparameters);
            return PopulateGetFinanceDetails(ds);
        }

        public RetailInvoiceExpenseAllocate PopulateGetFinanceDetails(DataSet ds)
        {
            RetailInvoiceExpenseAllocate model = new RetailInvoiceExpenseAllocate();
            model.RetailInvoiceExpenseAllocateItem = new RetailInvoiceExpenseAllocateItem();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                model.RetailInvoiceExpenseAllocateItem.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                model.RetailInvoiceExpenseAllocateItem.Model = MakeSafe.ToSafeString(row["Model"]);
                model.RetailInvoiceExpenseAllocateItem.Variant = MakeSafe.ToSafeString(row["Variant"]);
                model.RetailInvoiceExpenseAllocateItem.VariantCode = MakeSafe.ToSafeString(row["VariantCode"]);
                model.RetailInvoiceExpenseAllocateItem.InvoiceNo = MakeSafe.ToSafeString(row["InvoiceNo"]);
                model.RetailInvoiceExpenseAllocateItem.InvoiceDate = MakeSafe.ToSafeString(row["InvoiceDate"]);
                model.RetailInvoiceExpenseAllocateItem.InvoiceAmount = MakeSafe.ToSafeDecimal(row["InvoiceAmount"]);
            }

            model.RetailInvoiceExpenseAllocateItem.ExpensesList = new List<RetailInvoiceExpenseAllocateItem>();
            if ((ds.Tables.Count > 1) && (ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.RetailInvoiceExpenseAllocateItem.ExpensesList.Add(new RetailInvoiceExpenseAllocateItem
                    {
                        Code = MakeSafe.ToSafeInt32(row["Code"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        Amount = row["Amount"] == DBNull.Value ? (decimal?)null : MakeSafe.ToSafeDecimal(row["Amount"]),
                        Remarks = MakeSafe.ToSafeString(row["Remarks"])
                    });
                }
            }

            return model;
        }


        public async Task<ResponseEntity> Save(UserBase user, RetailInvoiceExpenseAllocate model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                new SqlParameter("@UserGuid", user.UserGuid),
                new SqlParameter("@JSONDATA", JsonHelper.ToJson(model.RetailInvoiceExpenseAllocateItem)),
                ResponseKey, ResponseStatus
            };

            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_EXPENSE_ALLOCATE_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

    }
}