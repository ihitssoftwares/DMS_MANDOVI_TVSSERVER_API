using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
    public interface ITechnicianInOutSaveRepository
    {
        public Task<ResponseEntity> GetTechnicianInOutSave(UserBase user, TechnicianInOutSave model,string Mode);
    }
}
