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
  public  class EWIncentiveSettingsRepository : IEWIncentiveSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public EWIncentiveSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<EWIncentiveSettings> GetList(UserBase user, int Month, int Designation, int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@Designation",Designation),
                 new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_EW_INCENTIVE_SETTINGS_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public EWIncentiveSettings PopulateGetList(DataSet ds)
        {
            EWIncentiveSettings model = new EWIncentiveSettings();
            model.EWIncentiveSettingsList = new List<EWIncentiveSettings>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new EWIncentiveSettings
                    {
                        EWIncSettingsCode = MakeSafe.ToSafeInt32(row["EWIncSettingsCode"]),
                        AmountPerCar = MakeSafe.ToSafeInt32(row["AmountPerCar"]),
                        PercentOfAcheievementFrom = MakeSafe.ToSafeInt32(row["PercentOfAcheievementFrom"]),
                        PercentOfAcheievementTo = MakeSafe.ToSafeInt32(row["PercentOfAcheievementTo"]),
                    };

                    model.EWIncentiveSettingsList.Add(item);
                }
            }

            return model;
        }





        public async Task<EWIncentiveSettings> GetEWIncentiveSettingsDetails(UserBase user, int Month, int Designation, int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Month",Month),
                new SqlParameter("@Designation",Designation),
                 new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_EW_INCENTIVE_SETTINGS_DETAILS]", sqlparameters);

            return PopulateGetEWIncentiveSettingsDetails(ds);

        }
        public EWIncentiveSettings PopulateGetEWIncentiveSettingsDetails(DataSet ds)
        {
            EWIncentiveSettings model = new EWIncentiveSettings();
            model.EWIncentiveSettingsList = new List<EWIncentiveSettings>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new EWIncentiveSettings
                    {
                        EWIncSettingsCode = MakeSafe.ToSafeInt32(row["EWIncSettingsCode"]),
                        AmountPerCar = MakeSafe.ToSafeInt32(row["AmountPerCar"]),
                        PercentOfAcheievementFrom = MakeSafe.ToSafeInt32(row["PercentOfAcheievementFrom"]),
                        PercentOfAcheievementTo = MakeSafe.ToSafeInt32(row["PercentOfAcheievementTo"]),
                    };

                    model.EWIncentiveSettingsList.Add(item);
                }
            }

            return model;


        }

        public async Task<ResponseEntity> EWIncentiveSettingsSave(UserBase user, EWIncentiveSettings model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_EW_INCENTIVE_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
