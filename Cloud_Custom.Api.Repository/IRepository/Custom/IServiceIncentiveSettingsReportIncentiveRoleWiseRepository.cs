using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceIncentiveSettingsReportIncentiveRoleWiseRepository
    {

        Task<ServiceIncentiveSettingsReportIncentiveRoleWise> GetList(UserBase user, int Month, int IncentiveGroup, int Region,int BranchCode);

        Task<ServiceIncentiveSettingsReportIncentiveRoleWise> GetEmployeedata(UserBase user, int IncentiveGroup,  int Branch);


    }
}
