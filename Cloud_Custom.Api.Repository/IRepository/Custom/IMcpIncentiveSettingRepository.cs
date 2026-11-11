using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public   interface IMcpIncentiveSettingRepository
    {
        Task<McpIncentiveSetting> GetList(UserBase user, int Month, int Designation, int Region);
        Task<McpIncentiveSetting> GetMcpIncentiveSettingsDetails(UserBase user, int Month, int Designation, int Region);
        Task<ResponseEntity> McpIncentiveSettingSave(UserBase user, McpIncentiveSetting model);
    }
}
