using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Custom
{
   public  interface ITechnicianEfficiencyRepository
    {
        public Task<DataSet> GetTechnicanlist(UserBase userBase, string date, int workshop);
    }
}
