using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public   interface IBookingndInventoryLiveStatusRepository
    {
        Task<BookingndInventoryLiveStatus> GetList(UserBase user,int Type,int ModelCode,int RegionCode,int BranchCode);
        Task<DataSet> GetDetails(UserBase user, string Type, int ModelCode, int Variant, int Color,int Region,int Branch,int GroupBy);
    }
}
