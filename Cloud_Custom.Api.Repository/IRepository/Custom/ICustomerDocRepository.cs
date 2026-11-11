using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface ICustomerDocRepository
    {
        Task<CustomerDoc> GetList(UserBase user);
        Task<CustomerDocItem> GetEmployeeDetails(UserBase user, int OrderNo);

        Task<ResponseEntity> Save(UserBase user, CustomerDoc model);
    }
}
