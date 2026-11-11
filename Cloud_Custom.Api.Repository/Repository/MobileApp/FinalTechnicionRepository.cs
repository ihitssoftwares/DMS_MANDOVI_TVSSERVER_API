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
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.MobileApp
{
    public  class FinalTechnicionRepository : IFinalTechnicionRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly ICommonRepository _common;
        public FinalTechnicionRepository(ISqlConnectionProvider sql, ICommonRepository common)
        {
            _sql = sql;
            _common = common;

        }
        public async Task<FinalTechnician> GetTechnicionTiles(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_TECHNICIAN_FINAL_TILES]", sqlparameters);
                return GetTechnicionTilesList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private FinalTechnician GetTechnicionTilesList(DataSet ds)
        {
            FinalTechnician model = new FinalTechnician();
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                DataRow row = ds.Tables[1].Rows[0];
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
                model.ElapsedMinutes = MakeSafe.ToSafeInt32(row["ElapsedMinutes"]);
                model.TimeElapsedPercentage = MakeSafe.ToSafeDecimal(row["TimeElapsedPercentage"]);
                model.RemainingHours = MakeSafe.ToSafeString(row["RemainingHours"]);
            }
            return model;
        }
        public async Task<FinalTechnician> GetJobInProgressList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_PENDING_JOBS_SERVICE_LIST]", sqlparameters);
                return GetJobInProgressListList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private FinalTechnician GetJobInProgressListList(DataSet ds)
        {
            FinalTechnician model = new FinalTechnician();

            List<FinalTechnician> GetList = new List<FinalTechnician>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new FinalTechnician();

                    item.Slno = MakeSafe.ToSafeInt32(row["Slno"]);
                    item.JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]);
                    item.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.Name = MakeSafe.ToSafeString(row["Name"]);
                    item.Phone = MakeSafe.ToSafeString(row["Phone"]);
                    item.JCDateTime = MakeSafe.ToSafeDateTime(row["JCDateTime"]);
                    item.CheckIn = MakeSafe.ToSafeDateTime(row["CheckIn"]);
                    item.VehicleRegistrationNumber = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.ModeName = MakeSafe.ToSafeString(row["ModeName"]);
                    item.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
                    item.Status = MakeSafe.ToSafeString(row["Status"]);
                    item.MCare = MakeSafe.ToSafeInt32(row["MCare"]);

                    GetList.Add(item);
                }

                model.List = GetList;
            }
            return model;
        }
        public async Task<FinalTechnician> MobileRegNoSearch(UserBase user,string REGNO)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@REGNO",REGNO),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_TECHNICIAN_REGNO_SEARCH]", sqlparameters);
                return GetTechnicianRegNoSearch(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private FinalTechnician GetTechnicianRegNoSearch(DataSet ds)
        {
            FinalTechnician model = new FinalTechnician();
            List<FinalTechnician> getList = new List<FinalTechnician>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    getList.Add(new FinalTechnician
                    {
                        VehicleRegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]),
                        CustomerCode=MakeSafe.ToSafeInt32(row["CustomerCode"]),
                        BayCode = MakeSafe.ToSafeInt32(row["BayCode"]),
                        TechnicianEmpCode = MakeSafe.ToSafeInt32(row["TechnicianEmpCode"]),
                        JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]),
                        JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]),
                        ModeName = MakeSafe.ToSafeString(row["Model"]),
                        VariantName = MakeSafe.ToSafeString(row["Variant"]),
                        EntryTime = MakeSafe.ToSafeDateTime(row["InTime"]),
                        Status = MakeSafe.ToSafeString(row["STATUSE"]),
                        MCare = MakeSafe.ToSafeInt32(row["MCare"])
                    });
                }
                model.List = getList;
            }
            return model;
        }
        public async Task<FinalTechnician> GetMCareDetails(UserBase user, int CustomerCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                
                 new SqlParameter("@CustomerCode",CustomerCode),

            };
                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_MCARE_CUSTOMER_SERVICE_DETAILS]", sqlparameters);
                    return GetMCareCustomerDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private FinalTechnician GetMCareCustomerDetails(DataSet ds)
        {
            FinalTechnician model = new FinalTechnician();
            List<FinalTechnician> getList = new List<FinalTechnician>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    getList.Add(new FinalTechnician
                    {
                        ServiceName = MakeSafe.ToSafeString(row["ServiceName"]),
                        AllowedLimit = MakeSafe.ToSafeInt32(row["AllowedLimit"]),
                        Availed = MakeSafe.ToSafeInt32(row["Availed"]),
                        Balance = MakeSafe.ToSafeInt32(row["Balance"]),
                       
                    });
                }
                model.List = getList;
            }
            return model;
        }
        public async Task<FinalTechnician> GetTechnicianHistory(UserBase user, string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGuid",  user.UserGuid),
            new SqlParameter("@Date",Date),
        };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_TECHNICIAN_HISTORY_LIST]", sqlparameters);
                return GetTechnicianHistory(ds);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private FinalTechnician GetTechnicianHistory(DataSet ds)
        {
            FinalTechnician model = new FinalTechnician();
            List<FinalTechnician> getList = new List<FinalTechnician>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    getList.Add(new FinalTechnician
                    {
                        JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]),
                        JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]),
                        VehicleRegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]),
                        BayCode = MakeSafe.ToSafeInt32(row["BayCode"]),
                        TechnicianEmpCode = MakeSafe.ToSafeInt32(row["TechnicianEmpCode"]),
                        EntryTime = MakeSafe.ToSafeDateTime(row["InTime"]),
                        ExistTime = MakeSafe.ToSafeDateTime(row["OutTime"]),
                        Status = MakeSafe.ToSafeString(row["Status"]),
                        DurationMinutes = MakeSafe.ToSafeInt32(row["DurationMinutes"]),
                        ModeName = MakeSafe.ToSafeString(row["Model"]),
                        VariantName = MakeSafe.ToSafeString(row["Variant"])
                    });
                }
                model.List = getList;
            }
            return model;
        }
        public async Task<FinalTechnician> GetTechnicianRecentList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                {
            new SqlParameter("@CompanyGI", user.CompanyGuid),
            new SqlParameter("@UserGuid",  user.UserGuid),
        };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_TECHNICIAN_RECENT_LIST]", sqlparameters);
                return GetTechnicianRecentList(ds);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private FinalTechnician GetTechnicianRecentList(DataSet ds)
        {
            FinalTechnician model = new FinalTechnician();
            List<FinalTechnician> getList = new List<FinalTechnician>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    getList.Add(new FinalTechnician
                    {
                        JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]),
                        JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]),
                        VehicleRegistrationNumber = MakeSafe.ToSafeString(row["RegistrationNumber"]),
                        BayCode = MakeSafe.ToSafeInt32(row["BayCode"]),
                        TechnicianEmpCode = MakeSafe.ToSafeInt32(row["TechnicianEmpCode"]),
                        EntryTime = MakeSafe.ToSafeDateTime(row["InTime"]),
                        ExistTime = MakeSafe.ToSafeDateTime(row["OutTime"]),
                        Status = MakeSafe.ToSafeString(row["Status"]),
                        DurationMinutes = MakeSafe.ToSafeInt32(row["DurationMinutes"]),
                        ModeName = MakeSafe.ToSafeString(row["Model"]),
                        VariantName = MakeSafe.ToSafeString(row["Variant"])
                    });
                }
                model.List = getList;
            }
            return model;
        }
        public async Task<ResponseEntity> GetServiceTechnicianSave(UserBase user, FinalTechnician model, string Mode)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                         new SqlParameter("@Mode",Mode),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_TECHNICIAN_INOUT_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
    }
}
