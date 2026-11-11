using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
     public interface IWorkshopFileReportRepository
    {
        Task<WorkshopFileReport> GetList(UserBase user, string Workshopcode, string FromDate, string ToDate);
        Task<WorkshopFileUpload> GetPopupList(UserBase user, int FileCode, string FromDate, string ToDate, string workShop);
    }
}
