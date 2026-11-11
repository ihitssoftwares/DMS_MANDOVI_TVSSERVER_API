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
   public  class DSEEnquiryReportRepository : IDSEEnquiryReportRepository
    {
        private readonly ISqlConnectionProvider _sql;


        public DSEEnquiryReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;

        }
        public async Task<DataSet> GetList(UserBase userBase, string From, string To, string Type, string RegionCode, string BranchCode)
        {
            IDbDataParameter[] sqlparameters =
           {
              
                new SqlParameter("@MonthFrom",From),
                new SqlParameter("@MonthTo",To),
                new SqlParameter("@Type",Type),
                new SqlParameter("@BranchCode",BranchCode),
                new SqlParameter("@RegionCode",RegionCode),

            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_ENQUIRY_FOLLOW_UP_REPORT_DSE_WISE]", sqlparameters);
            return ds;
        }
    }
}
