using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ILabourRepository
    {
        Task<LabourCls> GetList(UserBase user,int isAssigned);
        Task<LabourCls> GetPopupDetails(UserBase user, int LabourCode);
        public Task<ResponseEntity> PopupSave(UserBase user, LabourCls model);

    }
}
