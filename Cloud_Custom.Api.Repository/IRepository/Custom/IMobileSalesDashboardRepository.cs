using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.MobileApp
{
    public interface IMobileSalesDashboardRepository
    {
        Task<MobileSalesDashboard> GetList(UserBase user,int UserCode);
        Task<MobileSalesDashboard> GetDetails(UserBase user, int UserCode,string Type);
        Task<MobileSalesDashboard> GetTargetAchievement(UserBase user, int UserCode, int MonthCode);
        Task<MobileSalesDashboard> GetDetailsTL(UserBase user, int UserCode, string Type);
    }
}
