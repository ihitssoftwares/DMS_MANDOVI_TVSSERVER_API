using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IModelVsVariantUploadRepository
    {
        public Task<ResponseEntity<List<modelvsvariant>>> OrderImportFromExcel(UserBase user, ModelVsVariantUpload model);
        Task<ModelVsVariantUpload> GetList(UserBase user, int Month);
    }
}
