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
   public class ColdCallRepository : IColdCallRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ColdCallRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ResponseEntity<List<ColdCallImportModel>>> ImportFromExcel(UserBase user, COLDCALLFILEDOWNLOAD model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                    
                     new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };


            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_COLD_CALL_FILE_DOWNLOAD_IMPORT_EXCEL]", sqlParameters);
            var unmatchedDetails = PopulateUnmatchedDetails(ds);

            return new ResponseEntity<List<ColdCallImportModel>>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), unmatchedDetails);
        }
        public List<ColdCallImportModel> PopulateUnmatchedDetails(DataSet ds)
        {
            List<ColdCallImportModel> list = new List<ColdCallImportModel>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ColdCallImportModel
                    {
                        EnqNo = MakeSafe.ToSafeString(row["EnqNo"]),
                        Date = MakeSafe.ToSafeString(row["Date"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),
                    };

                    list.Add(item);
                }
            }

            return list;
        }


        public async Task<COLDCALLFILEDOWNLOAD> GetList(UserBase user,  int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
               
                
                new SqlParameter("@Month",Month),
               
            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_COLD_CALL_DOWNLOAD_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public COLDCALLFILEDOWNLOAD PopulateGetList(DataSet ds)
        {
            COLDCALLFILEDOWNLOAD model = new COLDCALLFILEDOWNLOAD();
            model.ColdCallImportModel = new List<ColdCallImportModel>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ColdCallImportModel
                    {
                        EnqNo = MakeSafe.ToSafeString(row["EnqNo"]),
                        Date = MakeSafe.ToSafeString(row["Date"]),
                        Name = MakeSafe.ToSafeString(row["Name"]),
                        MobileNo = MakeSafe.ToSafeString(row["MobileNo"]),
                        Email = MakeSafe.ToSafeString(row["Email"]),
                        Gender = MakeSafe.ToSafeString(row["Gender"]),
                        Color = MakeSafe.ToSafeString(row["Color"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        FuelType = MakeSafe.ToSafeString(row["FuelType"]),
                        Transmission = MakeSafe.ToSafeString(row["Transmission"]),
                        SourceOfEnquiry = MakeSafe.ToSafeString(row["SourceOfEnquiry"])
                   
                    };

                    model.ColdCallImportModel.Add(item);
                }
            }

            return model;
        }
    }
}
