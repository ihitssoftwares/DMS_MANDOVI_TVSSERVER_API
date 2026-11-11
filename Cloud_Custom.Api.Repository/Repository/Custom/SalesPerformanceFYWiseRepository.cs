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
    public class SalesPerformanceFYWiseRepository : ISalesPerformanceFYWiseRepository
    {
        private readonly ISqlConnectionProvider _sql;


        public SalesPerformanceFYWiseRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;

        }
        public async Task<DataSet> Getlist(UserBase userBase, int FY,int Branch, string FYText)
        {
            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@COMPANYGI",userBase.CompanyGuid),
                new SqlParameter("@USERGI",userBase.UserGuid),
                new SqlParameter("@FINYEAR",FY),
                new SqlParameter("@Branch",Branch),
                new SqlParameter("@FYText",FYText),

            };
            var ds = await _sql.GetDataSetAsync("DMS.[SP_SALES_PERFORMANCE_FINANCIAL_WISE REPORT]", sqlparameters);
            return ds;
        }
    }
}

