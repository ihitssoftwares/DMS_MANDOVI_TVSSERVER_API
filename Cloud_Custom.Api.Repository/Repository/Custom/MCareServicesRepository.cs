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
    public class MCareServicesRepository : IMCareServicesRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MCareServicesRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<MCareServices> GetList(UserBase user, string TabIndex)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
             new SqlParameter("@CompanyGI",user.CompanyGuid),
             new SqlParameter("@UserGuid",user.UserGuid),
             new SqlParameter("@Type",TabIndex)
        };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MCARE_SERVICES_LIST]", sqlparameters);
                return MCareServicesList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private MCareServices MCareServicesList(DataSet dataSet)
        {
            MCareServices model = new MCareServices();
            List<MCareServices> List = new List<MCareServices>();
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
                    var item = new MCareServices();

                    item.SLno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.MCareServicesCode = MakeSafe.ToSafeInt32(row["ServiceCode"]);
                    item.MCareServicesName = MakeSafe.ToSafeString(row["Name"]);
                    item.ShortName = MakeSafe.ToSafeString(row["ShortName"]);

                    List.Add(item);
                }
                model.List = List;
            }
            return model;
        }

        public async Task<ResponseEntity> Save(UserBase user, string mode, MCareServices model)
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
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MCARE_SERVICES_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<MCareServices> GetMCareServicesDetails(UserBase User, int MCareServicesCode, string mode, string Type)
        {
            IDbDataParameter[] sqlParameters =
             {
            new SqlParameter("@CompanyGI",User.CompanyGuid),
             new SqlParameter("@UserGuid",User.UserGuid),
            new SqlParameter("@MCareServicesCode",MCareServicesCode),
             new SqlParameter("@Type",Type),
        };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_MCARE_SERVICES_DETAILS]", sqlParameters);
            return PopulateMCareServicesDetails(dataSet);
        }

        private MCareServices PopulateMCareServicesDetails(DataSet dataSet)
        {
            MCareServices model = new MCareServices();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                model.MCareServicesCode = MakeSafe.ToSafeInt32(row["ServiceCode"]);
                model.MCareServicesName = MakeSafe.ToSafeString(row["Name"]);
                model.ShortName = MakeSafe.ToSafeString(row["ShortName"]);
                model.Active = MakeSafe.ToSafeBool(row["Active"]);
            }

            return model;
        }

        public async Task<ResponseEntity> DeleteMCareServices(UserBase user, MCareServices model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
             new SqlParameter("@CompanyGI",user.CompanyGuid),
             new SqlParameter("@UserGuid",user.UserGuid),
             new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),

                ResponseKey,ResponseStatus
        };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MCARE_SERVICES_DELETE]", sqlParameters, CommandType.StoredProcedure);
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
