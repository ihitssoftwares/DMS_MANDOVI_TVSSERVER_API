using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public   interface IExchangeIncentiveSettingRepository
    {
        Task<ExchangeIncentiveSetting> GetList(UserBase user, int Month, int Designation,int Region);
        Task<ExchangeIncentiveSetting> GetExchangeIncentiveSettingsDetails(UserBase user, int Month, int Designation,int Region);
        Task<ResponseEntity> ExchangeIncentiveSettingSave(UserBase user, ExchangeIncentiveSetting model);
    }
}
