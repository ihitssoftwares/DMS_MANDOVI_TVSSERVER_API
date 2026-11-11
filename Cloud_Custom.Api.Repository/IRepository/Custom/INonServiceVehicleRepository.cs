using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface INonServiceVehicleRepository
    {
        Task<NonServiceVehicle> GetList(UserBase user);
        Task<ResponseEntity> Save(UserBase user, string mode, NonServiceVehicle model);
        public Task<NonServiceVehicle> GetNonServiceVehicleDetails(UserBase User, int NonServiceVehicleCode, string mode);
        public Task<ResponseEntity> NonServiceVehicleDelete(UserBase User, NonServiceVehicle model);
    }
}
