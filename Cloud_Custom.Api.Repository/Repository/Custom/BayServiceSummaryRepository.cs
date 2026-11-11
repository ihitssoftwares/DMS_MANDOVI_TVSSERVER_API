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
    public class BayServiceSummaryRepository : IBayServiceSummaryRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public BayServiceSummaryRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<BayVsJob> LoadJobCardDetails(UserBase user, int jobCardNo)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),

                 new SqlParameter("@jobCardNo",jobCardNo)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_VS_JOB_DETAILS]", sqlparameters);
                return LoadJobCardDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private BayVsJob LoadJobCardDetails(DataSet dataSet)
        {
            BayVsJob model = new BayVsJob();
            List<BayVsJob> List = new List<BayVsJob>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new BayVsJob();

                
                    item.RegNo = MakeSafe.ToSafeString(row["RegNo"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                    
                    



                    List.Add(item);
                }
                model.BayVsJobList = List;
            }
            return model;

        }    
        
        public async Task<BayServiceSummary> GetBayDetailsList(UserBase user, int jcno)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),

                 new SqlParameter("@jcno",jcno)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_SERVICE_DETAILS]", sqlparameters);
                return GetBayDetailsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private BayServiceSummary GetBayDetailsList(DataSet dataSet)
        {
            BayServiceSummary model = new BayServiceSummary();
         
            List<BayServiceSummary> List = new List<BayServiceSummary>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new BayServiceSummary();

                    item.BayCode = MakeSafe.ToSafeInt32(row["Code"]);
                    item.BayName = MakeSafe.ToSafeString(row["Name"]);
                    item.Technician = MakeSafe.ToSafeString(row["Technician"]);
                    item.intime = MakeSafe.ToSafeString(row["Intime"]);
                    item.outtime = MakeSafe.ToSafeString(row["OutTime"]);
                    



                    List.Add(item);
                }
                model.BaydetailsList = List;
            }
            return model;

        }
         public async Task<GateIn> GetGateINList(UserBase user, int WorkshopCode,string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),

                 new SqlParameter("@WorkshopCode",WorkshopCode),
                 new SqlParameter("@Date",Date)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_GATE_IN_LIST]", sqlparameters);
                return GetGateINList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private GateIn GetGateINList(DataSet dataSet)
        {
            GateIn model = new GateIn();
            List<GateIn> List = new List<GateIn>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new GateIn();

                    item.RegNo = MakeSafe.ToSafeString(row["Regno"]);
                    item.Intime = MakeSafe.ToSafeString(row["Intime"]);
                    



                    List.Add(item);
                }
                model.GateInList = List;
            }
            return model;

        }

        public async Task<JobCard> GetjobCardList(UserBase user, int WorkshopCode, string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),

                 new SqlParameter("@WorkshopCode",WorkshopCode),
                 new SqlParameter("@Date",Date)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_SERVICE_JOB_CARD_LIST]", sqlparameters);
                return GetjobCardList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private JobCard GetjobCardList(DataSet dataSet)
        {
            JobCard model = new JobCard();
            List<JobCard> List = new List<JobCard>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    
                    var item = new JobCard();

                   
                    item.RegistrationNumber = MakeSafe.ToSafeString(row["RegNo"]);
                    item.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["Customer"]);
                    item.MobileNo = MakeSafe.ToSafeString(row["MobileNo"]);
                    item.Address = MakeSafe.ToSafeString(row["Address"]);
                    item.CheckIntime = MakeSafe.ToSafeString(row["CheckTime"]);
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.Modell = MakeSafe.ToSafeString(row["Model"]);
                    item.Variantt = MakeSafe.ToSafeString(row["Variant"]);
                 




                    List.Add(item);
                }
                model.JobCardList = List;
            }
            return model;

        }

        public async Task<TechnicianVsBay> GetBayVsTechList(UserBase user, int WorkshopCode, string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),

                 new SqlParameter("@WorkshopCode",WorkshopCode),
                 new SqlParameter("@Date",Date)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_SERVICE_BAY_TECH_LIST]", sqlparameters);
                return GetBayVsTechList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private TechnicianVsBay GetBayVsTechList(DataSet dataSet)
        {
            TechnicianVsBay model = new TechnicianVsBay();
            List<TechnicianVsBay> Lists = new List<TechnicianVsBay>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                   
                    var item = new TechnicianVsBay();

                    item.Date = MakeSafe.ToSafeString(row["DATE"]);
                    item.BayS = MakeSafe.ToSafeString(row["BAY"]);
                    item.Techniciann = MakeSafe.ToSafeString(row["TECHNICIAN"]);

                    Lists.Add(item);
                }
                model.TechnicianVsBayList = Lists;
            }
            return model;

        }


        public async Task<TechnicianInOut> GetTechInOutList(UserBase user, int WorkshopCode, string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),

                 new SqlParameter("@WorkshopCode",WorkshopCode),
                 new SqlParameter("@Date",Date)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_SERVICE_TECHNICIAN_IN_OUT_LIST]", sqlparameters);
                return GetTechInOutList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private TechnicianInOut GetTechInOutList(DataSet dataSet)
        {
            TechnicianInOut model = new TechnicianInOut();
            List<TechnicianInOut> Lists = new List<TechnicianInOut>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    

                    var item = new TechnicianInOut();

                    item.Bays = MakeSafe.ToSafeString(row["Bay"]);
                    item.Techniciann = MakeSafe.ToSafeString(row["Technician"]);
                    item.JcCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.Intime = MakeSafe.ToSafeString(row["INtime"]);
                    item.OUTTime = MakeSafe.ToSafeString(row["OutTime"]);

                    Lists.Add(item);
                }
                model.TechnicianInOutList = Lists;
            }
            return model;

        }


        public async Task<JobcardCompletetion> GetjobcompletedList(UserBase user, int WorkshopCode, string Date)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),

                 new SqlParameter("@WorkshopCode",WorkshopCode),
                 new SqlParameter("@Date",Date)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_SERVICE_JOB_COMPLETION_LIST]", sqlparameters);
                return GetjobcompletedList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private JobcardCompletetion GetjobcompletedList(DataSet dataSet)
        {
            JobcardCompletetion model = new JobcardCompletetion();
            List<JobcardCompletetion> Lists = new List<JobcardCompletetion>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    
                    model.JobcardNo = new Dropdown();

                    var item = new JobcardCompletetion();

                    item.BayName = MakeSafe.ToSafeString(row["BayDETAILS"]);
        
                    item.JobCardNOS = MakeSafe.ToSafeString(row["JobcardNo"]);
                    item.RegNo = MakeSafe.ToSafeString(row["RegNo"]);
                    item.Technician = MakeSafe.ToSafeString(row["Technician"]);
                    item.Intime = MakeSafe.ToSafeString(row["inTime"]);
                    item.Outtime = MakeSafe.ToSafeString(row["Outtime"]);

                    Lists.Add(item);
                }
                model.JobcardCompletetionList = Lists;
            }
            return model;

        }
        public async Task<BayServiceSummary> GetBayList(UserBase user, int WorkshopCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),

                 new SqlParameter("@WorkshopCode",WorkshopCode)
            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_BAY_COMBOFILL]", sqlparameters);
                return GetList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private BayServiceSummary GetList(DataSet dataSet)
        {
            BayServiceSummary model = new BayServiceSummary();
            List<Bays> List = new List<Bays>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new Bays();

                    item.BayCode = MakeSafe.ToSafeInt32(row["Code"]);
                    item.BayName = MakeSafe.ToSafeString(row["Name"]);
                    



                    List.Add(item);
                }
                model.BaysList = List;
            }
            return model;

        }

        public async Task<ResponseEntity> Save(UserBase user, BayServiceSummary model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_BAY_SERVICE_SUMMARY_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
        public async Task<ResponseEntity<JobCardResponse>> JobCardSave(UserBase user, BayServiceSummary model)
        {
            SqlParameter CustJobNo = new SqlParameter
            {
                ParameterName = "@CustJobNo",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Output
            };

            SqlParameter ResponseKey = new SqlParameter
            {
                ParameterName = "@ResponseKey",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Direction = ParameterDirection.Output
            };

            SqlParameter ResponseStatus = new SqlParameter
            {
                ParameterName = "@ResponseStatus",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output
            };

            IDbDataParameter[] sqlParameters =
            {
        new SqlParameter("@CompanyGI", user.CompanyGuid),
        new SqlParameter("@UserGuid", user.UserGuid),
        new SqlParameter("@JSONDATA", JsonHelper.ToJson(model)),
        CustJobNo,
        ResponseKey,
        ResponseStatus
    };

            await _sql.ExecuteNonQueryAsync(
                "[DMS].[SP_BAY_SERVICE_SUMMARY_JOBCARD_ENTRY_SAVE]",
                sqlParameters,
                CommandType.StoredProcedure);

            var responseObject = new JobCardResponse
            {
                JobCardNo = CustJobNo.Value?.ToString()
            };

            return new ResponseEntity<JobCardResponse>
            (
                ResponseKey.Value?.ToString(),
                Convert.ToBoolean(ResponseStatus.Value),
                responseObject
            );
        }
        public async Task<ResponseEntity> BayVsJobSave(UserBase user, BayServiceSummary model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_BAY_SERVICE_SUMMARY_BAY_VS_JOBCARD_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
            public async Task<ResponseEntity> BayVsTechSave(UserBase user, BayServiceSummary model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_BAY_SERVICE_SUMMARY_BAY_VS_TECH_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
            public async Task<ResponseEntity> TechSave(UserBase user, BayServiceSummary model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_BAY_SERVICE_SUMMARY_TECHNICIAN_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
            public async Task<ResponseEntity> JobCompleteionSave(UserBase user, BayServiceSummary model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_BAY_SERVICE_SUMMARY_JOB_COMPLETION_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
            public async Task<ResponseEntity> GateOutSave(UserBase user, BayServiceSummary model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_BAY_SERVICE_SUMMARY_GATE_OUT_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }

    }
}


    