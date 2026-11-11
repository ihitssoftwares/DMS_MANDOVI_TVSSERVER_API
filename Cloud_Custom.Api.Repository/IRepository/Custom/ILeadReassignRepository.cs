using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface ILeadReassignRepository
    {
       
        Task<LeadReassign> GetList(UserBase user, Filter filter);
        Task<LeadReassignItem> GetEmployeeDetails(UserBase user, int Trnno);
        Task<LeadReassign> GetUpdatedDetails(UserBase user, int Trnno);
        Task<ResponseEntity> Save(UserBase user, LeadReassign model);

    }
}
