using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IMCarePlanSettingsRepository
    {
        Task<MCarePlanSettings> GetList(UserBase user,int PlanCode);
        Task<MCarePlanSettings> GetDetails(UserBase user, int Type);
        Task<MCarePlanSettings> GetEditDetails(UserBase user, int Code, int DtCode);
        Task<ResponseEntity> Save(UserBase user, MCarePlanSettings model);
        Task<ResponseEntity> SaveSettings(UserBase user, MCarePlanSettings model);
    }
}
