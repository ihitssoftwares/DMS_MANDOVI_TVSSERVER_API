using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
  public   interface ISalesPerformanceFYWiseRepository
    {
        public Task<DataSet> Getlist(UserBase userBase, int FY,int Branch, string FYText);
    }
}
