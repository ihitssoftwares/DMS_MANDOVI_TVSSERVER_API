using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceAccessoriesRepository
    {
        Task<ServiceAccessories> GetList(UserBase user, int isAssigned);
        Task<ServiceAccessories> GetPopupDetails(UserBase user, int AccessoriesCode);
        public Task<ResponseEntity> PopupSave(UserBase user, ServiceAccessories model);
    }
}
