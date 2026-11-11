using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom.Reports
{
 public interface ITestDriveApprovalReportRepository
    {
        Task<TestDriveApproval> GetList(UserBase user);
        Task<TestDriveApprovalDetails> GetEmployeeDetails(UserBase user, string LeadNo);
        Task<ResponseEntity> Save(UserBase user, TestDriveApprovalDetails model);
    }
}
