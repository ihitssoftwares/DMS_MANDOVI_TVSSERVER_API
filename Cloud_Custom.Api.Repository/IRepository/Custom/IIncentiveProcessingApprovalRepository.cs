using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IIncentiveProcessingApprovalRepository
    {
        Task<IncentiveProcessingApproval> GetList(UserBase user, int Month, int Delearship, int Designation, int Incentive);
        Task<ResponseEntity> EmployeeWiseUpdate(UserBase user, IncentiveProcessingApproval model);
        Task<IncentiveProcessingApproval> GetEmployeeDetails(UserBase user, int HDCode, int EmployeeCode);
    }
}
