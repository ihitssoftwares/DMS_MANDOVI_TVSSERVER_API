using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IMcarePerEmployeeRepositroy
    {
        Task<McarePerEmployee> GetList(UserBase user, string FromDate, string ToDate, int DivisionCode, int RegionCode, int BranchCode, int EmployeeCode, int Year);
        Task<McarePerEmployee> GetEmployeeDetail(UserBase user, int EmployeeCode);

    }
}
