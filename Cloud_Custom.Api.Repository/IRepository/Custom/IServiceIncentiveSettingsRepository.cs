using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceIncentiveSettingsRepository
    {

        Task<ServiceIncentiveSettings> GetList(UserBase user, int Month, int IncentiveGroup, int Region);

        Task<ServiceIncentiveSettings> GeteditList(UserBase user, int Month, int IncentiveGroup, int Region, int ParameterCode);
        Task<ServiceIncentiveSettings> GetIncentiveSettingsDetails(UserBase user, int ParameterCode, int month, int IncentiveGroup, int Region);
        public Task<ResponseEntity> SettingsSave(UserBase User, ServiceIncentiveSettings model, int monthcode);

        Task<ResponseEntity> IncentiveSettingsSave(UserBase user, ServiceIncentiveSettings model);
        Task<ResponseEntity> SavePopup(UserBase user, int monthfromCode, int MonthToCode, int RegionCode);
    }
}
