using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public  interface IColdCallEnquireRepository
    {
        Task<ColdCallEnquire> GetList(UserBase user);
        Task<ColdCallEnquireItem> GetEmployeeDetails(UserBase user,string ColdCallNo);

        Task<ResponseEntity> Save(UserBase user, ColdCallEnquire model);
    }
}
