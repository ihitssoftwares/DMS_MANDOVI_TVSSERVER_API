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
    public class MCareExpiryReportRepository : IMCareExpiryReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MCareExpiryReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MCareExpiryReport> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid)
                 
            };
                var ds = await _sql.GetDataSetAsync("[MCARE].[MCARE_EXPIRY_REPORT]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MCareExpiryReport SummeryList(DataSet ds)
        {
            MCareExpiryReport model = new MCareExpiryReport();
            List<MCareExpiryReport> list = new List<MCareExpiryReport>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MCareExpiryReport();

                    item.RegistrationEntryCode = MakeSafe.ToSafeInt32(row["RegistrationEntryCode"]);
                    item.EntryNo = MakeSafe.ToSafeString(row["EntryNo"]);
                    item.RegistrationDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]);
                    item.PlanName = MakeSafe.ToSafeString(row["PlanName"]);
                    item.PackageDuration = MakeSafe.ToSafeString(row["PackageDuration"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.Phone = MakeSafe.ToSafeString(row["Phone"]);
                    item.VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.Colour = MakeSafe.ToSafeString(row["Colour"]);
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.PlanAmount = MakeSafe.ToSafeDecimal(row["PlanAmount"]);
                    item.StartDate = MakeSafe.ToSafeDateTime(row["StartDate"]);
                    item.EndDate = MakeSafe.ToSafeDateTime(row["EndDate"]);
                    item.RemainingDays = MakeSafe.ToSafeInt32(row["RemainingDays"]);

                    list.Add(item);
                }

                model.List = list;
            }

            return model;
        }
    }
}
