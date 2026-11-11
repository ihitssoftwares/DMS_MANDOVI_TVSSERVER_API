using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface IServiceIncentiveSlabSettingsRepository
    {
        Task<ServiceIncentiveSlabSettings> GetList(UserBase user, string Branch, string Designation, string WEFDate);
        Task<SlabItem> GetParameterDetails(UserBase user, int ParameterCode);
        Task<ResponseEntity> ServiceSave(UserBase user, ServiceIncentiveSlabSettings model);
    }
}
