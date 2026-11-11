using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IMCareServiceEntryRepository
    {
        Task<MCareServiceEntry> GetList(UserBase user);
        Task<PopUpDetails> GetPopupDetails(UserBase user, int RegEntryCode, int CustomerCode);
        Task<ResponseEntity> Save(UserBase user, MCareServiceEntry model);
        Task<PopUpDetails> ViewDetails(UserBase user, int ServiceCode,int RegCode);
    }
}
