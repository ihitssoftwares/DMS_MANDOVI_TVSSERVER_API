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
    public class SpotIncentiveModelWiseRepository : ISpotIncentiveModelWiseRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public SpotIncentiveModelWiseRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ResponseEntity> SpotIncentiveModelWiseSave(UserBase user, SpotIncentiveModelWise model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 500, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_DMS_SPOT_INCENTIVE_MODELWISE_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }


        public async Task<SpotIncentiveModelWise> GetList(UserBase user, Filter filter, int Month, int Model, int Ageing, string Status)
        {

            IDbDataParameter[] sqlparameters =
           {
        new SqlParameter("@JSONDATA",JsonHelper.ToJson(filter)),
        new SqlParameter("@CompanyGI",user.CompanyGuid),
        new SqlParameter("@UserGuid",user.UserGuid),
        new SqlParameter("@Month",Month),
        new SqlParameter("@Model",Model),
        new SqlParameter("@Ageing",Ageing),
        new SqlParameter("@Status",Status),
          };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SPOT_INCENTIVE_LIST_MODELWISE]", sqlparameters);

            return PopulateGetList(ds);

        }
        public SpotIncentiveModelWise PopulateGetList(DataSet ds)
        {

            SpotIncentiveModelWise model = new SpotIncentiveModelWise();
            model.SpotIncentiveModelWiseList = new List<SpotIncentiveModelWise>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new SpotIncentiveModelWise
                    {
                        HDCode = MakeSafe.ToSafeInt32(row["ID"]),
                        VIN = MakeSafe.ToSafeString(row["VIN"]),
                        ModelName = MakeSafe.ToSafeString(row["ModelName"]),
                        VariantName = MakeSafe.ToSafeString(row["VariantName"]),
                        StockStatus = MakeSafe.ToSafeString(row["StockStatus"]),
                        AllotmentStatus = MakeSafe.ToSafeString(row["AllotmentStatus"]),
                        QCStatus = MakeSafe.ToSafeString(row["QCStatus"]),
                        Stock_Age = MakeSafe.ToSafeInt32(row["Stock_Age"]),
                        Stock_Ageing_Bucket = MakeSafe.ToSafeString(row["Stock_Ageing_Bucket"]),
                        DSE = MakeSafe.ToSafeDecimal(row["DSEAmount"]),
                        TL = MakeSafe.ToSafeDecimal(row["TLAmount"]),
                        SM = MakeSafe.ToSafeDecimal(row["SMAmount"]),
                        TotalCount = MakeSafe.ToSafeInt32(row["TotalCount"]),
                        IncentiveStatus = MakeSafe.ToSafeInt32(row["IncentiveStatus"]),
                        ModelType = MakeSafe.ToSafeString(row["Type"]),
                    };

                    model.SpotIncentiveModelWiseList.Add(item);
                }
            }

            return model;
        }
        public async Task<SpotIncentiveModelWise> GetDetails(UserBase user, int HDCode,string VIN)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),


                new SqlParameter("@HDCode",HDCode),
                new SqlParameter("@VIN",VIN),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_DMS_SPOT_INCENTIVE_DETAILS_MODELWISE]", sqlparameters);

            return PopulateGetDetails(ds);

        }
        public SpotIncentiveModelWise PopulateGetDetails(DataSet ds)
        {
            SpotIncentiveModelWise model = new SpotIncentiveModelWise();
            model.Month = new Dropdown();
            model.Transmission = new Dropdown();
            model.FuelType = new Dropdown();
            model.Type = new Dropdown();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.HDCode = MakeSafe.ToSafeInt32(row["ID"]);
                model.VIN = MakeSafe.ToSafeString(row["VIN"]);
                model.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                model.ChaseNo = MakeSafe.ToSafeString(row["ChaseNo"]);

                model.Model = MakeSafe.ToSafeInt32(row["Model"]);
                model.ModelName = MakeSafe.ToSafeString(row["ModelName"]);

                model.Variant = MakeSafe.ToSafeInt32(row["Variant"]);
                model.VariantName = MakeSafe.ToSafeString(row["VariantName"]);

                model.Color = MakeSafe.ToSafeInt32(row["Color"]);
                model.ColorName = MakeSafe.ToSafeString(row["ColorName"]);

                model.Transmission.Code = MakeSafe.ToSafeInt32(row["Transmission"]);
                model.FuelType.Code = MakeSafe.ToSafeInt32(row["FuelType"]);

                model.Type.Name = MakeSafe.ToSafeString(row["ModelType"]);
                model.DSE = MakeSafe.ToSafeDecimal(row["DSE"]);
                model.TL = MakeSafe.ToSafeDecimal(row["TL"]);
                model.SM = MakeSafe.ToSafeDecimal(row["SM"]);

                model.Month.Code = MakeSafe.ToSafeInt32(row["MonthCode"]);
            }

            return model;
        }
    }
}
