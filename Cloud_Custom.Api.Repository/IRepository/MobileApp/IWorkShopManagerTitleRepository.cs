using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
    public interface IWorkShopManagerTitleRepository
    {
        Task<WorkShopManagerTitle> GetList(UserBase user);
    }
}
