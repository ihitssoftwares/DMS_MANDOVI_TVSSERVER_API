using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
    public class MobileAppSettings : MasterBase
    {
        public UserBase User { get; set; }
        public MobDeviceData MobileData { get; set; }

        public int AllCount { get; set; }
        public int LeaveCount { get; set; }
        public int OnDutyCount { get; set; }
        public int COFFCount { get; set; }
        public int WFHCount { get; set; }
        public int PermissionHourCount { get; set; }
        public int AttendanceRegularizationCount { get; set; }
        public decimal Absenteeism { get; set; }
        public int SalaryAdvanceCount { get; set; }
        public int ResignationApprovalCount { get; set; }
        public int GrievanceApprovalCount { get; set; }
        public int CoffCreditApprovalCount { get; set; }
        public int SocialWallCount { get; set; }
        public int HrAnnouncementsCount { get; set; }
        public int LoanRequestCount { get; set; }
        public int PunchingRegularizationCount { get; set; }
        public int LateInCount { get; set; }
        public int EarlyOutCount { get; set; }
        public int AssetApprovalCount { get; set; }
        public int SocialWallApprovalCount { get; set; }
        public int PendingTaskCount { get; set; }
        public int NotificationListCount { get; set; }
        public int NewsFeedCount { get; set; }
        public int NeedProfilePhoto { get; set; }
        public int RequestToHrApprovalCount { get; set; }

        public string DefaultLangingPage { get; set; }
        public string GoogleMapKey { get; set; }
        public int MobilePunchingRadius { get; set; }
    }

}
