using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IVahanDumpUploadRepository
    {
        public Task<ResponseEntity<List<DumpUploadModel>>> OrderImportFromExcel(UserBase user, VahanDumpUpload model);
        Task<VahanDumpUpload> GetList(UserBase user, int Month);
    }
}
