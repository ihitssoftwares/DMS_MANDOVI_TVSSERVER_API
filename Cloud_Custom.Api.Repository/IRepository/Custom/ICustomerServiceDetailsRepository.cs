using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface ICustomerServiceDetailsRepository
    {
        Task<CustomerServiceDetails> GetList(UserBase user);
        public Task<ResponseEntity> Save(UserBase user, string mode, CustomerServiceDetails input);
        public Task<CustomerServiceDetails> GetCustomerDetails(UserBase User, int CustomerCode );
        public Task<ResponseEntity> Delete(UserBase user, CustomerServiceDetails model);
    }
}
