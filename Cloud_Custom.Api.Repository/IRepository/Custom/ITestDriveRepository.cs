using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public  interface ITestDriveRepository
    {
        Task<TestDrive> GetList(UserBase user, String Type);
        Task<TestDrive> GetLead(UserBase user, String Customer);
        Task<ResponseEntity> Save(UserBase user, TestDrive model);
        Task<TestDriveDetails> GetEmployeeDetails(UserBase user, string LeadNo);
    }
}
