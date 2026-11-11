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
    public class PerCarProfitRepository : IPerCarProfitRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public PerCarProfitRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<PerCarProfit> GetList(UserBase user, string Month)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@Month",Month),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_PER_CAR_PROFIT_LIST]", sqlparameters);
                return PerCarProfitList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private PerCarProfit PerCarProfitList(DataSet dataSet)
        {
            PerCarProfit model = new PerCarProfit();
            List<PerCarProfit> List = new List<PerCarProfit>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.Month = new Dropdown(); // bind once

               
                model.SaleUpdatePendingCount = MakeSafe.ToSafeInt32(dataSet.Tables[0].Rows[0]["SaleUpdatePendingCount"]);
                model.FinanceUpdatePendingCount = MakeSafe.ToSafeInt32(dataSet.Tables[0].Rows[0]["FinanceUpdatePendingCount"]);

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new PerCarProfit();

                    item.InvoiceNo = MakeSafe.ToSafeString(row["InvoiceNo"]);
                    item.InvoiceDate = MakeSafe.ToSafeString(row["InvoiceDate"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.ModelName = MakeSafe.ToSafeString(row["ModelName"]);
                    item.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
                    item.VinNo = MakeSafe.ToSafeString(row["VinNo"]);
                    item.SalesPosition = MakeSafe.ToSafeString(row["SalesPosition"]);
                    item.VehicleDetails = MakeSafe.ToSafeString(row["VehicleDetails"]);
                    item.CostPrice = MakeSafe.ToSafeDecimal(row["CostPrice"]);
                    item.SellingPrice = MakeSafe.ToSafeDecimal(row["SellingPrice"]);
                    item.InvoiceAmount = MakeSafe.ToSafeDecimal(row["InvoiceAmount"]);
                    item.ReceivablesTotal = MakeSafe.ToSafeDecimal(row["ReceivablesTotal"]);
                    item.DiscountTotal = MakeSafe.ToSafeDecimal(row["DiscountTotal"]);
                    item.ExpenseTotal = MakeSafe.ToSafeDecimal(row["ExpenseTotal"]);
                    item.FinalNetAmount = MakeSafe.ToSafeDecimal(row["FinalNetAmount"]);
                    item.Hdcode = MakeSafe.ToSafeInt32(row["HDCODE"]);

                    List.Add(item);
                }

                model.List = List;
            }
            else
            {
               
            }

            return model;
        }
        public async Task<PerCarProfit> GetFinanceExportToExcelList(UserBase user, int Month, string Branch)
        {


            IDbDataParameter[] sqlparameters =
            {
           new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGuid", user.UserGuid),
           new SqlParameter("@Month", Month),
          new SqlParameter("@Branch", Branch)

             };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_FINANCE_PL_EXPORT_LIST]", sqlparameters);
            return PopulateGetPLList(ds);
        }




        public PerCarProfit PopulateGetPLList(DataSet ds)
        {
            PerCarProfit result = new PerCarProfit();
            PLReport model = new PLReport();

            // Table0: headers (Section D / R / E)
            if ((ds.Tables.Count > 0) && (ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    PLHeader header = new PLHeader
                    {
                        Code = MakeSafe.ToSafeInt32(row["Code"]),
                        Name = MakeSafe.ToSafeString(row["Name"])
                    };

                    string section = MakeSafe.ToSafeString(row["Section"]);
                    if (section == "D") model.DiscountHeaders.Add(header);
                    else if (section == "R") model.ReceivableHeaders.Add(header);
                    else if (section == "E") model.ExpenseHeaders.Add(header);
                }
            }


            if ((ds.Tables.Count > 1) && (ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    model.List.Add(new PLInvoice
                    {
                        SalesTrnCode = MakeSafe.ToSafeInt32(row["SalesTrnCode"]),
                        InvoiceNo = MakeSafe.ToSafeString(row["InvoiceNo"]),
                        InvoiceDate = MakeSafe.ToSafeString(row["InvoiceDate"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),
                        VariantCode = MakeSafe.ToSafeString(row["VariantCode"]),
                        InvoiceAmount = MakeSafe.ToSafeDecimal(row["InvoiceAmount"])
                    });
                }
            }


            if ((ds.Tables.Count > 2) && (ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    int salesTrnCode = MakeSafe.ToSafeInt32(row["SalesTrnCode"]);

                    foreach (PLInvoice invoice in model.List)
                    {
                        if (invoice.SalesTrnCode == salesTrnCode)
                        {
                            invoice.Lines.Add(new PLLine
                            {
                                Section = MakeSafe.ToSafeString(row["Section"]),
                                TypeCode = MakeSafe.ToSafeInt32(row["TypeCode"]),
                                Amount = MakeSafe.ToSafeDecimal(row["Amount"])
                            });
                            break;
                        }
                    }
                }
            }


            if ((ds.Tables.Count > 3) && (ds.Tables[3]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[3].Rows[0];
                model.Total.TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"]);
                model.Total.TotalInvoiceAmount = MakeSafe.ToSafeDecimal(row["TotalInvoiceAmount"]);
            }


            if ((ds.Tables.Count > 4) && (ds.Tables[4]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[4].Rows)
                {
                    model.Total.Lines.Add(new PLLine
                    {
                        Section = MakeSafe.ToSafeString(row["Section"]),
                        TypeCode = MakeSafe.ToSafeInt32(row["TypeCode"]),
                        Amount = MakeSafe.ToSafeDecimal(row["Amount"])
                    });
                }
            }

            result.PLReport = model;
            return result;
        }

    }
}
