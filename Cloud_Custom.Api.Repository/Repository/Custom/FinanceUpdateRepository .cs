using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
    public class FinanceUpdateRepository : IFinanceUpdateRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public FinanceUpdateRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<FinanceUpdate> GetList(UserBase user, int Month, string Status,string Branch)
        {
            IDbDataParameter[] sqlparameters =
            {
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                new SqlParameter("@UserGuid", user.UserGuid),
                new SqlParameter("@Month", Month),
                new SqlParameter("@Status", Status),
                new SqlParameter("@Branch", Branch),
 
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_FILE_FINANCE_UPDATE_LIST]", sqlparameters);
            return PopulateGetList(ds);
        }

        public FinanceUpdate PopulateGetList(DataSet ds)
        {
            FinanceUpdate model = new FinanceUpdate();
            model.FinanceUpdateList = new List<FinanceUpdate>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.FinanceUpdateList.Add(new FinanceUpdate
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
                        SalesAmount = MakeSafe.ToSafeDecimal(row["SaleAmount"]),
                        ReceivablesTotal = MakeSafe.ToSafeDecimal(row["ReceivablesTotal"]),
                        ExpenseTotal = MakeSafe.ToSafeDecimal(row["ExpenseTotal"]),
                        DiscountTotal = MakeSafe.ToSafeDecimal(row["DiscountTotal"]),
                        NetAmount = MakeSafe.ToSafeString(row["NetAmount"]),
                        VehiclePurchaseCost = MakeSafe.ToSafeDecimal(row["VehiclePurchaseCost"])
                    });
                }
            }

            return model;
        }
        public async Task<FinanceUpdate> GetExportToExcel(UserBase user, int Month, string Status, string Branch)
        {
            IDbDataParameter[] sqlparameters =
            {
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                new SqlParameter("@UserGuid", user.UserGuid),
                new SqlParameter("@Month", Month),
                new SqlParameter("@Status", Status),
                new SqlParameter("@Branch", Branch),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_FILE_FINANCE_UPDATE_EXPORT_LIST]", sqlparameters);
            return PopulateGetExportToExcel(ds);
        }

        public FinanceUpdate PopulateGetExportToExcel(DataSet ds)
        {
            FinanceUpdate model = new FinanceUpdate();
            model.FinanceUpdateList = new List<FinanceUpdate>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.FinanceUpdateList.Add(new FinanceUpdate
                    {
                        HDCODE = MakeSafe.ToSafeInt32(row["SalesTrnCode"]),
                        InvNo = MakeSafe.ToSafeString(row["InvNo"]),
                        Date = MakeSafe.ToSafeString(row["Date"]),
                        StoreOrBranch = MakeSafe.ToSafeString(row["StoreOrBranch"]),
                        Executive = MakeSafe.ToSafeString(row["Executive"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        Color = MakeSafe.ToSafeString(row["Color"]),
                        EngineNo = MakeSafe.ToSafeString(row["EngineNo"]),
                        ChasisNo = MakeSafe.ToSafeString(row["ChasisNo"]),
                        SalesAmount = MakeSafe.ToSafeDecimal(row["SaleAmount"]),
                        VehiclePurchaseCost = MakeSafe.ToSafeDecimal(row["VehiclePurchaseCost"]),
                        ReceivablesTotal = MakeSafe.ToSafeDecimal(row["ReceivablesTotal"]),
                        DiscountTotal = MakeSafe.ToSafeDecimal(row["DiscountTotal"]),
                        ExpenseTotal = MakeSafe.ToSafeDecimal(row["ExpenseTotal"]),
                        NetAmount = MakeSafe.ToSafeString(row["NetAmount"]),
                        VerifyStatus = MakeSafe.ToSafeString(row["VerifyStatus"])
                    });
                }
            }

            return model;
        }
        public async Task<FinanceUpdate> GetFinanceDetails(UserBase user, int SalesTrnCode)
        {
            IDbDataParameter[] sqlparameters =
            {
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                new SqlParameter("@UserGuid", user.UserGuid),
                new SqlParameter("@SalesTrnCode", SalesTrnCode),
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_FINANCE_UPDATE_DETAILS]", sqlparameters);
            return PopulateGetFinanceDetails(ds);
        }

        public FinanceUpdate PopulateGetFinanceDetails(DataSet ds)
        {
            FinanceUpdate model = new FinanceUpdate();
            model.FinanceUpdateItem = new FinanceUpdateItem();

            // Table 0 : header
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                model.FinanceUpdateItem.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                model.FinanceUpdateItem.Model = MakeSafe.ToSafeString(row["Model"]);
                model.FinanceUpdateItem.Variant = MakeSafe.ToSafeString(row["Variant"]);
                model.FinanceUpdateItem.VariantCode = MakeSafe.ToSafeString(row["VariantCode"]);
                model.FinanceUpdateItem.InvoiceNo = MakeSafe.ToSafeString(row["InvoiceNo"]);
                model.FinanceUpdateItem.InvoiceDate = MakeSafe.ToSafeString(row["InvoiceDate"]);
                model.FinanceUpdateItem.InvoiceAmount = MakeSafe.ToSafeDecimal(row["InvoiceAmount"]);
                model.FinanceUpdateItem.DeliVeryDate = MakeSafe.ToSafeDateTime(row["DeliVeryDate"]);
                model.FinanceUpdateItem.PurhaseCostPrice = MakeSafe.ToSafeDecimal(row["PurhaseCostPrice"]);
                model.FinanceUpdateItem.VinNo = MakeSafe.ToSafeString(row["NewVehVIN"]);
                model.FinanceUpdateItem.ValidationMessage = MakeSafe.ToSafeString(row["ValidationMessage"]);
            }

            // Table 1 : Maruti share
            model.FinanceUpdateItem.ReceivablesList = new List<FinanceLineItem>();
            if ((ds.Tables.Count > 1) && (ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.FinanceUpdateItem.ReceivablesList.Add(new FinanceLineItem
                    {
                        Code = MakeSafe.ToSafeInt32(row["Code"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        TypeName = MakeSafe.ToSafeString(row["TypeName"]),
                        Amount = MakeSafe.ToSafeDecimal(row["Amount"]),
                        Remarks = MakeSafe.ToSafeString(row["Remarks"])
                    });
                }
            }

            // Table 2 : discounts
            model.FinanceUpdateItem.DiscountList = new List<FinanceLineItem>();
            if ((ds.Tables.Count > 2) && (ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    model.FinanceUpdateItem.DiscountList.Add(new FinanceLineItem
                    {
                        Code = MakeSafe.ToSafeInt32(row["Code"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        TypeName = MakeSafe.ToSafeString(row["TypeName"]),
                        Amount = MakeSafe.ToSafeDecimal(row["Amount"]),
                        Remarks = MakeSafe.ToSafeString(row["Remarks"])
                    });
                }
            }

            // Table 3 : expenses
            model.FinanceUpdateItem.ExpensesList = new List<FinanceLineItem>();
            if ((ds.Tables.Count > 3) && (ds.Tables[3]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[3].Rows)
                {
                    model.FinanceUpdateItem.ExpensesList.Add(new FinanceLineItem
                    {
                        Code = MakeSafe.ToSafeInt32(row["Code"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        TypeName = MakeSafe.ToSafeString(row["TypeName"]),
                        Amount = MakeSafe.ToSafeDecimal(row["Amount"]),
                        Remarks = MakeSafe.ToSafeString(row["Remarks"])
                    });
                }
            }

            // Table 4 : accessories (display only)
            model.FinanceUpdateItem.AccessoriesList = new List<FinanceAccessoryItem>();
            if ((ds.Tables.Count > 4) && (ds.Tables[4]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[4].Rows)
                {
                    model.FinanceUpdateItem.AccessoriesList.Add(new FinanceAccessoryItem
                    {
                        TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]),
                        HdCode = MakeSafe.ToSafeInt32(row["HdCode"]),
                        ItemCode = MakeSafe.ToSafeInt32(row["ItemCode"]),
                        ItemName = MakeSafe.ToSafeString(row["ItemName"]),
                        PartNumber = MakeSafe.ToSafeString(row["PartNumber"]),
                        Qty = MakeSafe.ToSafeInt32(row["Qty"]),
                        UnitPrice = MakeSafe.ToSafeInt32(row["UnitPrice"]),
                        Cost = MakeSafe.ToSafeInt32(row["Cost"]),
                        SellingPrice = MakeSafe.ToSafeInt32(row["SellingPrice"]),
                        Profit = MakeSafe.ToSafeInt32(row["Profit"])
                    });
                }
            }

            
            model.FinanceUpdateItem.TotalAccessoriesQty = model.FinanceUpdateItem.AccessoriesList.Sum(a => a.Qty ?? 0);
            model.FinanceUpdateItem.TotalAccessoriesCost = model.FinanceUpdateItem.AccessoriesList.Sum(a => a.Cost ?? 0);
            model.FinanceUpdateItem.TotalAccessoriesSelling = model.FinanceUpdateItem.AccessoriesList.Sum(a => a.SellingPrice ?? 0);
            model.FinanceUpdateItem.TotalAccessoriesProfit = model.FinanceUpdateItem.AccessoriesList.Sum(a => a.Profit ?? 0);

            return model;
        }


        public async Task<ResponseEntity> Save(UserBase user, FinanceUpdate model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                new SqlParameter("@UserGuid", user.UserGuid),
                new SqlParameter("@JSONDATA", JsonHelper.ToJson(model)),
                ResponseKey, ResponseStatus
            };

            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_FINANCE_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
       
    }
}
