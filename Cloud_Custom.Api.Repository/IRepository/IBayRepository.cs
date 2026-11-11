using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IBayRepository
    {
        Task<Bay> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, Bay model);
        public Task<Bay> GetDealershipDetails(UserBase User, int DealerCode, string mode, string Type);
        public Task<ResponseEntity> DearlerDelete(UserBase User, Bay model);
    }
}
