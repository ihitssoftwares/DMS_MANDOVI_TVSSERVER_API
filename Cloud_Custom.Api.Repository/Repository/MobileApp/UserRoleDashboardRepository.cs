using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.MobileApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.MobileApp
{
  public   class UserRoleDashboardRepository : IUserRoleDashboardRepository
    {

        private readonly ISqlConnectionProvider _sql;
        public UserRoleDashboardRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<UserRoleDashboard> GetSecuritytotalactivityList(UserBase user,string Date,int WorkShopCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@Date",Date),
                 new SqlParameter("@WorkShopCode",WorkShopCode)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_USER_ROLE_DASHBOARD_SECURITY_COUNT_LIST]", sqlparameters);
                return UserRoleDashboardList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private UserRoleDashboard UserRoleDashboardList(DataSet dataSet)
        {
            UserRoleDashboard model = new UserRoleDashboard();
            List<Security> List = new List<Security>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new Security();

                    item.VehichleIn = MakeSafe.ToSafeInt32(row["vehichleIn"]);
                    item.VehichleOut = MakeSafe.ToSafeInt32(row["VehichleOut"]);
                    item.VehichlePending = MakeSafe.ToSafeInt32(row["VehichlePending"]);
                    

                    List.Add(item);
                }
                model.SecurityCountLIst = List;
            }
            return model;

        }  
        public async Task<UserRoleDashboard> GetSecurityDeatilsList(UserBase user,string Date,int WorkShopCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@Date",Date),
                 new SqlParameter("@WorkShopCode",WorkShopCode)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_USER_ROLE_DASHBOARD_SECURITY_COUNT_LIST]", sqlparameters);
                return GetSecurityDeatilsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private UserRoleDashboard GetSecurityDeatilsList(DataSet dataSet)
        {
            UserRoleDashboard model = new UserRoleDashboard();
            List<Security> DetailsList = new List<Security>();

            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[1].Rows)
                {
                    var item = new Security();

                    item.VehichleRegNo = MakeSafe.ToSafeString(row["RegistrationCode"]);
                    item.VehichleName = MakeSafe.ToSafeString(row["VehichleName"]);
                    item.VehichleInTime = MakeSafe.ToSafeString(row["InOutTime"]);
                    item.TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]);

                    DetailsList.Add(item);
                }
                model.SecurityDetailsLIst = DetailsList;
            }
            return model;

        }
        public async Task<UserRoleDashboard> GetSecurityHistoryDeatilsList(UserBase user,string Date,int WorkShopCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@Date",Date),
                 new SqlParameter("@WorkShopCode",WorkShopCode)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_USER_ROLE_DASHBOARD_SECURITY_COUNT_LIST]", sqlparameters);
                return GetSecurityHistoryDeatilsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex); 
            }
        }
        private UserRoleDashboard GetSecurityHistoryDeatilsList(DataSet dataSet)
        {
            UserRoleDashboard model = new UserRoleDashboard();
            List<Security> DetailsList = new List<Security>();

            if ((dataSet.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[2].Rows)
                {
                    var item = new Security();

                    item.VehichleRegNo= MakeSafe.ToSafeString(row["RegNo"]);
                    item.VehichleName= MakeSafe.ToSafeString(row["VehichleName"]);
                    item.VehichleInTime = MakeSafe.ToSafeString(row["InTime"]);
                    item.VehichleOutTime = MakeSafe.ToSafeString(row["OutTime"]);
                    item.TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]);


                    DetailsList.Add(item);
                }
                model.SecurityHistoryDetailsLIst = DetailsList;
            }
            return model;

        }
        public async Task<UserRoleDashboard> GetSecurityPendingList(UserBase user,string Date,int WorkShopCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@Date",Date),
                 new SqlParameter("@WorkShopCode",WorkShopCode)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_USER_ROLE_DASHBOARD_SECURITY_COUNT_LIST]", sqlparameters);
                return GetSecurityPendingList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex); 
            }
        }
        private UserRoleDashboard GetSecurityPendingList(DataSet dataSet)
        {
            UserRoleDashboard model = new UserRoleDashboard();
            List<Security> PendingList = new List<Security>();

            if ((dataSet.Tables[3]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[3].Rows)
                {
                    var item = new Security();

                    item.VehichleRegNo= MakeSafe.ToSafeString(row["RegistrationCode"]);
                    item.VehichleName= MakeSafe.ToSafeString(row["VehichleName"]);
                    item.VehichleInTime = MakeSafe.ToSafeString(row["InTime"]);
                    item.TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]);

                    PendingList.Add(item);
                }
                model.SecurityPendingLIst = PendingList;
            }
            return model;

        }
         public async Task<UserRoleDashboard> GetSecurityVehicleInList(UserBase user,string Date,int WorkShopCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),
                 new SqlParameter("@Date",Date),
                 new SqlParameter("@WorkShopCode",WorkShopCode)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_USER_ROLE_DASHBOARD_SECURITY_COUNT_LIST]", sqlparameters);
                return GetSecurityVehicleInList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex); 
            }
        }
        private UserRoleDashboard GetSecurityVehicleInList(DataSet dataSet)
        {
            UserRoleDashboard model = new UserRoleDashboard();
            List<Security> PendingList = new List<Security>();

            if ((dataSet.Tables[4]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[4].Rows)
                {
                    var item = new Security();

                    item.VehichleRegNo= MakeSafe.ToSafeString(row["RegistrationCode"]);
                    item.VehichleName= MakeSafe.ToSafeString(row["VehichleName"]);
                    item.VehichleInTime = MakeSafe.ToSafeString(row["InTime"]);
                    item.TrnCode = MakeSafe.ToSafeInt32(row["TrnCode"]);

                    PendingList.Add(item);
                }
                model.SecurityPendingLIst = PendingList;
            }
            return model;

        }

        public async Task<ResponseEntity> GetSecurityVehicleOutSave(UserBase user, UserRoleDashboard model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_SECURITY_DASHBOARD_VEHICLE_OUT_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
        public async Task<ResponseEntity> GetVehichlePassSaveMobile(UserBase user, UserRoleDashboard model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("DMS.[SP_SECURITY_DASHBOARD_VEHICLE_PASS_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

    }
}
