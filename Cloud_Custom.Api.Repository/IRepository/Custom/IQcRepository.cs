using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface IQcRepository
    {
        Task<Qc> GetList(UserBase user, Filter filter,int Region,int Branch);
        Task<QcItem> GetDetails(UserBase user, int SalesVehicleCode);
        Task<ResponseEntity> Save(UserBase user, Qc model);
    }
}
