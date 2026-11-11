using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public   interface IAllotmentRepository
    {
        Task<Allotment> GetList(UserBase user,int Model,int Variant,string Status);
        Task<AllotmentItem> GetDetails(UserBase user, int OrderTrnCode);
        Task<AllotmentItem> GetInvoice(UserBase user, int Model, int Variant);
        Task<ResponseEntity> Save(UserBase user, Allotment model);

    }
}
