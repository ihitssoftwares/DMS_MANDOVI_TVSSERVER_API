using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.MobileApp
{
     public class MobileAppSettingsRepository : IMobileAppSettingsRepository
    {
        private readonly ISqlConnectionProvider _sql;

        public MobileAppSettingsRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }


        public async Task<ResponseEntity> UpdateMobileFcmID(MobileAppSettings DiviceData, UserBase user)
        {

            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
            new SqlParameter("@JSONDATA",JsonHelper.ToJson(DiviceData)),
            new SqlParameter("@UserGI",user.UserGuid),
            new SqlParameter("@CompanyGI",user.CompanyGuid),
            ResponseKey,ResponseStatus
            };
            await _sql.ExecuteNonQueryAsync("[MOBILE].[SP_UPDATE_MOBILE_FCM_ID]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

        public async Task<ResponseEntity> SetMobAppVersion(MobAppVersion VersionData, UserBase user)
        {

            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
            new SqlParameter("@JSONDATA",JsonHelper.ToJson(VersionData)),
            new SqlParameter("@CompanyGI",user.CompanyGuid),
            new SqlParameter("@UserGuid",user.UserGuid),
            ResponseKey,ResponseStatus
            };
            await _sql.ExecuteNonQueryAsync("[MOBILE].[SP_UPDATE_MOBILE_APP_VERSION]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }


        public async Task<MobAppVersion> GetAppVersion()
        {
            IDbDataParameter[] sqlParameters =
            {

            };
            var ds = await _sql.GetDataSetAsync("[MOBILE].[SP_GET_MOBILE_APP_VERSION]", sqlParameters);
            return PopulateAppVersionDetails(ds);
        }

        private MobAppVersion PopulateAppVersionDetails(DataSet ds)
        {
            MobAppVersion Model = new MobAppVersion();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Model.AndroidVersion = MakeSafe.ToSafeString(row["AndroidVersion"]);
                    Model.IOSVersion = MakeSafe.ToSafeString(row["IOSVersion"]);
                    Model.AndroidUrl = MakeSafe.ToSafeString(row["AndroidUrl"]);
                    Model.IOSUrl = MakeSafe.ToSafeString(row["IOSUrl"]);
                    Model.updateStatus = MakeSafe.ToSafeString(row["updateStatus"]);
                    Model.CreatedDate = MakeSafe.ToSafeDateTime(row["CreatedDate"]);
                }
            }
            return Model;
        }

        public async Task<MobileAppSettings> GetNotificationCountDetails(UserBase userBase)
        {
            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                new SqlParameter("@UserGuid",userBase.UserGuid)
            };
            var ds = await _sql.GetDataSetAsync("[MOBILE].[SP_MOBILE_NOTIFICATION_COUNT_DETAILS]", sqlparameters);
            return MobilePopulateMobileAppSettings(ds);
        }

        private MobileAppSettings MobilePopulateMobileAppSettings(DataSet ds)
        {
            MobileAppSettings Model = new MobileAppSettings();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Model.AllCount = MakeSafe.ToSafeInt32(row["AllCount"]);
                    Model.LeaveCount = MakeSafe.ToSafeInt32(row["LeaveCount"]);
                    Model.OnDutyCount = MakeSafe.ToSafeInt32(row["OnDutyCount"]);
                    Model.COFFCount = MakeSafe.ToSafeInt32(row["COFFCount"]);
                    Model.PermissionHourCount = MakeSafe.ToSafeInt32(row["PermissionHourCount"]);
                    Model.WFHCount = MakeSafe.ToSafeInt32(row["WFHCount"]);
                    Model.AttendanceRegularizationCount = MakeSafe.ToSafeInt32(row["AttendanceRegularizationCount"]);
                    Model.Absenteeism = MakeSafe.ToSafeDecimal(row["Absenteeism"]);
                    Model.SalaryAdvanceCount = MakeSafe.ToSafeInt32(row["SalaryAdvanceCount"]);
                    Model.ResignationApprovalCount = MakeSafe.ToSafeInt32(row["ResignationApprovalCount"]);
                    Model.GrievanceApprovalCount = MakeSafe.ToSafeInt32(row["GrievanceApprovalCount"]);
                    Model.CoffCreditApprovalCount = MakeSafe.ToSafeInt32(row["CoffCreditApprovalCount"]);
                    Model.SocialWallCount = MakeSafe.ToSafeInt32(row["SocialWallCount"]);
                    Model.HrAnnouncementsCount = MakeSafe.ToSafeInt32(row["HrAnnouncementsCount"]);
                    Model.LoanRequestCount = MakeSafe.ToSafeInt32(row["LoanRequestCount"]);
                    Model.PunchingRegularizationCount = MakeSafe.ToSafeInt32(row["PunchingRegularizationCount"]);
                    Model.LateInCount = MakeSafe.ToSafeInt32(row["LateInCount"]);
                    Model.EarlyOutCount = MakeSafe.ToSafeInt32(row["EarlyOutCount"]);
                    Model.AssetApprovalCount = MakeSafe.ToSafeInt32(row["AssetApprovalCount"]);
                    Model.SocialWallApprovalCount = MakeSafe.ToSafeInt32(row["SocialWallApprovalCount"]);
                    Model.PendingTaskCount = MakeSafe.ToSafeInt32(row["PendingTaskCount"]);
                    Model.NotificationListCount = MakeSafe.ToSafeInt32(row["NotificationListCount"]);
                    Model.NewsFeedCount = MakeSafe.ToSafeInt32(row["NewsFeedCount"]);
                    Model.NeedProfilePhoto = MakeSafe.ToSafeInt32(row["NeedProfilePhoto"]);
                    Model.RequestToHrApprovalCount = MakeSafe.ToSafeInt32(row["RequestToHrApprovalCount"]);
                }
            }
            return Model;
        }

        public async Task<MobileAppSettings> GetMobDefaultLandingPage(UserBase userBase)
        {
            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                new SqlParameter("@UserGuid",userBase.UserGuid)
            };
            var ds = await _sql.GetDataSetAsync("[MOBILE].[SP_GET_DEFAULT_LANDING_PAGE]", sqlparameters);
            return PopulateMobDefaultLandingPage(ds);
        }

        private MobileAppSettings PopulateMobDefaultLandingPage(DataSet ds)
        {
            MobileAppSettings Model = new MobileAppSettings();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Model.DefaultLangingPage = MakeSafe.ToSafeString(row["DefaultLangingPage"]);
                    Model.GoogleMapKey = MakeSafe.ToSafeString(row["GoogleMapKey"]);
                    Model.MobilePunchingRadius = MakeSafe.ToSafeInt32(row["MobilePunchingRadius"]);

                }
            }
            return Model;
        }
    }
}
