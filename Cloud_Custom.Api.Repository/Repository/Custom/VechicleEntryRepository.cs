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

namespace Cloud_Custom.Api.Repository.Repository.Account
{
    public class VechicleEntryRepository : IVechicleEntryRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public VechicleEntryRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ResponseEntity> Save(UserBase User, VechicleEntry model)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                IDbDataParameter[] sqlParameters =
                {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                    new SqlParameter("@CompanyGI",User.CompanyGuid),
                    new SqlParameter("@UserGI",User.UserGuid),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_VEHICLE_ENTRY_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException EX)
            {
                var ErrorMsg = EX.Message.ToString();
                throw new Exception(ErrorMsg, EX);
            }
        }
    }
}
