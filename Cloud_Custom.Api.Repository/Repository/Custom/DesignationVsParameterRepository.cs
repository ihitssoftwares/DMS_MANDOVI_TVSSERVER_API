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
     public class DesignationVsParameterRepository : IDesignationVsParameterRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public DesignationVsParameterRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<DesignationVsParameter> GetList(UserBase user, int DesignationCode, int regionCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@IncentiveGroupCode",DesignationCode),
                 new SqlParameter("@regionCode",regionCode),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_DESIGNATION_VS_PARAMETER_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private DesignationVsParameter DesignationVsParameterList(DataSet dataSet)
        {
            DesignationVsParameter model = new DesignationVsParameter();
            List<DesignationVsParameter> List = new List<DesignationVsParameter>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new DesignationVsParameter();
                   

                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.PaticularCode = MakeSafe.ToSafeInt32(row["PaticularCode"]);
                    item.PaticularName = MakeSafe.ToSafeString(row["PaticularName"]);
                    item.ParameterTypeCode = MakeSafe.ToSafeInt32(row["ParameterTypeCode"]);
                    item.ParameterTypeName = MakeSafe.ToSafeString(row["ParameterTypeName"]);
                    item.IsApplicable = MakeSafe.ToSafeBool(row["IsApplicable"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;

        }
        public async Task<ResponseEntity> Save(DesignationVsParameter Model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@JSONDATA",JsonHelper.ToJson(Model)),
                ResponseKey,ResponseStatus
            };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DesignationVsParameter_Save]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
