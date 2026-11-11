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
    public class ServiceIncentiveSettingsGroupWiseRepository : IServiceIncentiveSettingsGroupWiseRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceIncentiveSettingsGroupWiseRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ServiceIncentiveSettingsGroupWise> GetList(UserBase user, int Month, int Parameter, int Region)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Month",Month),
                 new SqlParameter("@ParameterCode",Parameter),
                 new SqlParameter("@RegionCode",Region),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceIncentiveSettingsGroupWise DesignationVsParameterList(DataSet dataSet)
        {
            ServiceIncentiveSettingsGroupWise model = new ServiceIncentiveSettingsGroupWise();
            List<ServiceIncentiveSettingsGroupWise> List = new List<ServiceIncentiveSettingsGroupWise>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceIncentiveSettingsGroupWise();


                    item.IncentiveGroupCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                    item.IncentiveGroupName = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                    item.RegionCode = MakeSafe.ToSafeInt32(row["RegionCode"]);
                    item.WorkShopName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
                    item.SlabType = MakeSafe.ToSafeString(row["SlabType"]);
                    item.IncentiveType = MakeSafe.ToSafeString(row["IncentiveType"]);
                    item.SlabFrom = MakeSafe.ToSafeDecimal(row["SlabFrom"]);
                    item.SlabTo = MakeSafe.ToSafeDecimal(row["SlabTo"]);
                    item.Incentive = MakeSafe.ToSafeDecimal(row["Incentive"]);
                    item.Colorcode = MakeSafe.ToSafeString(row["Colorcode"]);


                    List.Add(item);
                }
                model.List = List;
            }
            

            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    
                    model.PendingCount = MakeSafe.ToSafeInt32(row["PendingCount"]);

                }
            }
            return model;
        }


        public async Task<ServiceIncentiveSettingsGroupWise> GeteditList(UserBase user, int Month, int IncentiveGroup, int Region, int ParameterCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Month",Month),
                 new SqlParameter("@IncentiveGroupCode",IncentiveGroup),
                 new SqlParameter("@RegionCode",Region),
                 new SqlParameter("@ParameterCode",ParameterCode),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_DATA]", sqlparameters);
                return ParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceIncentiveSettingsGroupWise ParameterList(DataSet dataSet)
        {
            ServiceIncentiveSettingsGroupWise model = new ServiceIncentiveSettingsGroupWise();
            List<EditServiceIncentiveSettingsGroupWise> List = new List<EditServiceIncentiveSettingsGroupWise>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new EditServiceIncentiveSettingsGroupWise();



                    item.IncentiveGroupCode= MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                    item.IncentiveGroupName = MakeSafe.ToSafeString(row["IncentiveGroupName"]);
                    item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
                    item.SlabType = MakeSafe.ToSafeString(row["SlabType"]);                   
                    item.IncentiveType = MakeSafe.ToSafeString(row["IncentiveType"]);
                    item.SlabFrom = MakeSafe.ToSafeDecimal(row["SlabFrom"]);
                    item.SlabTo = MakeSafe.ToSafeDecimal(row["SlabTo"]);
                    item.Incentives = MakeSafe.ToSafeDecimal(row["Incentive"]);
                    


                    List.Add(item);
                }
                model.EditList = List;
            }
            return model;

        }

        public async Task<ResponseEntity> SettingsSave(UserBase User, ServiceIncentiveSettingsGroupWise model,int monthcode)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                IDbDataParameter[] sqlParameters =
                {
                    new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),   
                    new SqlParameter("@CompanyGI",User.CompanyGuid),
                    new SqlParameter("@UserGI",User.UserGuid),
                    new SqlParameter("@Monthcode",monthcode),
            ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_INCENTIVE_TARGET_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException EX)
            {
                var ErrorMsg = EX.Message.ToString();
                throw new Exception(ErrorMsg, EX);
            }
        }

        public async Task<ServiceIncentiveSettingsGroupWise> GetIncentiveSettingsDetails(UserBase user, int IncentiveGroupCode, int month, int Parameter, int Region)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@ParameterCode",Parameter),
                new SqlParameter("@Month",month),
                new SqlParameter("@IncentiveGroupCode",IncentiveGroupCode),
                new SqlParameter("@RegionCode",Region),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_DATA_PARAMETER]", sqlparameters);

            return PopulateGetIncentiveSettingsDetails(ds);

        }


        public ServiceIncentiveSettingsGroupWise PopulateGetIncentiveSettingsDetails(DataSet ds)
        {
            ServiceIncentiveSettingsGroupWise model = new ServiceIncentiveSettingsGroupWise();
            List<DetailsServiceIncentiveSettingsGroupWise> List = new List<DetailsServiceIncentiveSettingsGroupWise>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new DetailsServiceIncentiveSettingsGroupWise();
                    
                        item.DMonthCode = MakeSafe.ToSafeInt32(row["MonthCode"]);
                        item.DWorkShopCode = MakeSafe.ToSafeInt32(row["WorkShopCode"]);
                        item.DIncentiveGroupCode = MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                        item.DParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                        item.DParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
                        item.DSlabType = MakeSafe.ToSafeString(row["SlabType"]);
                        item.DIncentiveType = MakeSafe.ToSafeString(row["IncentiveType"]);
                        item.DSlabFrom = MakeSafe.ToSafeDecimal(row["SlabFrom"]);
                        item.DSlabTo = MakeSafe.ToSafeDecimal(row["SlabTo"]);
                        item.DIncentives = MakeSafe.ToSafeDecimal(row["Incentive"]);

                        List.Add(item);
                }

                model.DetailsList = List;
            }

            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {

                    model.ParameterName = MakeSafe.ToSafeString(row["parametername"]);
                    model.WorkShopName = MakeSafe.ToSafeString(row["regionname"]);
                    model.IncentiveType = MakeSafe.ToSafeString(row["incentivegroupname"]);
                    model.MonthName = MakeSafe.ToSafeString(row["MonthName"]);

                }
            }


            return model;
        }



        public async Task<ResponseEntity> IncentiveSettingsSave(UserBase user, ServiceIncentiveSettingsGroupWise model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }


        public async Task<ResponseEntity> SavePopup(UserBase user, int monthfromCode, int MonthToCode, int RegionCode)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                     new SqlParameter("@MonthcodeFrom",monthfromCode),
                     new SqlParameter("@MonthcodeTo",MonthToCode),
                      new SqlParameter("@RegionCode",RegionCode),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_INCENTIVE_SETTINGS_TRANSFER]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

    }
}
