using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
    public interface IOutLetWiseEnquiryReportRepository
    {

        Task<OutLetWiseEnquiryReport> GetList(UserBase user, int MonthCode, int ModelCode, int EnquiryCode, Filter filter);
        Task<OutLetWiseEnquiryReport> GetPopUpDetails(UserBase user, string ColType, string channel, string regionName, string branchCode, string monthCode, string modelCode, string enquiryCode, string Type);
    }
}
