using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IAccessoriesInvoiceDetailsUpdateRepository
    {
        Task<AccessoriesInvoiceDetailsUpdate> GetList(UserBase user,int MonthCode, int BranchCode);
        Task<AccessoriesInvoiceDetailsUpdate> GetDetails(UserBase user,int DtCode);
        Task<ResponseEntity> Save(UserBase user, AccessoriesInvoiceDetailsUpdate model);
    }
}
