using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public  interface IPriceSettingsRepository
    {
        Task<PriceSettings> GetList(UserBase user, int Type,int Region);
        //Task<PriceSettings> GetPriceSettingsDetails(UserBase user, string mode, int Type);
        Task<ResponseEntity> Save(UserBase user, PriceSettings model, string mode);
        public Task<PriceSettings> GetVarientDetails(UserBase User, int PriceId, string mode);
    }
}
