using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceMstRepository
    {

        Task<ServiceMst> GetList(UserBase user,int isAssigned);
        Task<ServiceMst> GetPopupDetails(UserBase user, int ServiceCode);
        public Task<ResponseEntity> PopupSave(UserBase user, ServiceMst model);
    }
}
