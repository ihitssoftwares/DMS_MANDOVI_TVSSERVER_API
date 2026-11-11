using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IWareHouseRepository
    {
        Task<WareHouse> GetList(UserBase user, string TabIndex);
        public Task<ResponseEntity> Save(UserBase user, string mode, WareHouse input);
        public Task<WareHouse> GetWareHouseDetails(UserBase User, int WarehouseCode, string mode, string Type);
        public Task<ResponseEntity> DeleteWareHouse(UserBase user, WareHouse model);
    }
}
