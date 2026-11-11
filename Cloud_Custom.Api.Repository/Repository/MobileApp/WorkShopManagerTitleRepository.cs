using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.General;
using Cloud_Custom.Api.Repository.IRepository.MobileApp;
using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.MobileApp
{
    public class WorkShopManagerTitleRepository : IWorkShopManagerTitleRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;

        public WorkShopManagerTitleRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }



        public async Task<WorkShopManagerTitle> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_DASHBOARD_WORKSHOP_MANAGER_TILE_DATA]", sqlparameters);
                return BindDashboard(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkShopManagerTitle BindDashboard(DataSet dataSet)
        {
            WorkShopManagerTitle model = new WorkShopManagerTitle();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = dataSet.Tables[0].Rows[0];

                model.Active = MakeSafe.ToSafeInt32(row["Active"]);

                model.Open = MakeSafe.ToSafeInt32(row["Open"]);

                model.Hold = MakeSafe.ToSafeInt32(row["Hold"]);

                model.Completed = MakeSafe.ToSafeInt32(row["Completed"]);
            }

            return model;
        }
    }
}
