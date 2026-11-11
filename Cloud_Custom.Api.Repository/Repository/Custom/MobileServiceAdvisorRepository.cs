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
     public class MobileServiceAdvisorRepository : IMobileServiceAdvisorRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MobileServiceAdvisorRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MobileServiceAdvisor> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SERVICE_DASHBOARD_SERVICE_ADVISOR]", sqlparameters);
                return ServiceAdvisor(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileServiceAdvisor ServiceAdvisor(DataSet ds)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileServiceAdvisor> list = new List<MobileServiceAdvisor>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MobileServiceAdvisor();

                    item.JCNotOpened = MakeSafe.ToSafeInt32(row["JcNotOpened"]);
                    item.JCOpened = MakeSafe.ToSafeInt32(row["JCOpenedNotInBay"]);
                    item.InBay = MakeSafe.ToSafeInt32(row["InBay"]);
                    item.BillPending = MakeSafe.ToSafeInt32(row["BillPending"]);
                    item.Billed = MakeSafe.ToSafeInt32(row["Billed"]);
                    item.Hold = MakeSafe.ToSafeInt32(row["Hold"]);
                    item.Delayed = MakeSafe.ToSafeInt32(row["DelayedMoreThanOneDay"]);
                    item.DelayedInBay = MakeSafe.ToSafeInt32(row["DelayedInBay"]);
                    item.BillAmount = MakeSafe.ToSafeDecimal(row["BillAmount"]);
                    list.Add(item);
                }

                model.List = list;
            }
           


            return model;
        }

        public async Task<MobileServiceAdvisor> CardDetailsList(UserBase user,string  Type)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",Type),


            };
                var ds = await _sql.GetDataSetAsync("DMS.[SP_MOBILE_SERVICE_DASHBOARD_ADVISOR_CARD_DETAILS]", sqlparameters);
                return CardDetailsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileServiceAdvisor CardDetailsList(DataSet ds)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileServiceAdvisor> list = new List<MobileServiceAdvisor>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MobileServiceAdvisor();

                    item.JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JOBCARDNO"]);
                    item.Customer = MakeSafe.ToSafeString(row["CUSTOMER"]);
                    item.Regno = MakeSafe.ToSafeString(row["REGNO"]);
                    item.Checkin = MakeSafe.ToSafeString(row["CHECKIN"]);
                    item.jcStatus = MakeSafe.ToSafeString(row["JCSTATUS"]);
                    item.BillAmount = MakeSafe.ToSafeInt32(row["AMOUNT"]);
                    item.ModelName = MakeSafe.ToSafeString(row["MODEL"]);
                    item.VariantName = MakeSafe.ToSafeString(row["VARIANT"]);
                    item.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    item.MCare = MakeSafe.ToSafeInt32(row["MCare"]);
                    
                    list.Add(item);
                }

                model.CardList = list;
            }



            return model;
        }
        public async Task<MobileServiceAdvisor> GetMCareDetails(UserBase user, int CustomerCode)
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
        private MobileServiceAdvisor GetMCareCustomerDetails(DataSet ds)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();
            List<MobileServiceAdvisor> getList = new List<MobileServiceAdvisor>();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    getList.Add(new MobileServiceAdvisor
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
        public async Task<MobileServiceAdvisor> BayList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_DASHBOARD_JOB TRACK_ADVISOR_BAY_OCCUPANCY]", sqlparameters);
                return BayList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileServiceAdvisor BayList(DataSet ds)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileServiceAdvisor> list = new List<MobileServiceAdvisor>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MobileServiceAdvisor();

                    item.BayName = MakeSafe.ToSafeString(row["BayUserCode"]);
                    item.BayStatus = MakeSafe.ToSafeString(row["BayStatus"]);
                    item.VehicleReg = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.Jobcard = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.Technician = MakeSafe.ToSafeString(row["Technician"]);
                    item.count = MakeSafe.ToSafeInt32(row["UnitCompleted"]);

                    list.Add(item);
                }

                model.BayOccupancy = list;
            }



            return model;
        }

        public async Task<MobileServiceAdvisor> JobCardDetails(UserBase user, int JobCardEntryCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JobCardEntryCode",JobCardEntryCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SERVICE_DASHBOARD_SERVICE_JOBCARD_DETAILS]", sqlparameters);
                return JobCardDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileServiceAdvisor JobCardDetails(DataSet ds)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
         
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    
                 
                    model.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    model.JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]);
                    model.ModelName = MakeSafe.ToSafeString(row["ModeName"]);
                    model.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
                    model.JobCardID = MakeSafe.ToSafeString(row["JobCardNo"]);
                    model.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    model.Mobile = MakeSafe.ToSafeString(row["Phone"]);
                    model.RegistrationNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);



                }

            }
            if ((ds.Tables[1]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileServiceAdvisor> list = new List<MobileServiceAdvisor>();
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new MobileServiceAdvisor();
                    item.RegistrationNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.BayUserCode = MakeSafe.ToSafeInt32(row["BayUserCode"]);
                    item.BayName = MakeSafe.ToSafeString(row["BayName"]);
                    item.Technician = MakeSafe.ToSafeString(row["Technician"]);
                    item.InTime = MakeSafe.ToSafeString(row["InTime"]);
                    item.OutTime = MakeSafe.ToSafeString(row["OutTime"]);
                    list.Add(item);
                }
                model.BayList = list;
            }

            return model;
        }
        public async Task<MobileServiceAdvisor> HistoryList(UserBase user, int ServiceAdvisorCode, DateTime PickedDate)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@ServiceAdvisorCode",ServiceAdvisorCode),
                 new SqlParameter("@PickedDate",PickedDate),

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SERVICE_DASHBOARD_SERVICE_ADVISOR_HISTORY]", sqlparameters);
                return HistoryList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileServiceAdvisor HistoryList(DataSet ds)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileServiceAdvisor> list = new List<MobileServiceAdvisor>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MobileServiceAdvisor();
                    item.JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.ModelName = MakeSafe.ToSafeString(row["ModeName"]);
                    item.VariantName = MakeSafe.ToSafeString(row["VariantName"]);
                    item.JobCardID = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.Mobile = MakeSafe.ToSafeString(row["Phone"]);
                    item.RegistrationNo = MakeSafe.ToSafeString(row["VehicleRegistrationNumber"]);
                    item.ServiceDate = MakeSafe.ToSafeDateTime(row["JCDateTime"]);
                    item.CheckIn = MakeSafe.ToSafeString(row["CheckIn"]);
                    item.CheckOut = MakeSafe.ToSafeString(row["CheckOut"]);
                    
                    list.Add(item);
                }
                model.List = list;
            }

            return model;
        }
        public async Task<MobileServiceAdvisor> HistoryDetails(UserBase user, int JobCardEntryCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JobCardEntryCode",JobCardEntryCode),
           

            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SERVICE_DASHBOARD_SERVICE_HISTORY_DETAILS]", sqlparameters);
                return HistoryDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileServiceAdvisor HistoryDetails(DataSet ds)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();
           
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileServiceAdvisor> list = new List<MobileServiceAdvisor>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MobileServiceAdvisor();
                    item.RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNumber"]);
                    item.BayName = MakeSafe.ToSafeString(row["BayName"]);
                    item.Technician = MakeSafe.ToSafeString(row["EmployeeName"]);
                    item.InTime = MakeSafe.ToSafeString(row["InTime"]);
                    item.OutTime = MakeSafe.ToSafeString(row["OutTime"]);



                    list.Add(item);
                }
                model.BayList = list;
            }

            return model;
        }
        public async Task<MobileServiceAdvisor> GetNotAssignedList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI", user.CompanyGuid),
                 new SqlParameter("@UserGuid", user.UserGuid),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SERVICE_ADVISOR_DRIVER_LIST]", sqlparameters);
                return AssignDriverList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileServiceAdvisor AssignDriverList(DataSet dataSet)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();
            List<MobileServiceAdvisor> List = new List<MobileServiceAdvisor>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    MobileServiceAdvisor item = new MobileServiceAdvisor();

           
                    item.BookingNumber = MakeSafe.ToSafeString(row["BookingNo"]);
                    item.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.Mobile = MakeSafe.ToSafeString(row["MobileNo"]);
                    item.RegistrationNo = MakeSafe.ToSafeString(row["RegistrationNo"]);
                    item.ModelName = MakeSafe.ToSafeString(row["Model"]);
                    item.ServiceDueType = MakeSafe.ToSafeString(row["ServiceDueType"]);
                    item.ServiceTypeName = MakeSafe.ToSafeString(row["ServiceType"]);
                    item.PickUpAddress = MakeSafe.ToSafeString(row["PickupAddress"]);
                    item.PreferredDate = MakeSafe.ToSafeString(row["PreferredDate"]);
                    item.PreferredTimeSlot = MakeSafe.ToSafeString(row["PreferredTimeSlot"]);


                    List.Add(item);
                }
                model.DriverList = List;
            }

            return model;
        }

        public async Task<MobileServiceAdvisor> GetCustomerDetails(UserBase user, int CustomerCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@CustomerCode",CustomerCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SERVICE_ADVISOR_CUSTOMER_DETAILS]", sqlparameters);
                return PopulateCustomerdetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private MobileServiceAdvisor PopulateCustomerdetails(DataSet dataSet)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();
            List<MobileServiceAdvisor> CustomerList = new List<MobileServiceAdvisor>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    

                    model.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    model.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    model.PickUpAddress = MakeSafe.ToSafeString(row["PickupAddress"]);
                    model.PreferredDate = MakeSafe.ToSafeString(row["PreferredDate"]);
                    model.PreferredTimeSlot = MakeSafe.ToSafeString(row["PreferredTimeSlot"]);
                   
                }
            }
            return model;

        }


        public async Task<ResponseEntity> PopupSave(UserBase user, MobileServiceAdvisor model, int empcode)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                  new SqlParameter("@empcode",empcode),

                // new SqlParameter("@Mode",mode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MOBILE_SERVICE_ADVISOR_DRIVER_POPUP_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<MobileServiceAdvisor> JobCardList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_SERVICE_ADVISOR_BAY_MANAGEMENT_LIST]", sqlparameters);
                return GetList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileServiceAdvisor GetList(DataSet dataSet)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();
            List<MobileServiceAdvisor> List = new List<MobileServiceAdvisor>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new MobileServiceAdvisor();

                    item.JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardCode"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JobCardNo"]);
                    item.JobCardDate = MakeSafe.ToSafeDateTime(row["Jcdate"]);
                    item.CustomerCode = MakeSafe.ToSafeInt32(row["CustomerCode"]);
                    item.CustomerName = MakeSafe.ToSafeString(row["CustomerName"]);
                    item.RegistrationNo = MakeSafe.ToSafeString(row["VehicleRegNo"]);
                    item.Mobile = MakeSafe.ToSafeString(row["PhoneNo"]);
                    item.ChassisNo = MakeSafe.ToSafeString(row["ChassisNo"]);
                    item.EngineNo = MakeSafe.ToSafeString(row["EngineNo"]);
                    item.ModelName = MakeSafe.ToSafeString(row["Model"]);
                    item.VariantName = MakeSafe.ToSafeString(row["variant"]);
                    item.BayCount = MakeSafe.ToSafeInt32(row["BayCount"]);



                    List.Add(item);
                }
                model.BayList = List;
            }
            return model;

        }


        public async Task<MobileServiceAdvisor> GetBayDetails(UserBase user, int JobCardCode)
        {

            IDbDataParameter[] sqlparameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                new SqlParameter("@JobCardCode",JobCardCode),


            };
            var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_SERVICE_BAY_MANAGEMENT_DETAILS_LIST]", sqlparameters);

            return PopulateGetBayDetails(ds);

        }
        public MobileServiceAdvisor PopulateGetBayDetails(DataSet ds)
        {
            MobileServiceAdvisor model = new MobileServiceAdvisor();
            BayApplicablity bayApplicablity = new BayApplicablity();
            List<BayApplicablity> bayDetailsList = new List<BayApplicablity>();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new BayApplicablity();
                    item.BayCode = MakeSafe.ToSafeInt32(row["BayCode"]);
                    item.Bayname = MakeSafe.ToSafeString(row["BAY"]);
                    item.BayTypeCode = MakeSafe.ToSafeInt32(row["BayTypeCode"]);
                    item.BayTypename = MakeSafe.ToSafeString(row["BAYTYPE"]);
                    item.Applicability = MakeSafe.ToSafeBool(row["Applicability"]);
                    bayDetailsList.Add(item);
                }

                bayApplicablity.BayDetailsList = bayDetailsList;  
                model.BayApplicablity = bayApplicablity;          
            }

            return model;
        }
        public async Task<ResponseEntity> SaveBay(UserBase user, MobileServiceAdvisor model)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {        new SqlParameter("@CompanyGI",user.CompanyGuid),
                     new SqlParameter("@UserGuid",user.UserGuid),
                       new SqlParameter("@JSONDATA",JsonHelper.ToJson(model)),
                ResponseKey,ResponseStatus
                };
            await _sql.ExecuteNonQueryAsync("[DMS].[SP_MOBILE_SERVICE_ADVISOR_BAY_MANAGEMENT_SAVE]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
        public async Task<ResponseEntity> UpdateJobCard(UserBase user, int JobCardPhotoEntryCode,string Type)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JobCardPhotoEntryCode",JobCardPhotoEntryCode),
                 new SqlParameter("@Type",Type),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MOBILE_SERVICE_ADVISOR_JOBCARD_UPDATE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<ResponseEntity> SaveEntry(UserBase user, MobileServiceAdvisor input)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JSONDATA",JsonHelper.ToJson(input)),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MOBILE_JOBCARD_ENTRY_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        public async Task<ResponseEntity> Save(UserBase user, int  JobCardPhotoEntryCode)
        {
            try
            {

                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

                IDbDataParameter[] sqlParameters =
                {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JobCardPhotoEntryCode",JobCardPhotoEntryCode),
                    ResponseKey,ResponseStatus
            };
                await _sql.ExecuteNonQueryAsync("[DMS].[SP_MOBILE_SERVICE_ADVISOR_DETAILS_SAVE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }


    }
}
