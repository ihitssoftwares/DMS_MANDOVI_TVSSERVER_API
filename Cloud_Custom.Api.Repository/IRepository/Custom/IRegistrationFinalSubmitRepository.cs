using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface IRegistrationFinalSubmitRepository
    {
        Task<Registration> GetList(UserBase user);
        Task<Registration> GetRegistrationDetails(UserBase use, int RegistrationCode);

        Task<ResponseEntity> Verify(UserBase user, int RegistrationCode, string Remarks, string Mode);
    }
}
