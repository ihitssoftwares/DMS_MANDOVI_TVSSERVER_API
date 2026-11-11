using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using Cloud_Custom.Api.Shared.MobileApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
   public  interface IUserRoleDashboardRepository
    {
        Task<UserRoleDashboard> GetSecuritytotalactivityList(UserBase user,string Date,int WorkShopCode);
        Task<UserRoleDashboard> GetSecurityDeatilsList(UserBase user,string Date,int WorkShopCode);
        Task<UserRoleDashboard> GetSecurityHistoryDeatilsList(UserBase user,string Date,int WorkShopCode);
        Task<UserRoleDashboard> GetSecurityPendingList(UserBase user,string Date,int WorkShopCode);
        Task<UserRoleDashboard> GetSecurityVehicleInList(UserBase user,string Date,int WorkShopCode);
        public Task<ResponseEntity> GetSecurityVehicleOutSave(UserBase user, UserRoleDashboard model);
        public Task<ResponseEntity> GetVehichlePassSaveMobile(UserBase user, UserRoleDashboard model);
    }
}
