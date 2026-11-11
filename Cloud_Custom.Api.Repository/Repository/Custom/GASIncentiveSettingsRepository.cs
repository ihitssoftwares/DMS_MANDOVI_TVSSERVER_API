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
  public  class GASIncentiveSettingsRepository : IGASIncentiveSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public GASIncentiveSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<GASIncentiveSettings> GetList(UserBase user, int Month, int Designation, int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@Designation",Designation),
                 new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_GAS_INCENTIVE_SETTINGS_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public GASIncentiveSettings PopulateGetList(DataSet ds)
        {
            GASIncentiveSettings model = new GASIncentiveSettings();
            model.GASIncentiveSettingsList = new List<GASIncentiveSettings>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new GASIncentiveSettings
                    {
                        GASIncSettingsCode = MakeSafe.ToSafeInt32(row["GASIncSettingsCode"]),
                        AmountPerCar = MakeSafe.ToSafeInt32(row["AmountPerCar"]),
                        PercentOfAcheievementFrom = MakeSafe.ToSafeInt32(row["PercentOfAcheievementFrom"]),
                        PercentOfAcheievementTo = MakeSafe.ToSafeInt32(row["PercentOfAcheievementTo"]),
                        BillAmount = MakeSafe.ToSafeInt32(row["BillAmount"]),
                        PercentOfBillAmount = MakeSafe.ToSafeInt32(row["PercentOfBillAmount"]),

                    };

                    model.GASIncentiveSettingsList.Add(item);
                }
            }

            return model;
        }





        public async Task<GASIncentiveSettings> GetGASIncentiveSettingsDetails(UserBase user, int Month, int Designation,int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Month",Month),
                new SqlParameter("@Designation",Designation),
                            new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_GAS_INCENTIVE_SETTINGS_DETAILS]", sqlparameters);

            return PopulateGetGASIncentiveSettingsDetails(ds);

        }
        public GASIncentiveSettings PopulateGetGASIncentiveSettingsDetails(DataSet ds)
        {
            GASIncentiveSettings model = new GASIncentiveSettings();
            model.GASIncentiveSettingsList = new List<GASIncentiveSettings>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new GASIncentiveSettings
                    {
                        GASIncSettingsCode = MakeSafe.ToSafeInt32(row["GASIncSettingsCode"]),
                        AmountPerCar = MakeSafe.ToSafeInt32(row["AmountPerCar"]),
                        PercentOfAcheievementFrom = MakeSafe.ToSafeInt32(row["PercentOfAcheievementFrom"]),
                        PercentOfAcheievementTo = MakeSafe.ToSafeInt32(row["PercentOfAcheievementTo"]),
                        BillAmount = MakeSafe.ToSafeInt32(row["BillAmount"]),
                        PercentOfBillAmount = MakeSafe.ToSafeInt32(row["PercentOfBillAmount"]),
                    };

                    model.GASIncentiveSettingsList.Add(item);
                }
            }

            return model;


        }

        public async Task<ResponseEntity> GASIncentiveSettingsSave(UserBase user, GASIncentiveSettings model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_GAS_INCENTIVE_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
