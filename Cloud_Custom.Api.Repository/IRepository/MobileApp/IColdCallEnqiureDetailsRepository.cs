using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using Cloud_Custom.Api.Shared.MobileApp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
    public interface IColdCallEnqiureDetailsRepository
    {    
        Task<ResponseEntity> Save(UserBase user, ColdCallEnquireDetails model);
    }
}
