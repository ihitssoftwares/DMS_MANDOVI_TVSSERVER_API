using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IIncentiveTargetRegionSettingsRepository
    {

        Task<IncentiveTargetRegionSettings> GetList(UserBase user, int EmployeeCode);
        Task<IncentiveTargetRegionSettings> GetDetails(UserBase user, int EmployeeCode);

        Task<ResponseEntity> IncentiveSettingsSave(UserBase user, IncentiveTargetRegionSettings model, int TLEmployeeCode);

    }
}
