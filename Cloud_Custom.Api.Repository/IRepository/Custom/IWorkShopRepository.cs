using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IWorkShopRepository
    {
        Task<WorkShop> GetList(UserBase user);
        public Task<ResponseEntity> Save(UserBase user, string mode, WorkShop input);
        public Task<WorkShop> GetWorkShopDetails(UserBase User, int WorkShopCode, string mode);
        public Task<ResponseEntity> DeleteWorkShop(UserBase user, WorkShop model);
    }
}
