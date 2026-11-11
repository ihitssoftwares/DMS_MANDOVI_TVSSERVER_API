using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface ISeviceAchivementvsTargetRepository
    {

        Task<SeviceAchivementvsTarget> GetList(UserBase user, int Region, int MonthCode, int ParameterCode);

        Task<SeviceAchivementvsTarget> GetDetails(UserBase user, int parameterCode, int IncentiveGroupCode, int RegionCode, int BranchCode, int MonthCode);


        Task<SeviceAchivementvsTarget> GetDrillDownDetails(UserBase user, int MonthCode, int parameterCode, int EmployeeCode);

    }
}
