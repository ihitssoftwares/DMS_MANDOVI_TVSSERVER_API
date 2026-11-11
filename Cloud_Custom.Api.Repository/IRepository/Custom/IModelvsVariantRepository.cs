using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IModelvsVariantRepository
    {
        public Task<ModelvsVariant> GetList(UserBase user, int Modeldr);
        Task<ModelvsVariant> GetPopUpDetails(UserBase user);
        Task<ResponseEntity> Save(UserBase user, ModelvsVariant model);
        Task<ModelvsVariant> Getdetails(UserBase user,int HDCode,int ColorCode);
        Task<ResponseEntity> Edit(UserBase user, ModelvsVariant model);
        public Task<ResponseEntity> Delete(UserBase User, ModelvsVariant model);

    }
}
