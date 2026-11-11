using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface IRegistrationRepository
    {
        Task<Registration> GetList(UserBase user);
        Task<Registration> GetOrderDetails(UserBase use, int OrderTrnCode);
        Task<ResponseEntity> Save(UserBase user, Registration model);
    }
}
