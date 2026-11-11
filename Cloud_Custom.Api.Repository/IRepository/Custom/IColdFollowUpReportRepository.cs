using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IColdFollowUpReportRepository
    {
        Task<ColdFollowUpReport> GetList(UserBase user, Filter filter, string FromDate, string ToDate, int Region, int Branch, string Status);
        Task<ColdFollowUPItems> GetEmployeeDetails(UserBase user, int Trnno);
    }
}
