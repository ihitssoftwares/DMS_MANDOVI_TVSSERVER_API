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
    public class SpotIncentiveDateWiseRepository : ISpotIncentiveDateWiseRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SpotIncentiveDateWiseRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ResponseEntity> SpotIncentiveDateWiseSave(UserBase user, SpotIncentiveDateWise model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 500, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_SPOT_INCENTIVE_DATEWISE_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }



        public async Task<SpotIncentiveDateWise> GetList(UserBase user, int Month, int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),
                new SqlParameter("@Region",Region),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SPOT_INCENTIVE_LIST_DATEWISE]", sqlparameters);

            return PopulateGetList(ds);

        }
        public SpotIncentiveDateWise PopulateGetList(DataSet ds)
        {
            // Create the main model
            SpotIncentiveDateWise model = new SpotIncentiveDateWise();
            model.SpotIncentiveDateWiseList = new List<SpotIncentiveDateWise>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new SpotIncentiveDateWise
                    {
                        HDCode = MakeSafe.ToSafeInt32(row["ID"]),
                        FromDate = MakeSafe.ToSafeDateTime(row["FromDate"]),
                        ToDate = MakeSafe.ToSafeDateTime(row["ToDate"]),
                        DSE = MakeSafe.ToSafeDecimal(row["DSEAmount"]),
                        TL = MakeSafe.ToSafeDecimal(row["TLAmount"]),
                        SM = MakeSafe.ToSafeDecimal(row["SMAmount"]),

                    };

                    model.SpotIncentiveDateWiseList.Add(item);
                }
            }

            return model;
        }

        public async Task<SpotIncentiveDateWise> GetDetails(UserBase user, int HDCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@HDCode",HDCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SPOT_INCENTIVE_DETAILS_DATEWISE]", sqlparameters);

            return PopulateGetDetails(ds);

        }
        public SpotIncentiveDateWise PopulateGetDetails(DataSet ds)
        {
            SpotIncentiveDateWise model = new SpotIncentiveDateWise();

            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.HDCode = MakeSafe.ToSafeInt32(row["ID"]);
                model.FromDate = MakeSafe.ToSafeDateTime(row["FromDate"]);
                model.ToDate = MakeSafe.ToSafeDateTime(row["ToDate"]);
                model.DSE = MakeSafe.ToSafeDecimal(row["DSEAmount"]);
                model.TL = MakeSafe.ToSafeDecimal(row["TLAmount"]);
                model.SM = MakeSafe.ToSafeDecimal(row["SMAmount"]);
            }

            return model;
        }

    }
}


