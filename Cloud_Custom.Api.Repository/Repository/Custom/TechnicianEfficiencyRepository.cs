using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
   public  class TechnicianEfficiencyRepository : ITechnicianEfficiencyRepository
    {
        private readonly ISqlConnectionProvider _sql;


        public TechnicianEfficiencyRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;

        }
        public async Task<DataSet> GetTechnicanlist(UserBase userBase, string date, int workshop)
        {
            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",userBase.CompanyGuid),
                new SqlParameter("@UserGI",userBase.UserGuid),
                new SqlParameter("@Date",date),
                new SqlParameter("@WorkShopCode",workshop),

            };
            var ds = await _sql.GetDataSetAsync("DMS.[SP_TECHNICIAN_EFFICIENCY_LIST]", sqlparameters);
            return ds;
        }
    }
}
