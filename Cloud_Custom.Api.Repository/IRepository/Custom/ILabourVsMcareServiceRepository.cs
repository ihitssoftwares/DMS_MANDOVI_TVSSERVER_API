using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ILabourVsMcareServiceRepository
    {
        Task<LabourVsMcareService> GetList(UserBase user);
        //Task<LabourVsMcareService> GetPopupDetails(UserBase user);
        public Task<ResponseEntity> PopupSave(UserBase user, LabourVsMcareService model);

    }
}
