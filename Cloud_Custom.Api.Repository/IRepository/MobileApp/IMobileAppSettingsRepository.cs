using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
     public interface IMobileAppSettingsRepository
    {
        Task<ResponseEntity> UpdateMobileFcmID(MobileAppSettings DiviceData, UserBase user);
        Task<ResponseEntity> SetMobAppVersion(MobAppVersion DiviceData, UserBase userBase);
        Task<MobAppVersion> GetAppVersion();
        Task<MobileAppSettings> GetNotificationCountDetails(UserBase userBase);
        Task<MobileAppSettings> GetMobDefaultLandingPage(UserBase userBase);

    }
}
