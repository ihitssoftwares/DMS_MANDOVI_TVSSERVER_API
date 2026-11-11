using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface IDSEEnquiryReportRepository
    {
        public Task<DataSet> GetList(UserBase userBase, string From, string To, string Type, string RegionCode, string BranchCode);
    }
}
