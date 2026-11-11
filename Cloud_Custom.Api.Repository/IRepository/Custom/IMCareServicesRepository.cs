using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IMCareServicesRepository
    {
        Task<MCareServices> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, MCareServices model);
        public Task<MCareServices> GetMCareServicesDetails(UserBase User, int MCareServicesCode, string mode, string Type);
        public Task<ResponseEntity> DeleteMCareServices(UserBase user, MCareServices model);
    }
}
