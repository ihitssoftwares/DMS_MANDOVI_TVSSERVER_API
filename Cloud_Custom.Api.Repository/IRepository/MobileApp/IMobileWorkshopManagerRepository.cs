using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
    public  interface IMobileWorkshopManagerRepository
    {

        Task<MobileWorkshopManager> GetList(UserBase user);
        Task<MobileWorkshopManager> CardDetailsList(UserBase user, string Type);
        Task<MobileWorkshopManager> BayList(UserBase user);
        Task<MobileWorkshopManager> JobCardDetails(UserBase user, int JobCardEntryCode);
        public Task<ResponseEntity> UpdateJobCard(UserBase user, int JobCardPhotoEntryCode, string Type);
        Task<MobileWorkshopManager> HistoryList(UserBase user, int ServiceAdvisorCode, DateTime PickedDate);
        Task<MobileWorkshopManager> HistoryDetails(UserBase user, int JobCardEntryCode);
        Task<MobileWorkshopManager> JobCardList(UserBase user);
        Task<MobileWorkshopManager> GetBayDetails(UserBase user, int JobCardCode);
        Task<ResponseEntity> SaveBay(UserBase user, MobileWorkshopManager model);
        Task<MobileWorkshopManager> GetNotAssignedList(UserBase user);
        Task<MobileWorkshopManager> GetCustomerDetails(UserBase user, int CustomerCode);
        public Task<ResponseEntity> PopupSave(UserBase user, MobileWorkshopManager model, int empcode);
        public Task<ResponseEntity> Save(UserBase user, int JobCardPhotoEntryCode);
        public Task<ResponseEntity> SaveEntry(UserBase user, MobileWorkshopManager model);
    }
}
