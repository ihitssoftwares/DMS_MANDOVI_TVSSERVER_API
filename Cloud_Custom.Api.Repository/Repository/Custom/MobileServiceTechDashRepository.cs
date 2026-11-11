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
    public class MobileServiceTechDashRepository : IMobileServiceTechDashRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;

        public MobileServiceTechDashRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }



        public async Task<MobileServiceTechDash> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_TECHNICIAN_EMP_DASH_LIST]", sqlparameters);
                return BindDashboard(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileServiceTechDash BindDashboard(DataSet dataSet)
        {
            MobileServiceTechDash model = new MobileServiceTechDash();

            //
            // TABLE 0 = Vehicle List
            //
            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileTechnicianVehicleModel> vehicleList = new List<MobileTechnicianVehicleModel>();

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    MobileTechnicianVehicleModel item =new MobileTechnicianVehicleModel();

                    item.RegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]);

                    item.TechnicianEmpCode = MakeSafe.ToSafeInt32(row["TechnicianEmpCode"]);
                    item.JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);

                    item.ModelCode = MakeSafe.ToSafeInt32(row["MODELCODE"]);

                    item.Model = MakeSafe.ToSafeString(row["Model"]);

                    item.Variant = MakeSafe.ToSafeString(row["Variant"]);

                    item.InTime = MakeSafe.ToSafeDateTime(row["INTIME"]);

                    item.Statuse =  MakeSafe.ToSafeString(row["STATUSE"]);

                    vehicleList.Add(item);
                }

                model.VehicleList = vehicleList;
            }

            //
            // TABLE 1 = Work Summary
            //
            if ((dataSet.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = dataSet.Tables[1].Rows[0];

                model.TechnicianEmpCode = MakeSafe.ToSafeInt32(row["TechnicianEmpCode"]);

                model.EmployeeName = MakeSafe.ToSafeString(row["EmployeeName"]);

                model.WorkedMinutes = MakeSafe.ToSafeInt32(row["WorkedMinutes"]);

                model.WorkedHours = MakeSafe.ToSafeString(row["WorkedHours"]);

                model.BranchWorkingHours = MakeSafe.ToSafeString(row["BranchWorkingHours"]);

                model.WorkDonePercentage = MakeSafe.ToSafeDecimal(row["WorkDonePercentage"]);
                model.BayUserCode = MakeSafe.ToSafeString(row["BayUserCode"]);
                model.BayName = MakeSafe.ToSafeString(row["BayName"]);
                model.EntryTime = MakeSafe.ToSafeDateTime(row["EntryTime"]);
                model.JobsAssigned = MakeSafe.ToSafeString(row["JobsAssigned"]);
                model.JobsCompleted = MakeSafe.ToSafeString(row["JobsCompleted"]);
                
                    
                    
                    
            }

            return model;
        }
    }
}
