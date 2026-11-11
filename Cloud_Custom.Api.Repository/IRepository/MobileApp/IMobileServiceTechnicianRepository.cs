using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
    public interface IMobileServiceTechnicianRepository
    {
        public Task<ResponseEntity> GetServiceTechnicianSave(UserBase user, MobileServiceTechnician model);
    }
}
