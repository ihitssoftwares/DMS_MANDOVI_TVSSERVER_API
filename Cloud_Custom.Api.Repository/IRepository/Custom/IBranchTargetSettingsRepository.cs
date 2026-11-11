using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IBranchTargetSettingsRepository
    {
        Task<BranchTargetSettings> GetList(UserBase user, int Month, int Region);
        
        Task<ResponseEntity> BranchWiseUpdate(UserBase user, BranchTargetSettings model);
        
    }
}
