using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IVariantRepository
    {
        Task<Variant> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, Variant model);
        public Task<Variant> GetVarientDetails(UserBase User, int VariantCode, string mode, string Type);
        public Task<ResponseEntity> VariantDelete(UserBase User, Variant model);
    }
}
