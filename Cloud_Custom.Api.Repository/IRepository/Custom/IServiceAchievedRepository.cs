using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IServiceAchievedRepository
    {
        Task<ServiceAchieved> GetList(UserBase user, int Month, int Designation, int Parameter);
        Task<ResponseEntity> Save(UserBase user, ServiceAchieved model);
    }
}
