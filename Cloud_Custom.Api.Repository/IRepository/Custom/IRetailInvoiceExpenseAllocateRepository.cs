using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IRetailInvoiceExpenseAllocateRepository
    {
        Task<RetailInvoiceExpenseAllocate> GetList(UserBase user, int Month, string Status, string Branch);
        //Task<RetailInvoiceExpenseAllocate> GetExportToExcel(UserBase user, int Month, string Status, string Branch);

        Task<RetailInvoiceExpenseAllocate> GetPopupDetails(UserBase user, int SalesTrnCode);
        Task<ResponseEntity> Save(UserBase user, RetailInvoiceExpenseAllocate model);
    }
}
