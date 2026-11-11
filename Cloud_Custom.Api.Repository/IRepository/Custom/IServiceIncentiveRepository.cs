using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceIncentiveRepository
    {
        //public Task<DataSet> GetIncentiveList(UserBase userBase, int MonthCode, int IncentiveCode);
        Task<ServiceIncentive> GetIncentiveList(UserBase userBase, int MonthCode, int IncentiveCode);

        Task<ServiceIncentive> GetProcessList(UserBase userBase, int MonthCode, int Region, int Employeecode);
        Task<ServiceIncentive> GetExcelProcessList(UserBase userBase, int MonthCode, int Region, int Employeecode);
        Task<ServiceIncentive> GetExportToExcelList(UserBase userBase, int MonthCode, int Region);
    }
}
