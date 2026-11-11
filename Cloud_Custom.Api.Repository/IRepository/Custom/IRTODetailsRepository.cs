using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Shared.Custom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IRTODetailsRepository
    {
        Task<RTODetailsRegistration> GetList(UserBase user);
        Task<RTODetailsRegistration> GetRegistrationDetails(UserBase use, int RegistrationCode);
        Task<ResponseEntity> Save(UserBase user, RTODetailsRegistration model);

        Task<RTODetailsRegistration> GetRTODetails(UserBase use, int RegistrationCode);
    }
}
