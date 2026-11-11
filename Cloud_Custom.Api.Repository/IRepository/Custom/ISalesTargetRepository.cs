using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface ISalesTargetRepository
    {
        Task<SalesTarget> GetList(UserBase user, int Month, int Branch);
        Task<SalesTarget> GetEmployeeDetails(UserBase user, int Month, int Type,int TeamLeadCode);
        Task<ResponseEntity> EmpSave(SalesTarget Model);

    }
}
