using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface IRegionRepository
    {
        Task<Region> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, Region model);
        public Task<Region> GetDetails(UserBase User, int RegionCode, string mode, string Type);
        public Task<ResponseEntity> Delete(UserBase User, Region model);
    }
}
