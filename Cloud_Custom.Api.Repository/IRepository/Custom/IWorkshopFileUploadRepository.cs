using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IWorkshopFileUploadRepository
    {
        Task<WorkshopFileUpload> GetList(UserBase user, string PickedDate);
        Task<WorkshopFileUpload> OrderList(UserBase user, int FileCode);
        public Task<ResponseEntity<List<WorkshopFileUpload>>> ImportFromExcel(UserBase user, WorkshopFileUpload model);
        Task<WorkshopFileUpload> GetListByParticular(UserBase user, int PaticularCode, string Date);
        Task<WorkshopFileUpload> SmartUpload(UserBase user, WorkshopFileUpload model);
        Task<WorkshopFileUpload> SmartUploadAutoFix(UserBase user, WorkshopFileUpload model);
        Task<UploadFolderResponse> UploadFolder(UserBase user, IFormFileCollection files, string monthUpload);
        Task<int> GetServerFileCount(UserBase user, WorkshopFileUpload model);
    }
}
