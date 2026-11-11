using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public   interface IMisSalesDashboardRepository 
    {
        Task<MisSalesDashboard> GetTabDetails(UserBase user, int Month, string Fromdate, string ToDate, int Type, string Grid,int Region, int PageNo = 1, int PageSize = 10);

        Task<MisSalesDashboard> GetList(UserBase user, int Month, string Fromdate, string ToDate, int Type, string Grid,int Region);
        Task<MisSalesDashboard> GetInventoryList(UserBase user, int Month, string Fromdate, string ToDate, int Type, string Grid,int Region, int PageNo = 1, int PageSize = 10);
        Task<DataSet> GetRetailTabDetails(UserBase user, int Month, string Fromdate, string ToDate, int Region,int Type);
        Task<DataSet> GetInventoryTabDetails(UserBase user, int Month, string Fromdate, string ToDate, int Region,int Type);
        Task<DataSet> GetInventoryBookingDetails(UserBase user, int Model, int Variant, int Color, int Region);

    }
}
