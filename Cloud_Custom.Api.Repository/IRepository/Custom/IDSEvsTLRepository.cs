using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public  interface IDSEvsTLRepository
    {
        Task<DSEvsTL> GetList(UserBase user, string Code, string branch, string TabIndex);
        public Task<ResponseEntity> Save(UserBase user, string mode, DSEvsTL input);
        public Task<DSEvsTL> GetDSEvsTLDetails(UserBase User, int TrnCode, string mode,int EmpCode);
        public Task<ResponseEntity> DeleteDSEvsTL(UserBase user, DSEvsTL model);
        Task<DSEvsTL> GetUpdatedDetails(UserBase user, int Trnno);
    }
}
