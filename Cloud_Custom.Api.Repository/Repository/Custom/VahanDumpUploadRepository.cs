using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public class VahanDumpUploadRepository : IVahanDumpUploadRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public VahanDumpUploadRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        //public async Task<ResponseEntity<List<DumpUploadModel>>> OrderImportFromExcel(UserBase user, VahanDumpUpload model)
        //{
        //    SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
        //    SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

        //    IDbDataParameter[] sqlParameters =
        //    {        new SqlParameter("@CompanyGI",user.CompanyGuid),
        //             new SqlParameter("@UserGuid",user.UserGuid),

        //             new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
        //        ResponseKey,ResponseStatus
        //        };


        //    var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_VAHAN_DUMP_UPLOAD_IMPORT_FROM_EXECL]", sqlParameters);
        //    var unmatchedDetails = PopulateUnmatchedDetails(ds);

        //    return new ResponseEntity<List<DumpUploadModel>>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), unmatchedDetails);
        //}


        public async Task<ResponseEntity<List<DumpUploadModel>>> OrderImportFromExcel(UserBase user, VahanDumpUpload model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };


                IDbDataParameter[] sqlParameters =
                {
                    new SqlParameter("@CompanyGI", user.CompanyGuid),
                    new SqlParameter("@UserGuid", user.UserGuid),
                    new SqlParameter("@JSONDATA", JsonHelper.ToJson(model)),
                    ResponseKey,
                    ResponseStatus
                };

            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_VAHAN_DUMP_UPLOAD_IMPORT_FROM_EXECL]", sqlParameters);

            var unmatchedDetails = PopulateUnmatchedDetails(ds);

            return new ResponseEntity<List<DumpUploadModel>>(ResponseKey.Value?.ToString() ?? "ERROR",ResponseStatus.Value != null && Convert.ToBoolean(ResponseStatus.Value),unmatchedDetails);
        }


        public List<DumpUploadModel> PopulateUnmatchedDetails(DataSet ds)
        {
            List<DumpUploadModel> list = new List<DumpUploadModel>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new DumpUploadModel
                    {
                        ChasisNumber = MakeSafe.ToSafeString(row["ChasisNumber"]),
                        //NEWVEHVIN = MakeSafe.ToSafeString(row["NEWVEHVIN"]),
                        //BookingNum = MakeSafe.ToSafeString(row["BookingNum"]),

                        Message = MakeSafe.ToSafeString(row["Message"]),
                    };

                    list.Add(item);
                }
            }

            return list;
        }

        public async Task<VahanDumpUpload> GetList(UserBase user, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_VAHAN_DUMP_UPLOAD_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public VahanDumpUpload PopulateGetList(DataSet ds)
        {
            VahanDumpUpload model = new VahanDumpUpload();
            List<VahanDumpUploadModel> List = new List<VahanDumpUploadModel>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new VahanDumpUploadModel
                    {
                        RegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]),
                       
                        ChasisNumber = MakeSafe.ToSafeString(row["ChasisNumber"]),
                        DealerName = MakeSafe.ToSafeString(row["DealerName"]),
                     
                        Total = MakeSafe.ToSafeInt32(row["Total"]),
                        Interest = MakeSafe.ToSafeInt32(row["Interest"]),
                        
                        ReceiptNumber = MakeSafe.ToSafeString(row["ReceiptNumber"]),
                        ApplicationNo = MakeSafe.ToSafeString(row["ApplicationNo"]),
                        ApplicationDate = MakeSafe.ToSafeDateTime(row["ApplicationDate"]),
                        ApprovalDate = MakeSafe.ToSafeDateTime(row["ApprovalDate"]),
                        ReceiptDate = MakeSafe.ToSafeDateTime(row["ReceiptDate"]),
                        CurrentAddress = MakeSafe.ToSafeString(row["CurrentAddress"]),
                        PermanentAddress = MakeSafe.ToSafeString(row["PermanentAddress"]),
                        Fees = MakeSafe.ToSafeInt32(row["Fees"]),
                        MVTax = MakeSafe.ToSafeInt32(row["MVTax"]),
                        Surcharge = MakeSafe.ToSafeInt32(row["Surcharge"]),

                    };
                    List.Add(item);
                }
                model.VahanDumpUploadList = List;
            }

            return model;
        }
    }
}

