using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IMcareRegistrationRepository
    {
        Task<McareRegistration> GetList(UserBase user, int AppoinmentStatus);
        Task<McareRegistration> GetSearchList(UserBase user, string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo, string VinNo);

        Task<McareRegistration> GetSearchDetails(UserBase user, string SearchCustomerName, string SearchCustomerRegisterNo, string SearchPhoneNo, string VinNo);
        Task<McareRegistration> GetDetails(UserBase user, string SearchCustomerRegisterNo);

        public Task<ResponseEntity> Save(UserBase User, McareRegistration model);

        public Task<McareRegistration> GetPlanAmount(UserBase User, int id, int VechicleModel, string FromDate);
    }
}
