using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IInvoiceGenerationForVechicleRepository
    {
        Task<InvoiceGenerationForVechicle> GetList(UserBase user,int Status);
        Task<CustomeAccitem> GetAccList(UserBase user, int OrderTrnCode);
        Task<InvoiceGenerationForVechicle> GetDetails(UserBase user, int OrderTrnCode);
        Task<ResponseEntity> Save(UserBase user, InvoiceGenerationForVechicle model);
    }
}
