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
    public class BranchTargetSettingsRepository : IBranchTargetSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public BranchTargetSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<BranchTargetSettings> GetList(UserBase user, int Month, int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_BRANCH_TARGET_SETTINGS_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public BranchTargetSettings PopulateGetList(DataSet ds)
        {
            BranchTargetSettings model = new BranchTargetSettings();
            model.List = new List<BranchTargetSettings>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new BranchTargetSettings
                    {
                        BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]),
                        Branch = MakeSafe.ToSafeString(row["BRANCH"]),
                        target = MakeSafe.ToSafeInt32(row["Target"]),
                        IncentiveAmount = MakeSafe.ToSafeDecimal(row["IncentiveAmount"]),
                      


                    };

                    model.List.Add(item);
                }
            }

            return model;
        }






        public async Task<ResponseEntity> BranchWiseUpdate(UserBase user, BranchTargetSettings model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_BRANCH_TARGET_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }




    }
}