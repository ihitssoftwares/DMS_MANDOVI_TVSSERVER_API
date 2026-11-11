using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ISpotIncentiveDateWiseRepository
    {
        Task<ResponseEntity> SpotIncentiveDateWiseSave(UserBase user, SpotIncentiveDateWise model);
        Task<SpotIncentiveDateWise> GetList(UserBase user, int Month,int Region);
        Task<SpotIncentiveDateWise> GetDetails(UserBase user, int HdCode);
    }
}
