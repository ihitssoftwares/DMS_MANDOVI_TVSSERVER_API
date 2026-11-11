using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public  interface IDriverRepository
    {
        Task<Driver> DriverDetails(UserBase user);
        Task<Driver> PickupList(UserBase user);
        public Task<ResponseEntity> UpdateEntryStatus(UserBase user, Driver model);
        public Task<ResponseEntity> UpdateExitStatus(UserBase user, Driver model);
    }
}
