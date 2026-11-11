using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceIncentiveSettingsGroupWiseRepository
    {

        Task<ServiceIncentiveSettingsGroupWise> GetList(UserBase user, int Month, int Parameter, int Region);

        Task<ServiceIncentiveSettingsGroupWise> GeteditList(UserBase user, int Month, int IncentiveGroup, int Region, int ParameterCode);
        Task<ServiceIncentiveSettingsGroupWise> GetIncentiveSettingsDetails(UserBase user, int IncentiveGroupCode, int month, int Parameter, int Region);
        public Task<ResponseEntity> SettingsSave(UserBase User, ServiceIncentiveSettingsGroupWise model, int monthcode);

        Task<ResponseEntity> IncentiveSettingsSave(UserBase user, ServiceIncentiveSettingsGroupWise model);
        Task<ResponseEntity> SavePopup(UserBase user, int monthfromCode, int MonthToCode, int RegionCode);
    }
}
