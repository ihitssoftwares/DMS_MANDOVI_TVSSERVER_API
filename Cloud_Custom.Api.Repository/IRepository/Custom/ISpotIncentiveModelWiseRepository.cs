using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ISpotIncentiveModelWiseRepository
    {
        Task<ResponseEntity> SpotIncentiveModelWiseSave(UserBase user, SpotIncentiveModelWise model);
        Task<SpotIncentiveModelWise> GetList(UserBase user, Filter filter, int Month, int Model, int Ageing, string Status);
        Task<SpotIncentiveModelWise> GetDetails(UserBase user, int HdCode,string VIN);
    }
}
