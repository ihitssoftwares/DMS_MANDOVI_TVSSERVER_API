using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IMisModelWiseReportRepository
    {
        Task<MisModelWiseReport> GetList(UserBase user, int ReportType, int Branch, int Model, int SourceOfEnq, int Color, int Region,int Channel);
    }
}
