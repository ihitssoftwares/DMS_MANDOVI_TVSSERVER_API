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
    public class ModelVsVariantUploadRepository : IModelVsVariantUploadRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ModelVsVariantUploadRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


 

        public async Task<ResponseEntity<List<modelvsvariant>>> OrderImportFromExcel(UserBase user, ModelVsVariantUpload model)
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

            var ds = await _sql.GetDataSetAsync("[DMS].[SP_MODEL_VS_VARIANT_IMPORT_FROM_EXECL]", sqlParameters);

            var unmatchedDetails = PopulateUnmatchedDetails(ds);

            return new ResponseEntity<List<modelvsvariant>>(ResponseKey.Value?.ToString() ?? "ERROR", ResponseStatus.Value != null && Convert.ToBoolean(ResponseStatus.Value), unmatchedDetails);
        }


        public List<modelvsvariant> PopulateUnmatchedDetails(DataSet ds)
        {
            List<modelvsvariant> list = new List<modelvsvariant>();

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new modelvsvariant
                    {
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        //NEWVEHVIN = MakeSafe.ToSafeString(row["NEWVEHVIN"]),
                        //BookingNum = MakeSafe.ToSafeString(row["BookingNum"]),

                        Message = MakeSafe.ToSafeString(row["Message"]),
                    };

                    list.Add(item);
                }
            }

            return list;
        }

        public async Task<ModelVsVariantUpload> GetList(UserBase user, int Month)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_MODEL_VS_VARIANT_UPLOAD_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public ModelVsVariantUpload PopulateGetList(DataSet ds)
        {
            ModelVsVariantUpload model = new ModelVsVariantUpload();
            List<ModelVsVariantUploadModel> List = new List<ModelVsVariantUploadModel>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new ModelVsVariantUploadModel
                    {
                        Model = MakeSafe.ToSafeString(row["Model"]),

                        VariantCode = MakeSafe.ToSafeString(row["VariantCode"]),
                        Variant = MakeSafe.ToSafeString(row["Variant"]),

                        Color = MakeSafe.ToSafeString(row["Color"]),
                        

                    };
                    List.Add(item);
                }
                model.ModelVsVariantUploadList = List;
            }

            return model;
        }
    }
}

