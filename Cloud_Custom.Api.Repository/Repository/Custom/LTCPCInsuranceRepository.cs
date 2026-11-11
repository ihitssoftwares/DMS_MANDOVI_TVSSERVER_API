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
    public class LTCPCInsuranceRepository : ILTCPCInsuranceRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public LTCPCInsuranceRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<LTCPCInsurance> GetList(UserBase user, int Month, int Designation, int Region )
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@Month",Month),
                 new SqlParameter("@Designation",Designation),
                 new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_LTCP_INSURANCE_INCENTIVE_SETTINGS_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }
        public LTCPCInsurance PopulateGetList(DataSet ds)
        {
            LTCPCInsurance model = new LTCPCInsurance();
            model.LTCPCInsuranceList = new List<LTCPCInsurance>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new LTCPCInsurance
                    {
                        LtcpCode = MakeSafe.ToSafeInt32(row["LTCPCode"]),
                        AmountPerCar = MakeSafe.ToSafeInt32(row["AmountPerCar"]),
                        PercentOfAcheievementFrom = MakeSafe.ToSafeInt32(row["PercentOfAcheievementFrom"]),
                        PercentOfAcheievementTo = MakeSafe.ToSafeInt32(row["PercentOfAcheievementTo"]),
                    };

                    model.LTCPCInsuranceList.Add(item);
                }
            }

            return model;
        }
        public async Task<LTCPCInsurance> GetDetails(UserBase user, int Month, int Designation,int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Month",Month),
                new SqlParameter("@Designation",Designation),
                       new SqlParameter("@Region",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_LTCP_INSURANCE_INCENTIVE_SETTINGS_DETAILS]", sqlparameters);

            return PopulateGetInsurIncentiveSettingDetails(ds);

        }
        public LTCPCInsurance PopulateGetInsurIncentiveSettingDetails(DataSet ds)
        {
            LTCPCInsurance model = new LTCPCInsurance();
            model.LTCPCInsuranceList = new List<LTCPCInsurance>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new LTCPCInsurance
                    {
                        LtcpCode = MakeSafe.ToSafeInt32(row["LTCPCode"]),
                        AmountPerCar = MakeSafe.ToSafeInt32(row["AmountPerCar"]),
                        PercentOfAcheievementFrom = MakeSafe.ToSafeInt32(row["PercentOfAcheievementFrom"]),
                        PercentOfAcheievementTo = MakeSafe.ToSafeInt32(row["PercentOfAcheievementTo"]),
                    };

                    model.LTCPCInsuranceList.Add(item);
                }
            }

            return model;


        }

        public async Task<ResponseEntity> Save(UserBase user, LTCPCInsurance model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_LTCP_INSURANCE_INCENTIVE_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
