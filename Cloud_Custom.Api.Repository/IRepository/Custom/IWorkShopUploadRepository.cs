using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
 public    interface IWorkShopUploadRepository
    {
        Task<WorkShopUpload> GetList(UserBase user, string PickedDate);
        Task<WorkShopUpload> GetEntryDateList(UserBase user, string PickedDate);
        Task<WorkShopUpload> OrderList(UserBase user, int FileCode);

        public Task<ResponseEntity<List<WorkShopUpload>>> ImportFromExcel(UserBase user, WorkShopUpload model);

        Task<WorkShopUpload> GetListByParticular(UserBase user, int WorkshopCode, int ParticularCode, string Date);
        Task<WorkShopUpload> EntryListperPopularList(UserBase user, int WorkshopCode, int ParticularCode, string Date);
        Task<WorkShopUpload> GetWorkShopList(UserBase user, string ParticularName, string Date);
        Task<WorkShopUpload> GetEntryWiseWorKshopList(UserBase user, string ParticularName, string Date);
    }
}
