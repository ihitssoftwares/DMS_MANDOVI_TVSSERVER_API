using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IInventoryDispatchUpdateRepository
    {
        public Task<ResponseEntity<List<SalesVehicleImport>>> ImportDispatchFromExcel(UserBase user, InventoryDispatchUpdate model);
        Task<InventoryDispatchUpdate> GetDispatchStockList(UserBase user, int BatchCode);
        Task<InventoryDispatchUpdate> GetSummaryDetails(UserBase user, int BatchCode);
        Task<ResponseEntity> Delete(UserBase user, int BatchCode);
    }
}
