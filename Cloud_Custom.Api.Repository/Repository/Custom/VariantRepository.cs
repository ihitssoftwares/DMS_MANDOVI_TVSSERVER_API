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
    public class VariantRepository : IVariantRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public VariantRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Variant> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",TabIndex)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_Variant_LIST]", sqlparameters);
                return VariantList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Variant VariantList(DataSet dataSet)
        {
            Variant model = new Variant();
            List<Variant> List = new List<Variant>();
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    model.ActiveCount = MakeSafe.ToSafeInt32(row["ActiveCount"]);
                    model.InactiveCount = MakeSafe.ToSafeInt32(row["InactiveCount"]);


                }
            }
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new Variant();

                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.VariantCode = MakeSafe.ToSafeInt32(row["VariantCode"]);
                    item.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
                    item.VariantDescription = MakeSafe.ToSafeString(row["VariantDescription"]);
                    item.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(UserBase user, string mode, Variant model)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
               new SqlParameter("@CompanyGI",user.CompanyGuid),
               new SqlParameter("@UserGuid",user.UserGuid),
               new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
               new SqlParameter("@Mode",mode),
                ResponseKey,ResponseStatus
                };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_varient_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<Variant> GetVarientDetails(UserBase User, int VariantCode, string mode, string Type)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@VariantCode",VariantCode),
                new SqlParameter("@Type",Type),

            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_Varient_Edit_DETAILS]", sqlParameters);
            return PopulateVarientDetails(dataSet);

        }

        private Variant PopulateVarientDetails(DataSet dataSet)
        {
            Variant model = new Variant();


            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];


                model.VariantCode = MakeSafe.ToSafeInt32(row["VariantCode"]);
                model.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
                model.VariantDescription = MakeSafe.ToSafeString(row["VariantDescription"]);
                model.DMSCode = MakeSafe.ToSafeString(row["DMSCode"]);
                model.Active = MakeSafe.ToSafeBool(row["IsActive"]);
            }

            return model;
        }

        public async Task<ResponseEntity> VariantDelete(UserBase User, Variant model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),

                        ResponseKey,ResponseStatus
                };

                await _sql.ExecuteNonQueryAsync("[DMS].[SP_VARIANT_DELETE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
    }
}

