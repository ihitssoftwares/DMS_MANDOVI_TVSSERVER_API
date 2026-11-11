using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IProfitMarginRepository
    {
        Task<ProfitMargin> GetList(UserBase user,int VechicleModel);

        Task<ProfitMargin> GetTabList(UserBase user, string TabIndex);

        public Task<ResponseEntity> SettingsSave(UserBase User, ProfitMargin model, int VechicleModel);

        public Task<ResponseEntity> Save(UserBase User, ProfitMargin model, string TabIndex);
    }
}
