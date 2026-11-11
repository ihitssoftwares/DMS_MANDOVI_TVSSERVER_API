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
    public class PriceSettingsRepository : IPriceSettingsRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public PriceSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<PriceSettings> GetList(UserBase user, int Type,int Region)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",Type),
                 new SqlParameter("@Region",Region),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_Varient_LIST]", sqlparameters);
                return PriceSettingsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private PriceSettings PriceSettingsList(DataSet dataSet)
        {
            PriceSettings model = new PriceSettings();
            model.Model = new Dropdown();
            model.Region = new Dropdown();
            model.VariantWiseList = new List<PriceSettings>();

            // Always bind dropdown from Tables[1]
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                model.Model.Code = MakeSafe.ToSafeInt32(dataSet.Tables[1].Rows[0]["ModelId"]);
                model.Model.Name = MakeSafe.ToSafeString(dataSet.Tables[1].Rows[0]["ModelName"]);
                model.Region.Code = MakeSafe.ToSafeInt32(dataSet.Tables[1].Rows[0]["RegionId"]);
                model.Region.Name = MakeSafe.ToSafeString(dataSet.Tables[1].Rows[0]["RegionName"]);
            }

          

            // Bind list from Tables[0] if data exists
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<PriceSettings> List = new List<PriceSettings>();
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new PriceSettings();
                    item.SlNo = MakeSafe.ToSafeInt32(row["SlNo"]);
                    item.PriceId = MakeSafe.ToSafeInt32(row["PriceId"]);
                    item.ModelName = MakeSafe.ToSafeString(row["ModelName"]);
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.VarientName = MakeSafe.ToSafeString(row["VarientName"]);
                    item.Fuelname = MakeSafe.ToSafeString(row["Fuelname"]);
                    item.TransmissionName = MakeSafe.ToSafeString(row["TransmissionTypeName"]);
                    //item.ColorName = MakeSafe.ToSafeString(row["ColorName"]);
                    item.OnShowPrice = MakeSafe.ToSafeDecimal(row["OnShowPrice"]);
                    //item.Gst = MakeSafe.ToSafeDecimal(row["Gst"]);
                    item.TCS = MakeSafe.ToSafeDecimal(row["TCS"]);
                
                    //item.WarrantyAmount = MakeSafe.ToSafeInt32(row["WarrantyAmount"]);

                    item.RoadTax = MakeSafe.ToSafeDecimal(row["RoadTax"]);
                    item.RegnExp = MakeSafe.ToSafeDecimal(row["RegnExp"]);
                    item.Insurance = MakeSafe.ToSafeDecimal(row["Insurance"]);
                    item.Fastag = MakeSafe.ToSafeDecimal(row["Fastag"]);

                    item.OnRoadPrice = MakeSafe.ToSafeDecimal(row["OnRoadPrice"]);

                    item.EW = MakeSafe.ToSafeDecimal(row["EW"]);
                    item.MSILRewards = MakeSafe.ToSafeDecimal(row["MSILRewards"]);
                    item.BasicAccessories = MakeSafe.ToSafeDecimal(row["BasicAccessories"]);
                    item.SMP = MakeSafe.ToSafeDecimal(row["SMP"]);

                    item.TotalOnRoad = MakeSafe.ToSafeDecimal(row["TotalOnRoad"]);

                    List.Add(item);
                }
                model.VariantWiseList = List;
            }
            return model;
        }

        public async Task<ResponseEntity> Save(UserBase user, PriceSettings model, string mode)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@Mode",mode),
               new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SAVE_PRICE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
        public async Task<PriceSettings> GetVarientDetails(UserBase User, int PriceId, string mode)
        {

            IDbDataParameter[] sqlParameters =
             {
                new SqlParameter("@CompanyGI",User.CompanyGuid),
                 new SqlParameter("@UserGuid",User.UserGuid),
                new SqlParameter("@PriceId",PriceId),


            };
            var dataSet = await _sql.GetDataSetAsync("[DMS].[SP_Varient_DETAILS]", sqlParameters);
            return PopulateVariantDetails(dataSet);

        }

        private PriceSettings PopulateVariantDetails(DataSet dataSet)
        {
            PriceSettings model = new PriceSettings();
            model.Variant = new Dropdown();
            //model.Color = new Dropdown();
            model.FuelType = new Dropdown();
            model.TransmissionType = new Dropdown();
            model.Model = new Dropdown();

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                model.FromDate = MakeSafe.ToSafeDateTime(row["EffectiveFrom"]);
                model.ToDate = MakeSafe.ToSafeDateTime(row["EffectiveTo"]);

                model.PriceId = MakeSafe.ToSafeInt32(row["PriceId"]);
                model.Model.Code = MakeSafe.ToSafeInt32(row["ModelId"]); 
                model.Variant.Code = MakeSafe.ToSafeInt32(row["VariantId"]);
                model.FuelType.Code = MakeSafe.ToSafeInt32(row["FuelTypeId"]);
                model.TransmissionType.Code = MakeSafe.ToSafeInt32(row["TransmissionTypeId"]);
                //model.Color.Code = MakeSafe.ToSafeInt32(row["ColorId"]);

                model.OnShowPrice = MakeSafe.ToSafeDecimal(row["OnShowPrice"]);
                //model.Gst = MakeSafe.ToSafeDecimal(row["Gst"]);
                model.TCS = MakeSafe.ToSafeDecimal(row["TCS"]);
                model.OnRoadPrice = MakeSafe.ToSafeDecimal(row["OnRoadPrice"]);
                //model.WarrantyAmount = MakeSafe.ToSafeInt32(row["WarrantyAmount"]);

                model.RoadTax = MakeSafe.ToSafeDecimal(row["RoadTax"]);
                model.RegnExp = MakeSafe.ToSafeDecimal(row["RegnExp"]);
                model.Insurance = MakeSafe.ToSafeDecimal(row["Insurance"]);
                model.Fastag = MakeSafe.ToSafeDecimal(row["Fastag"]);

                model.OnRoadPrice = MakeSafe.ToSafeDecimal(row["OnRoadPrice"]);

                model.EW = MakeSafe.ToSafeDecimal(row["EW"]);
                model.MSILRewards = MakeSafe.ToSafeDecimal(row["MSILRewards"]);
                model.BasicAccessories = MakeSafe.ToSafeDecimal(row["BasicAccessories"]);
                model.SMP = MakeSafe.ToSafeDecimal(row["SMP"]);

                model.TotalOnRoad = MakeSafe.ToSafeDecimal(row["TotalOnRoad"]);

            }

            return model;
        }

    }
}
