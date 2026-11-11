using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface ICustomerAccountRepository
    {
        Task<CustomerAccount> GetList(UserBase user);
        Task<CustomeAccitem> GetAccList(UserBase user,int OrderTrnCode);
        Task<CustomerAccount> GetDetails(UserBase user, int OrderTrnCode);
        Task<ResponseEntity> Save(UserBase user, CustomerAccount model);

    }
}
