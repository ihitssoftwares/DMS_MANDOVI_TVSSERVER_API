using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceTargetvsAchivementRepository
    {

        Task<ServiceTargetvsAchivement> GetList(UserBase user, int Month, int IncentiveGroup, int Region, int Parameter);

        public Task<DataSet> GetDetails(UserBase userBase, int months, int IncentiveGroups, int Region, int Parameters, int empCode);

    }
}
