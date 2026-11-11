using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface ICustomerRepository
    {
        Task<Customer> GetList(UserBase user, Filter filter);
        public Task<ResponseEntity> Save(UserBase user, string mode, Customer input);
        public Task<Customer> GetCustomerDetails(UserBase User, int CustomerCode, string mode);
        public Task<ResponseEntity> DeleteCustomer(UserBase user, Customer model);

        public Task<ResponseEntity<List<Customer>>> CustomerImportFromExcel(UserBase user, Customer model);
    }
}
