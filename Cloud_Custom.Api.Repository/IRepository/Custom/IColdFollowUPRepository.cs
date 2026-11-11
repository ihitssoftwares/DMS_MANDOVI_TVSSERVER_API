using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface IColdFollowUPRepository
    {
        
        Task<ColdFollowUP> GetList(UserBase user, Filter filter);
        Task<ColdFollowUPItem> GetEmployeeDetails(UserBase user, string EnqNo, int Trnno);
        Task<ResponseEntity> Save(UserBase user, ColdFollowUP model);

    }
}
