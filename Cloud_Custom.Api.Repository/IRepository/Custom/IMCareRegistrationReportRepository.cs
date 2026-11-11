using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IMCareRegistrationReportRepository
    {
        Task<MCareRegistrationReport> GetList(UserBase user, int PlanCode, string Status, int RegionCode, int BranchCode);
    }
}
