using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface ITLvsSTRepository
    {
        Task<TLvsST> GetList(UserBase user, string data);
        public Task<ResponseEntity> Save(UserBase user, string mode, TLvsST input);
        public Task<TLvsST> GetTLvsSTDetails(UserBase User, int TrnCode, string mode);
        public Task<ResponseEntity> DeleteTLvsST(UserBase user, TLvsST model);
    }
}
