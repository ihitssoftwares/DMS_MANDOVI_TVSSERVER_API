using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public interface IColdCallRepository
    {
        public Task<ResponseEntity<List<ColdCallImportModel>>> ImportFromExcel(UserBase user, COLDCALLFILEDOWNLOAD model);
        Task<COLDCALLFILEDOWNLOAD> GetList(UserBase user, int Month);
    }
}
