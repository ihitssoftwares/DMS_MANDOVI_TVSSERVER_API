using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public  interface IMcareCancellationRepository
    {
        Task<McareCancellation> GetList(UserBase user,int PlanCode,int EntryCode);
        Task<ResponseEntity> Save(UserBase user, McareCancellation model);
    }
}
