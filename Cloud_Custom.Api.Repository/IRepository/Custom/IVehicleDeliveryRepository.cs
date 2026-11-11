using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IVehicleDeliveryRepository
    {
        Task<VehicleDelivery> GetList(UserBase user);
        public Task<VehicleDelivery> GetDetails(UserBase User, int RegistrationCode);
        Task<ResponseEntity> Save(UserBase user, VehicleDelivery model);
    }
}
