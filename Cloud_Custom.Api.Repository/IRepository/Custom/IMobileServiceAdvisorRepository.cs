using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IMobileServiceAdvisorRepository
    {
        Task<MobileServiceAdvisor> GetList(UserBase user);
        Task<MobileServiceAdvisor> CardDetailsList(UserBase user,string Type);
        Task<MobileServiceAdvisor> BayList(UserBase user);
        Task<MobileServiceAdvisor> JobCardDetails(UserBase user, int JobCardEntryCode);
        Task<MobileServiceAdvisor> GetMCareDetails(UserBase user, int CustomerCode);
        public Task<ResponseEntity> UpdateJobCard(UserBase user, int JobCardPhotoEntryCode,string Type);
        Task<MobileServiceAdvisor> HistoryList(UserBase user,int ServiceAdvisorCode,DateTime PickedDate);
        Task<MobileServiceAdvisor> HistoryDetails(UserBase user,int JobCardEntryCode);
        Task<MobileServiceAdvisor> JobCardList(UserBase user);
        Task<MobileServiceAdvisor> GetBayDetails(UserBase user, int JobCardCode);
        Task<ResponseEntity> SaveBay(UserBase user, MobileServiceAdvisor model);
        Task<MobileServiceAdvisor> GetNotAssignedList(UserBase user);
        Task<MobileServiceAdvisor> GetCustomerDetails(UserBase user, int CustomerCode);
        public Task<ResponseEntity> PopupSave(UserBase user, MobileServiceAdvisor model, int empcode);
        public Task<ResponseEntity> Save(UserBase user, int JobCardPhotoEntryCode);
        public Task<ResponseEntity> SaveEntry(UserBase user, MobileServiceAdvisor model);
    }
}
