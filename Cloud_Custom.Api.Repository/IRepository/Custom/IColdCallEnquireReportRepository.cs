using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public   interface IColdCallEnquireReportRepository
    {
        Task<ColdCallEnquireReport> GetList(UserBase user, string FromDate, string ToDate,string Status);
    }
}
