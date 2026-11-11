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
  public  class SalesIncentiveSettingsRepository : ISalesIncentiveSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SalesIncentiveSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<SalesIncentiveSettings> GetList(UserBase user, int Month, int Designation, int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@Designation",Designation),
                 new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SALES_INCENTIVE_SETTINGS_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public SalesIncentiveSettings PopulateGetList(DataSet ds)
        {
            SalesIncentiveSettings model = new SalesIncentiveSettings();
            model.SalesIncentiveSettingsList = new List<SalesIncentiveSettings>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new SalesIncentiveSettings
                    {
                        SalesIncSettingsCode = MakeSafe.ToSafeInt32(row["SalesIncSettingsCode"]),
                        ModelCode = MakeSafe.ToSafeInt32(row["ModelCode"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        AmountPerCar = MakeSafe.ToSafeInt32(row["AmountPerCar"]),
                        MinimumAchievementPer = MakeSafe.ToSafeInt32(row["MinimumAchievementPer"]),
                      
                    };

                    model.SalesIncentiveSettingsList.Add(item);
                }
            }

            return model;
        }





        public async Task<SalesIncentiveSettings> GetSalesIncentiveSettingsDetails(UserBase user, int Month, int Designation, int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Month",Month),
                new SqlParameter("@Designation",Designation),
                new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SALES_INCENTIVE_SETTINGS_DETAILS]", sqlparameters);

            return PopulateGetSalesIncentiveSettingsDetails(ds);

        }
        public SalesIncentiveSettings PopulateGetSalesIncentiveSettingsDetails(DataSet ds)
        {
            SalesIncentiveSettings model = new SalesIncentiveSettings();
            model.SalesIncentiveSettingsList = new List<SalesIncentiveSettings>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new SalesIncentiveSettings
                    {
                        SalesIncSettingsCode = MakeSafe.ToSafeInt32(row["SalesIncSettingsCode"]),
                        ModelCode = MakeSafe.ToSafeInt32(row["ModelCode"]),
                        Model = MakeSafe.ToSafeString(row["Model"]),
                        AmountPerCar = MakeSafe.ToSafeInt32(row["AmountPerCar"]),
                        MinimumAchievementPer = MakeSafe.ToSafeInt32(row["MinimumAchievementPer"]),

                    };

                    model.SalesIncentiveSettingsList.Add(item);
                }
            }

            return model;


        }

        public async Task<ResponseEntity> SalesIncentiveSettingsSave(UserBase user, SalesIncentiveSettings model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_SALES_INCENTIVE_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
