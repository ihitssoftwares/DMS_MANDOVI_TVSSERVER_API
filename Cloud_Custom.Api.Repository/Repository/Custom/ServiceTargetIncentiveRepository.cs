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
    public class ServiceTargetIncentiveRepository : IServiceTargetIncentiveRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceTargetIncentiveRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ServiceTargetIncentive> GetList(UserBase user, int Month, int IncentiveGroup, int Region)
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

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_TARGET_LIST]", sqlparameters);
                return DesignationVsParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceTargetIncentive DesignationVsParameterList(DataSet dataSet)
        {
            ServiceTargetIncentive model = new ServiceTargetIncentive();
            List<ServiceTargetIncentive> List = new List<ServiceTargetIncentive>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new ServiceTargetIncentive();



                    item.WorkShopCode = MakeSafe.ToSafeInt32(row["RegionCode"]);
                    item.WorkShopName = MakeSafe.ToSafeString(row["RegionName"]);
                    item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
                    item.TargetType = MakeSafe.ToSafeString(row["TargetType"]);
                    item.Targets = MakeSafe.ToSafeInt32(row["Target"]);
                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
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


        public async Task<ServiceTargetIncentive> GeteditList(UserBase user, int Month, int IncentiveGroup, int Region)
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

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_TARGET_DATA]", sqlparameters);
                return ParameterList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private ServiceTargetIncentive ParameterList(DataSet dataSet)
        {
            ServiceTargetIncentive model = new ServiceTargetIncentive();
            List<EditServiceTargetIncentive> List = new List<EditServiceTargetIncentive>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new EditServiceTargetIncentive();



                    item.IncentiveGroupCode= MakeSafe.ToSafeInt32(row["IncentiveGroupCode"]);
                    item.GroupName = MakeSafe.ToSafeString(row["GroupName"]);
                    item.ParameterCode = MakeSafe.ToSafeInt32(row["ParameterCode"]);
                    item.ParameterName = MakeSafe.ToSafeString(row["ParameterName"]);
                    item.TargetType = MakeSafe.ToSafeString(row["TargetType"]);
                    item.Target = MakeSafe.ToSafeInt32(row["Target"]);
                    item.PreTarget = MakeSafe.ToSafeInt32(row["Prev Target"]);
                    item.BranchCode = MakeSafe.ToSafeInt32(row["BranchCode"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                    item.Colorcode = MakeSafe.ToSafeString(row["Colorcode"]);

                    List.Add(item);
                }
                model.EditList = List;
            }
            return model;

        }

        public async Task<ResponseEntity> SettingsSave(UserBase User, ServiceTargetIncentive model,int monthcode)
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

        public async Task<ResponseEntity> SavePopup(UserBase user, int monthfromCode, int MonthToCode, int RegionCode)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                     new SqlParameter("@MonthcodeFrom",monthfromCode),
                     new SqlParameter("@MonthcodeTo",MonthToCode),
                     new SqlParameter("@Regioncode",RegionCode),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SERVICE_INCENTIVE_TARGET_TRANSFER]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }


    }
}
