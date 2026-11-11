using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceTargetIncentiveRepository
    {

        Task<ServiceTargetIncentive> GetList(UserBase user, int Month, int IncentiveGroup, int Region);

        Task<ServiceTargetIncentive> GeteditList(UserBase user, int Month, int IncentiveGroup, int Region);
    
        public Task<ResponseEntity> SettingsSave(UserBase User, ServiceTargetIncentive model,int monthcode);

        Task<ResponseEntity> SavePopup(UserBase user, int monthfromCode, int MonthToCode, int RegionCode);

    }
}
