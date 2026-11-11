using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface IServiceIncentiveProccesingReportRepository
    {
       
        Task<ServiceIncentiveProccesingReport> GetIncentiveList(UserBase userBase, int MonthCode, int RegionCode,int BranchCode,int EmpCode );
        Task<DataSet> GetPopupList(UserBase userBase, int MonthCode, int Region, int branchCode, int EmpCode, int ParaCode, int InceCode);
        Task<ServiceIncentiveProccesingReport> GetExcelProcessList(UserBase userBase, int MonthCode, int Region,int BranchCode,string Type, int Employeecode);
    }
}
