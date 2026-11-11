using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IServiceFileUploadReconcilationReportRepository
    {

        Task<ServiceFileUploadReconcilationReport> GetList(UserBase user, int Month,int Region);

        Task<ServiceFileUploadReconcilationReport> GetPopUp(UserBase user, string date);

        Task<ServiceFileUploadReconcilationReport> GetPopUp1(UserBase user, string date);

        Task<ServiceFileUploadReconcilationReport> GetPopUp2(UserBase user, string date);


    }
}
