using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ISalesPerformanceReportRepository
    {
        Task<SalesPerformanceReport> GetList(UserBase user, int Month);
    }
}