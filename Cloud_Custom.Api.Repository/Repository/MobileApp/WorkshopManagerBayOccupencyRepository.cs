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
    public class WorkshopManagerBayOccupencyRepository : IWorkshopManagerBayOccupencyRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;

        public WorkshopManagerBayOccupencyRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }



        public async Task<WorkshopManagerBayOccupency> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_DASHBOARD_WORKSHOP_MANAGER_BAY_OCUPANCY]", sqlparameters);
                return BindDashboard(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private WorkshopManagerBayOccupency BindDashboard(DataSet dataSet)
        {
            WorkshopManagerBayOccupency model = new WorkshopManagerBayOccupency();

            model.List = new List<WorkshopManagerBayOccupency>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    WorkshopManagerBayOccupency item = new WorkshopManagerBayOccupency
                    {
                        BayUserCode = MakeSafe.ToSafeString(row["BayUserCode"]),

                        BayStatus = MakeSafe.ToSafeString(row["BayStatus"]),

                        JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]),

                        VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]),

                        EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]),

                        UnitPending = MakeSafe.ToSafeInt32(row["UnitPending"])
                    };

                    model.List.Add(item);
                }
            }

            return model;
        }
    }
}
