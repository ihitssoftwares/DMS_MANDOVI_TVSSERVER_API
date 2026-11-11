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
    public class MCareRegistrationReportRepository : IMCareRegistrationReportRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MCareRegistrationReportRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MCareRegistrationReport> GetList(UserBase user, int PlanCode, string Status, int RegionCode, int BranchCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
         new SqlParameter("@CompanyGI",user.CompanyGuid),
         new SqlParameter("@UserGuid",user.UserGuid),
            new SqlParameter("@PlanCode",PlanCode),
             new SqlParameter("@Status",Status),
             new SqlParameter("@RegionCode",RegionCode),
             new SqlParameter("@BranchCode",BranchCode)
    };
                var ds = await _sql.GetDataSetAsync("[MCARE].[MCARE_REGISTRATION_REPORT]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MCareRegistrationReport SummeryList(DataSet ds)
        {
            MCareRegistrationReport model = new MCareRegistrationReport();
            List<MCareRegistrationReport> list = new List<MCareRegistrationReport>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MCareRegistrationReport();
                    item.RegistrationEntryCode = MakeSafe.ToSafeGuid(row["RegistrationEntryCode"]);
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
                    item.Status = MakeSafe.ToSafeString(row["Status"]);
                    item.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
                    item.RegionName = MakeSafe.ToSafeString(row["RegionName"]);
                    list.Add(item);
                }
                model.List = list;
            }
            return model;
        }
    }
}
