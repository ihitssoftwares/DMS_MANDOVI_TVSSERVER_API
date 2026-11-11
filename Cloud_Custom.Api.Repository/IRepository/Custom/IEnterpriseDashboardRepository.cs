using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IEnterpriseDashboardRepository
    {
        Task<EnterpriseDashboard> GetReportList(UserBase user,int BranchCode);
        Task<EnterpriseDashboard> GetList(UserBase user,int WorkShopCode);
        Task<EnterpriseDashboard> GetStatusList(UserBase user,int WorkShopCode,string Status);
    }
}
