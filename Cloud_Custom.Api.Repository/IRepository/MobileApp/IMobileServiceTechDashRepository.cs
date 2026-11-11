using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
    public interface IMobileServiceTechDashRepository
    {
        Task<MobileServiceTechDash> GetList(UserBase user);
    }
}
