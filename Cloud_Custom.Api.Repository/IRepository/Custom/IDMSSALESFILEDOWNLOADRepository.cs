using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public interface IDMSSALESFILEDOWNLOADRepository
    {
        public Task<ResponseEntity<List<VehicleSalesImportModel>>> ImportFromExcel(UserBase user, DMSSALESFILEDOWNLOAD model);
        Task<DMSSALESFILEDOWNLOAD> GetList(UserBase user, int Month, int Region, int Branch);
        Task<ResponseEntity> Delete(UserBase user, int BatchCode);
    }
}
