using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceRepository
    {
        Task<Services> GetBatteryList(UserBase user, int Month, int Type);

        Task<Services> GetCCpList(UserBase user, int Month, int Type);

        Task<Services> GetEWList(UserBase user, int Month, int Type);

        Task<Services> GetLabourList(UserBase user, int Month, int Type);

        Task<Services> GetLoadList(UserBase user, int Month, int Type);

        Task<Services> GetMCPList(UserBase user, int Month, int Type);

        Task<Services> GetMGAList(UserBase user, int Month, int Type);

        Task<Services> GetPMS20List(UserBase user, int Month, int Type);

        Task<Services> GetPMSPartsList(UserBase user, int Month, int Type);

        Task<Services> GetSparesList(UserBase user, int Month, int Type);

        Task<Services> GetSyntheticOilList(UserBase user, int Month, int Type);

        Task<Services> GetTrueValueList(UserBase user, int Month, int Type);

        Task<Services> GetTyreList(UserBase user, int Month, int Type);
        
        Task<Services> GetLoadPopDetails(UserBase user, Filter filter, string Tab, string Name, int Code, int TypeCode, int Month);
        Task<Services> GetLabourPopDetails(UserBase user, Filter filter, string Tab, string Name, int Code, int TypeCode, int Month);
        Task<Services> GetMGAPopDetails(UserBase user, Filter filter, string Tab, string Name, int Code, int TypeCode, int Month);
    }
}
