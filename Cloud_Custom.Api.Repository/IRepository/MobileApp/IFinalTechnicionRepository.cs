using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
    public  interface IFinalTechnicionRepository
    {
        Task<FinalTechnician> GetTechnicionTiles(UserBase user);
        Task<FinalTechnician> MobileRegNoSearch(UserBase user, string REGNO);
        Task<FinalTechnician> GetMCareDetails(UserBase user, int CustomerCode);
        Task<FinalTechnician> GetJobInProgressList(UserBase user);
        Task<FinalTechnician> GetTechnicianHistory(UserBase user, string Date);
        Task<FinalTechnician> GetTechnicianRecentList(UserBase user);
        public Task<ResponseEntity> GetServiceTechnicianSave(UserBase user, FinalTechnician model, string Mode);
       
    }
}
