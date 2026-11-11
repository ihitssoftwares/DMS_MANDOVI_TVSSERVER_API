using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceTargetIncentiveParameterRepository
    {

        Task<ServiceTargetIncentiveParameter> GetList(UserBase user, int Month, int Parameter, int Region);

        Task<ServiceTargetIncentiveParameter> GeteditList(UserBase user, int Month, int Parameter, int Region);

        public Task<ResponseEntity> SettingsSave(UserBase User, ServiceTargetIncentiveParameter model, int monthcode);

        Task<ResponseEntity> SavePopup(UserBase user, int monthfromCode, int MonthToCode, int RegionCode);

    }
}
