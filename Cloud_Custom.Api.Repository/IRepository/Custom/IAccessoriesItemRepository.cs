using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IAccessoriesItemRepository
    {
        Task<AccessoriesItem> GetList(UserBase user, string TabIndex);
        public Task<ResponseEntity> Save(UserBase user, string mode, AccessoriesItem input);
        public Task<AccessoriesItem> GetAccessoriesDetails(UserBase User, int ItemCode, string mode, string Type);
        public Task<ResponseEntity> DeleteAccessories(UserBase user, AccessoriesItem accessoriesItem);
    }
}
