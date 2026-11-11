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
    public class InventoryDispatchUpdateRepository : IInventoryDispatchUpdateRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public InventoryDispatchUpdateRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ResponseEntity<List<SalesVehicleImport>>> ImportDispatchFromExcel(UserBase user, InventoryDispatchUpdate model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),

                     new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };


            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SALES_VECHICLE_FILE_DOWNLOAD_IMPORT_EXCEL]", sqlParameters);
            var unmatchedDetails = PopulateUnmatchedDetails(ds);

            return new ResponseEntity<List<SalesVehicleImport>>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), unmatchedDetails);
        }
        public List<SalesVehicleImport> PopulateUnmatchedDetails(DataSet ds)
        {
            List<SalesVehicleImport> list = new List<SalesVehicleImport>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new SalesVehicleImport
                    {
                        
                        EngineNo = MakeSafe.ToSafeString(row["NewVehVIN"]),
                        Remarks = MakeSafe.ToSafeString(row["Remarks"]),
                    };

                    list.Add(item);
                }
            }

            return list;
        }



        public async Task<InventoryDispatchUpdate> GetDispatchStockList(UserBase user, int BatchCode)
        {
            IDbDataParameter[] sqlparameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGuid", user.UserGuid),
        new SqlParameter("@BatchCode", BatchCode),
        
    };

            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DISPATCH_STOCK_LIST]", sqlparameters);

            return PopulateGetList(ds);
        }
        public InventoryDispatchUpdate PopulateGetList(DataSet ds)
        {
            InventoryDispatchUpdate model = new InventoryDispatchUpdate();
            model.SalesVehicleImport = new List<SalesVehicleImport>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new SalesVehicleImport
                    {
                        DealerRegionCode = MakeSafe.ToSafeString(row["DealerRegionCOde"]),
                        SalesDealerCode = MakeSafe.ToSafeString(row["SalesDealerCode"]),
                        NewVehVIN = MakeSafe.ToSafeString(row["NewVehVin"]),
                        ModelName = MakeSafe.ToSafeString(row["Model"]),
                        VariantName = MakeSafe.ToSafeString(row["Variant"]),
                        ColourName = MakeSafe.ToSafeString(row["Color"]),
                        ChassisPrefix = MakeSafe.ToSafeString(row["ChassisPrefix"]),
                        ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]),
                        EngineNo = MakeSafe.ToSafeString(row["EngineNo"]),
                        InvoiceNo = MakeSafe.ToSafeString(row["InvoiceNo"]),
                        InvoiceDate = MakeSafe.ToSafeString(row["InvoiceDate"]),
                        DispatchDate = MakeSafe.ToSafeString(row["DispatchDate"]),
                        BasicValue = MakeSafe.ToSafeString(row["BasicValue"]),
                        DiscountSpot = MakeSafe.ToSafeString(row["DiscountSpot"]),
                        DRF = MakeSafe.ToSafeString(row["DRF"]),
                        AssessableValue = MakeSafe.ToSafeString(row["AssessableValue"]),
                        IGST = MakeSafe.ToSafeString(row["IGST"]),
                        Cess = MakeSafe.ToSafeString(row["Cess"]),
                        TCS = MakeSafe.ToSafeString(row["TCS"]),
                        Amount = MakeSafe.ToSafeString(row["Amount"]),
                        StockStatus = MakeSafe.ToSafeString(row["StockStatus"]),
                        AllotmentStatus = MakeSafe.ToSafeString(row["AllotmentStatus"]),
                        QCStatus = MakeSafe.ToSafeString(row["QCStatus"])
                    };

                    model.SalesVehicleImport.Add(item);
                }
            }

            return model;
        }


        public async Task<InventoryDispatchUpdate> GetSummaryDetails(UserBase user, int BatchCode)
        {
            IDbDataParameter[] sqlparameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGI", user.UserGuid),
        new SqlParameter("@BatchCode", BatchCode),
       
    };

            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SALES_VEHICLE_BATCH_SUMMARY]", sqlparameters);

            return PopulateGetSummaryDetails(ds);
        }
        public InventoryDispatchUpdate PopulateGetSummaryDetails(DataSet ds)
        {
            InventoryDispatchUpdate model = new InventoryDispatchUpdate();
            model.SalesVehicleBatchSummary = new List<SalesVehicleBatchSummary>();



            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new SalesVehicleBatchSummary
                    {
                        
                        TotalVehicles = MakeSafe.ToSafeInt32(row["TotalVehicles"]),
                        FirstDispatchDate = MakeSafe.ToSafeDateTime(row["FirstDispatchDate"]),
                        LastDispatchDate = MakeSafe.ToSafeDateTime(row["LastDispatchDate"]),
                        FirstInvoiceDate = MakeSafe.ToSafeDateTime(row["FirstInvoiceDate"]),
                        LastInvoiceDate = MakeSafe.ToSafeDateTime(row["LastInvoiceDate"]),
                        EntryDate = MakeSafe.ToSafeDateTime(row["EntryDate"]),
                    
                        QCPassed = MakeSafe.ToSafeInt32(row["QC_Passed"]),
                        Allotted = MakeSafe.ToSafeInt32(row["Allotted"]),
                        InWarehouse = MakeSafe.ToSafeInt32(row["InWarehouse"])
                    };

                    model.SalesVehicleBatchSummary.Add(item);
                }
            }

            return model;
        }

        public async Task<ResponseEntity> Delete(UserBase user, int BatchCode)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@BatchCode",BatchCode),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_DELET_BATCH_VECHICLE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
