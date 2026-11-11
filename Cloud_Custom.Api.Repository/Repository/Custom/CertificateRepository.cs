using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.Custom;
using Cloud_Custom.Api.Shared.Custom;
using Cloud_Custom.Api.Shared.General;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.Custom
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public CertificateRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<Certificate> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                   
            };
                var ds = await _sql.GetDataSetAsync("[MCARE].[MCARE_CERTIFICATE_PRINT]", sqlparameters);
                return SummeryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Certificate SummeryList(DataSet ds)
        {
            Certificate model = new Certificate();
            List<Certificate> List = new List<Certificate>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new Certificate();



                    item.RegEntryCode = MakeSafe.ToSafeInt32(row["RegistrationEntryCode"]);
                    item.EntryNo = MakeSafe.ToSafeString(row["EntryNo"]);
                    item.RegDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]);
                    item.PlaneName = MakeSafe.ToSafeString(row["PlanName"]);
                    item.PackageDuration = MakeSafe.ToSafeString(row["PackageDuration"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                   
                    item.Phone = MakeSafe.ToSafeString(row["Phone"]);
                    item.VehicleRegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.Model = MakeSafe.ToSafeString(row["Model"]);
                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);
                    item.Color = MakeSafe.ToSafeString(row["Colour"]);
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.PlaneAmount = MakeSafe.ToSafeInt32(row["PlanAmount"]);
                    item.StartDate = MakeSafe.ToSafeDateTime(row["StartDate"]);
                    item.EndDate = MakeSafe.ToSafeDateTime(row["EndDate"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);

                    List.Add(item);
                }
                model.List = List;
            }

            return model;

        }

        public async Task<Certificate> GetCertificateDetails(UserBase user, int RegEntryCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                
                new SqlParameter("@RegistrationEntryCode",RegEntryCode),
               

            };
            var ds = await _sql.GetDataSetAsync("[MCARE].[MCARE_CERTIFICATE_PRINT_DETAILS]", sqlparameters);

            return PopulateCertificateDetails(ds);

        }


        public Certificate PopulateCertificateDetails(DataSet ds)
        {
            Certificate model = new Certificate();
            List<Certificate> list = new List<Certificate>();


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                model.RegistrationEntryGI = MakeSafe.ToSafeString(row["RegistrationEntryGI"]);
                model.RegEntryCode = MakeSafe.ToSafeInt32(row["RegistrationEntryCode"]);
                model.EntryNo = MakeSafe.ToSafeString(row["EntryNo"]);
                model.RegDate = MakeSafe.ToSafeDateTime(row["RegistrationDate"]);
                model.PlaneName = MakeSafe.ToSafeString(row["PlanName"]);
                model.PackageDuration = MakeSafe.ToSafeString(row["PackageDuration"]);
                model.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                model.City = MakeSafe.ToSafeString(row["City"]);
                model.Address = MakeSafe.ToSafeString(row["Address"]);
                model.Phone = MakeSafe.ToSafeString(row["Phone"]);

                model.VehicleRegNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                model.Model = MakeSafe.ToSafeString(row["Model"]);
                model.Variant = MakeSafe.ToSafeString(row["Variant"]);
                model.Color = MakeSafe.ToSafeString(row["Colour"]);
                model.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                model.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                model.PlaneAmount = MakeSafe.ToSafeInt32(row["PlanAmount"]);
                model.StartDate = MakeSafe.ToSafeDateTime(row["StartDate"]);
                model.EndDate = MakeSafe.ToSafeDateTime(row["EndDate"]);

                model.Status = MakeSafe.ToSafeString(row["Status"]);
                model.BranchName = MakeSafe.ToSafeString(row["BranchName"]);
            }
            // Table 0: SlabFrom, SlabTo, Incentive, CalculationTypeCode
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new Certificate();
                    

                    item.Service = MakeSafe.ToSafeString(row["Service"]);
                    item.Limit = MakeSafe.ToSafeInt32(row["Limit"]);
                    item.Percentage = MakeSafe.ToSafeInt32(row["Percentage"]);

                    list.Add(item);
                }
                model.List = list;
            }

            // Table 1: BranchCode, HdCode, IncentiveGroupCode, ParameterCode, BranchName, MonthName, IncentiveGroupName, ParameterName
            if ((ds.Tables[2]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[2].Rows[0];
               model.Description = MakeSafe.ToSafeString(row["Description"]);
            }

            return model;
        }
        public async Task<JObject> CertificateJSON(string RegGi, int RegCode)
        {
            IDbDataParameter[] sqlparameters =
        {
                 new SqlParameter("@RegGi",RegGi),
                new SqlParameter("@RegCode",RegCode),
             

            };

            var ds = await _sql.ExecuteJsonAsync("[MCARE].[SP_GET_MCARE_INVOICE]", sqlparameters);
            return ds;
            //return PopulatePaySlip(ds);

        }

    }
}
