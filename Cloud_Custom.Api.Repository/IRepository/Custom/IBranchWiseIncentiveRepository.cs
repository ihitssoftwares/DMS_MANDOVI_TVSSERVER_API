using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IBranchWiseIncentiveRepository
    {
        Task<BranchWiseIncentive> GetList(UserBase user, int Month, int Parameter, int Region,int IncentiveGroup);

       
        Task<BranchWiseIncentive> GetBranchWiseIncentiveDetails(UserBase user,int HdCode,int BranchCode, int IncentiveGroupCode, int month, int Parameter, int Region);
        

        Task<ResponseEntity> BranchWiseIncentiveSave(UserBase user, BranchWiseIncentive model);
        
    }
}
