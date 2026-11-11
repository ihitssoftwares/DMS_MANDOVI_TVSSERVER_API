using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface IMCarePlanRepository
    {
        Task<MCarePlan> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, MCarePlan model);
        public Task<MCarePlan> GetMCarePlanDetails(UserBase User, int MCarePlanCode, string mode, string Type);

        public Task<ResponseEntity> Delete(UserBase user, MCarePlan model);
    }
}
