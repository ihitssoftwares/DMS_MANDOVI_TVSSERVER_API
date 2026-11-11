using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
 public   interface IBayServiceSummaryRepository
    {
        Task<BayServiceSummary> GetBayList(UserBase user, int WorkshopCode);
        Task<GateIn> GetGateINList(UserBase user, int WorkshopCode,string Date);
        Task<JobCard> GetjobCardList(UserBase user, int WorkshopCode,string Date);
        Task<TechnicianVsBay> GetBayVsTechList(UserBase user, int WorkshopCode,string Date);
        Task<TechnicianInOut> GetTechInOutList(UserBase user, int WorkshopCode,string Date);
        Task<JobcardCompletetion> GetjobcompletedList(UserBase user, int WorkshopCode,string Date);
        Task<BayServiceSummary> GetBayDetailsList(UserBase user, int jcno);
        Task<BayVsJob> LoadJobCardDetails(UserBase user, int jobCardNo);
        Task<ResponseEntity> Save(UserBase user, BayServiceSummary model);
        Task<ResponseEntity<JobCardResponse>> JobCardSave(UserBase user, BayServiceSummary model);
        Task<ResponseEntity> BayVsJobSave(UserBase user, BayServiceSummary model);
        Task<ResponseEntity> BayVsTechSave(UserBase user, BayServiceSummary model);
        Task<ResponseEntity> TechSave(UserBase user, BayServiceSummary model);
        Task<ResponseEntity> JobCompleteionSave(UserBase user, BayServiceSummary model);
        Task<ResponseEntity> GateOutSave(UserBase user, BayServiceSummary model);
    }
}
