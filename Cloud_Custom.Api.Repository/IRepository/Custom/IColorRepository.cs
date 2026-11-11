using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IColorRepository
    {
        Task<Color> GetList(UserBase user, string TabIndex);
        Task<ResponseEntity> Save(UserBase user, string mode, Color model);
        public Task<Color> GetColorDetails(UserBase User, int ColorCode, string mode, string Type);

        public Task<ResponseEntity> DeleteColor(UserBase user, Color model);
    }
}
