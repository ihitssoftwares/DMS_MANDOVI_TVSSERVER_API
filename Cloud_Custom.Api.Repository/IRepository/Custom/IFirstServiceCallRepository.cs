using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public  interface IFirstServiceCallRepository
    {
        Task<FirstServiceCall> GetList(UserBase user,int ServiceCode);
        public Task<FirstServiceCall> GetDetails(UserBase User, int RegistrationCode, int OrdertrnCode);
        Task<ResponseEntity> Save(UserBase user, FirstServiceCall model);
    }
}
