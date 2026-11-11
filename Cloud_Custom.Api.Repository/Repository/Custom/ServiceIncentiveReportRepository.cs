using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
     public class ServiceIncentiveReportRepository : IServiceIncentiveReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public ServiceIncentiveReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }

        public async Task<ServiceIncentiveReport> GetList(UserBase user, int Month, int Parameter, int Region)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 //new SqlParameter("@CompanyGI",user.CompanyGuid),
                 //new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@MonthCode",Month),
                 new SqlParameter("@incentiveGroup",Parameter),
                 new SqlParameter("@RegionCode",Region),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_INCENTIVE_REPORT]", sqlparameters);
                return PopulateServiceIncentiveReport(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private ServiceIncentiveReport PopulateServiceIncentiveReport(DataSet dataSet)
        {
            var model = new ServiceIncentiveReport();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                var table = dataSet.Tables[0];

                foreach (DataColumn col in table.Columns)
                {
                    model.Columns.Add(col.ColumnName);
                }

                foreach (DataRow row in table.Rows)
                {
                    var rowDict = new Dictionary<string, string>();
                    foreach (DataColumn col in table.Columns)
                    {
                        rowDict[col.ColumnName] = MakeSafe.ToSafeString(row[col]);
                    }
                    model.Rows.Add(rowDict);
                }
            }

            return model;
        }
    }
}
