using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IVehiclesDeliveryRepository
    {
        Task<VehiclesDelivery> GetList(UserBase user, int Month, int Branch);

        Task<VehiclesDelivery> GetPopUpDetails(UserBase user, int  OrderTrnCode);
        public Task<ResponseEntity> PopupSave(UserBase user, VehiclesDelivery vehicleModel);
    }
}
