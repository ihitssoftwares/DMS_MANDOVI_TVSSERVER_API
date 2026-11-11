using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
   public  interface IStoreOrBranchRepository
    {
        Task<StoreOrBranch> GetList(UserBase user,int Type,int Region , int Workshoponly);
        public Task<ResponseEntity> Save(UserBase user, string mode, StoreOrBranch input);
        public Task<StoreOrBranch> GetBranchDetails(UserBase User, int BranchCode, string mode);
        public Task<ResponseEntity> DeleteBranch(UserBase user, StoreOrBranch model);



        public Task<ResponseEntity> PopupSave(UserBase user, StoreOrBranch model);
        Task<StoreOrBranch> GetPopupList(UserBase user, int BranchCode);

        public Task<ResponseEntity> DeletePopup(UserBase user, int BranchCode, int DtCode);
    }
}

