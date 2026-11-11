using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IFinanceUpdateRepository
    {
        Task<FinanceUpdate> GetList(UserBase user, int Month, string Status,string Branch);
        Task<FinanceUpdate> GetExportToExcel(UserBase user, int Month, string Status,string Branch);
        
        Task<FinanceUpdate> GetFinanceDetails(UserBase user, int SalesTrnCode);
        Task<ResponseEntity> Save(UserBase user, FinanceUpdate model);
    }
}
