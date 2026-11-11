using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public interface IIncentiveSummaryRepository
    {

        Task<IncentiveSummary> GetList(UserBase user, int Month, int Delearship, int Designation, int Branch);
        Task<IncentiveSummary> GetEmployeeDetails(UserBase user, int Month, int Delearship, int Designation,int EmployeeCode);

        Task<DataSet> SummaryExcel(UserBase user, int Month, int Delearship, int Designation,int Branch);
    }
}
