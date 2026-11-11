using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Repository.IRepository.General;
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
    public class BayUtilizationReportRepository: IBayUtilizationReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;

        public BayUtilizationReportRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }



        public async Task<BayUtilizationReport> GetList(UserBase user,DateTime Date, int WorkShopCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@WorkShopCode",WorkShopCode),
                 new SqlParameter("@Date",Date),
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_UTILIZATION_REPORT]", sqlparameters);
                return BindDashboard(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private BayUtilizationReport BindDashboard(DataSet ds)
        {
            BayUtilizationReport model = new BayUtilizationReport();

            model.List = new List<BayUtilizationReport>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    model.List.Add(new BayUtilizationReport
                    {
                        BayCode = MakeSafe.ToSafeInt32(row["BayCode"]),
                        BayUserCode = MakeSafe.ToSafeString(row["BayUserCode"]),
                        BayName = MakeSafe.ToSafeString(row["BayName"]),
                        BayType = MakeSafe.ToSafeString(row["BayType"]),
                        AverageServiceTime = MakeSafe.ToSafeDecimal(row["AverageServiceTime"]),
                        TotalVehicles = MakeSafe.ToSafeInt32(row["TotalVehicles"]),
                        FirstVehicleIn = MakeSafe.ToSafeDateTime(row["FirstVehicleIn"]),
                        LastVehicleOut = MakeSafe.ToSafeDateTime(row["LastVehicleOut"]),
                        Technician = MakeSafe.ToSafeString(row["TechnicianName"]),
                    });
                }
            }

            return model;
        }
    }
}