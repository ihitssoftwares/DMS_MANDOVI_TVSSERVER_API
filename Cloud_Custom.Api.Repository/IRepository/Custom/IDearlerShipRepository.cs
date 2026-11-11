using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface IDearlerShipRepository
    {
        Task<DearlerShip> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, DearlerShip model);
        public Task<DearlerShip> GetDealershipDetails(UserBase User, int DealerCode, string mode, string Type);
        public Task<ResponseEntity> DearlerDelete(UserBase User, DearlerShip model);
    }
}
