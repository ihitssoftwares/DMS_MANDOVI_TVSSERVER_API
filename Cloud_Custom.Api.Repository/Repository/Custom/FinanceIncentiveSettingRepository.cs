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
 public    class FinanceIncentiveSettingRepository : IFinanceIncentiveSettingRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public FinanceIncentiveSettingRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<FinanceIncentiveSetting> GetList(UserBase user, int Month, int Designation,int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@Designation",Designation),
                       new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_FINANCE_INCENTIVE_SETTINGS_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public FinanceIncentiveSetting PopulateGetList(DataSet ds)
        {
            FinanceIncentiveSetting model = new FinanceIncentiveSetting();
            model.FinanceIncentiveSettingList = new List<FinanceIncentiveSetting>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new FinanceIncentiveSetting
                    {
                        FinanceIncSettingsCode = MakeSafe.ToSafeInt32(row["FinanceIncSettingsCode"]),
                        AmountPerCar = MakeSafe.ToSafeInt32(row["AmountPerCar"]),
                        PercentOfAcheievementFrom = MakeSafe.ToSafeInt32(row["PercentOfAcheievementFrom"]),
                        PercentOfAcheievementTo = MakeSafe.ToSafeInt32(row["PercentOfAcheievementTo"]),
                    };

                    model.FinanceIncentiveSettingList.Add(item);
                }
            }

            return model;
        }
        public async Task<FinanceIncentiveSetting> GetFinanceIncentiveSettingsDetails(UserBase user, int Month, int Designation, int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Month",Month),
                new SqlParameter("@Designation",Designation),
                      new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_FINANCE_INCENTIVE_SETTINGS_DETAILS]", sqlparameters);

            return PopulateGetFinanceIncentiveSettingDetails(ds);

        }
        public FinanceIncentiveSetting PopulateGetFinanceIncentiveSettingDetails(DataSet ds)
        {
            FinanceIncentiveSetting model = new FinanceIncentiveSetting();
            model.FinanceIncentiveSettingList = new List<FinanceIncentiveSetting>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new FinanceIncentiveSetting
                    {
                        FinanceIncSettingsCode = MakeSafe.ToSafeInt32(row["FinanceIncSettingsCode"]),
                        AmountPerCar = MakeSafe.ToSafeInt32(row["AmountPerCar"]),
                        PercentOfAcheievementFrom = MakeSafe.ToSafeInt32(row["PercentOfAcheievementFrom"]),
                        PercentOfAcheievementTo = MakeSafe.ToSafeInt32(row["PercentOfAcheievementTo"]),
                    };

                    model.FinanceIncentiveSettingList.Add(item);
                }
            }

            return model;


        }

        public async Task<ResponseEntity> FinanceIncentiveSettingSave(UserBase user, FinanceIncentiveSetting model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_FINANCE_INCENTIVE_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
