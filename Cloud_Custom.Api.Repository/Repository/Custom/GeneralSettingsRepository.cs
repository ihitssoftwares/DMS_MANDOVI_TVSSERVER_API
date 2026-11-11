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
    public class GeneralSettingsRepository: IGeneralSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public GeneralSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<GeneralSettings> GetList(UserBase user)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),

        


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_GENERAL_SETTINGS_LIST]", sqlparameters);

            return PopulateGetList(ds);

        }



        public GeneralSettings PopulateGetList(DataSet ds)
        {
            GeneralSettings model = new GeneralSettings();
            model.BasedOn = new Dropdown();




            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];



                model.DespatchEntry = MakeSafe.ToSafeBool(row["DespatchEntry"]);
                model.OrderBookingEntry = MakeSafe.ToSafeBool(row["OrderBookingEntry"]);
                model.DeliveryCompletedChecking = MakeSafe.ToSafeBool(row["DeliveryCompletedChecking"]);
                model.EnableSalesUpdate = MakeSafe.ToSafeBool(row["EnableSalesUpdate"]);
                model.BasedOn.Code= MakeSafe.ToSafeInt32(row["BasedOn"]);




            }

            return model;
        }

      
        public async Task<ResponseEntity> Save(UserBase user, GeneralSettings model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 500, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_GENERAL_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

    }
}
