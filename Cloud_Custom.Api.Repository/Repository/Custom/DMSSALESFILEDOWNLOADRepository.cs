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
   public class DMSSALESFILEDOWNLOADRepository : IDMSSALESFILEDOWNLOADRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public DMSSALESFILEDOWNLOADRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ResponseEntity<List<VehicleSalesImportModel>>> ImportFromExcel(UserBase user, DMSSALESFILEDOWNLOAD model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                    
                     new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };


            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SALES_FILE_DOWNLOAD_IMPORT_EXCEL]", sqlParameters);
            var unmatchedDetails = PopulateUnmatchedDetails(ds);

            return new ResponseEntity<List<VehicleSalesImportModel>>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), unmatchedDetails);
        }
        public List<VehicleSalesImportModel> PopulateUnmatchedDetails(DataSet ds)
        {
            List<VehicleSalesImportModel> list = new List<VehicleSalesImportModel>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new VehicleSalesImportModel
                    {
                        InvoiceNum = MakeSafe.ToSafeString(row["InvNo"]),
                        InvoiceDate = MakeSafe.ToSafeString(row["Date"]),
                        CustomerName = MakeSafe.ToSafeString(row["CustomerName"]),
                        Remarks = MakeSafe.ToSafeString(row["Remarks"]),
                    };

                    list.Add(item);
                }
            }

            return list;
        }


        public async Task<DMSSALESFILEDOWNLOAD> GetList(UserBase user,  int Month, int Region, int Branch)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
               
                
                new SqlParameter("@Month",Month),
                new SqlParameter("@Region",Region),
                new SqlParameter("@Branch",Branch),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_FILE_DOWNLOAD_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public DMSSALESFILEDOWNLOAD PopulateGetList(DataSet ds)
        {
            DMSSALESFILEDOWNLOAD model = new DMSSALESFILEDOWNLOAD();
            model.VehicleSalesImportModel = new List<VehicleSalesImportModel>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new VehicleSalesImportModel
                    {
                        InvoiceNum = MakeSafe.ToSafeString(row["InvoiceNum"]),
                        InvoiceDate = MakeSafe.ToSafeString(row["InvoiceDate"]),
                        StoreorBranch = MakeSafe.ToSafeString(row["StoreorBranch"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        NewCarVariant = MakeSafe.ToSafeString(row["Variant"]),
                        Color = MakeSafe.ToSafeString(row["Color"]),
                        NewVehVIN = MakeSafe.ToSafeString(row["NewVehVIN"]),
                        EnquiryNum = MakeSafe.ToSafeString(row["EnquiryNum"]),
                        EnquiryDate = MakeSafe.ToSafeString(row["EnquiryDate"]),
                        Executive = MakeSafe.ToSafeString(row["Executive"]),
                        BookingNum = MakeSafe.ToSafeString(row["BookingNum"]),
                        BookingDate = MakeSafe.ToSafeString(row["BookingDate"]),
                        Discount = MakeSafe.ToSafeString(row["Discount"]),
                        ISLDiscount = MakeSafe.ToSafeString(row["ISLDiscount"]),
                        InvoiceAmount = MakeSafe.ToSafeString(row["InvoiceAmount"]),
                        Status = MakeSafe.ToSafeString(row["Status"])
                    };

                    model.VehicleSalesImportModel.Add(item);
                }
            }

            if ((ds.Tables.Count > 1) && (ds.Tables[1].Rows.Count > 0))
            {
                model.BatchCode = Convert.ToInt32(ds.Tables[1].Rows[0]["BatchCode"]);
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
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_DELETE_BATCH_SALES]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
