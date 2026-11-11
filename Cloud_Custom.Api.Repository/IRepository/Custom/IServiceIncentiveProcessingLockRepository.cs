using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceIncentiveProcessingLockRepository
    {
        Task<ServiceIncentiveProcessingLock> GetList(UserBase user, int Month);
        public Task<ResponseEntity> Save(ServiceIncentiveProcessingLock model, UserBase user);
        //Task<ResponseEntity> EmployeeWiseUpdate(UserBase user, ServiceIncentiveProcessingLock model);
    }
}
