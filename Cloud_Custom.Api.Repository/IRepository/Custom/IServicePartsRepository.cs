using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServicePartsRepository
    {
        Task<ServiceParts> GetList(UserBase user);

        //public Task<ResponseEntity> Save(UserBase user, string mode, ServiceParts input);
        //public Task<ServiceParts> GetWareHouseDetails(UserBase User, int WarehouseCode, string mode, string Type);
        //public Task<ResponseEntity> DeleteWareHouse(UserBase user, WareHouse model);
    }
}
