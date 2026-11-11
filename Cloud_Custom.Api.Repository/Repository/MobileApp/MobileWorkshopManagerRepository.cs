using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
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
     public class MobileWorkshopManagerRepository : IMobileWorkshopManagerRepository
    {
        private readonly ISqlConnectionProvider _sql;
        public MobileWorkshopManagerRepository(ISqlConnectionProvider sql)
        {
            _sql = sql;
        }
        public async Task<MobileWorkshopManager> GetList(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_WORKSHOP_MANAGER_DASHBOARD]", sqlparameters);
                return ServiceAdvisor(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileWorkshopManager ServiceAdvisor(DataSet ds)
        {
            MobileWorkshopManager model = new MobileWorkshopManager();


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileWorkshopManager> list = new List<MobileWorkshopManager>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MobileWorkshopManager();

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

        public async Task<MobileWorkshopManager> CardDetailsList(UserBase user, string Type)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@Type",Type),


            };
                var ds = await _sql.GetDataSetAsync("DMS.[SP_MOBILE_WORKSHOP_DASHBOARD_CARD_DETAILS]", sqlparameters);
                return CardDetailsList(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileWorkshopManager CardDetailsList(DataSet ds)
        {
            MobileWorkshopManager model = new MobileWorkshopManager();


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileWorkshopManager> list = new List<MobileWorkshopManager>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MobileWorkshopManager();

                    item.JobCardEntryCode = MakeSafe.ToSafeInt32(row["JobCardEntryCode"]);
                    item.JobCardNo = MakeSafe.ToSafeString(row["JOBCARDNO"]);
                    item.Customer = MakeSafe.ToSafeString(row["CUSTOMER"]);
                    item.Regno = MakeSafe.ToSafeString(row["REGNO"]);
                    item.Checkin = MakeSafe.ToSafeString(row["CHECKIN"]);
                    item.jcStatus = MakeSafe.ToSafeString(row["JCSTATUS"]);
                    item.BillAmount = MakeSafe.ToSafeInt32(row["AMOUNT"]);
                    item.ModelName = MakeSafe.ToSafeString(row["MODEL"]);
                    item.VariantName = MakeSafe.ToSafeString(row["VARIANT"]);

                    list.Add(item);
                }

                model.CardList = list;
            }



            return model;
        }

        public async Task<MobileWorkshopManager> BayList(UserBase user)
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
        private MobileWorkshopManager BayList(DataSet ds)
        {
            MobileWorkshopManager model = new MobileWorkshopManager();


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileWorkshopManager> list = new List<MobileWorkshopManager>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MobileWorkshopManager();

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

        public async Task<MobileWorkshopManager> JobCardDetails(UserBase user, int JobCardEntryCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                 new SqlParameter("@JobCardEntryCode",JobCardEntryCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_WORKSHOP_MANAGER_DASHBOARD_JOBCARD_DETAILS]", sqlparameters);
                return JobCardDetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private MobileWorkshopManager JobCardDetails(DataSet ds)
        {
            MobileWorkshopManager model = new MobileWorkshopManager();

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
                List<MobileWorkshopManager> list = new List<MobileWorkshopManager>();
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var item = new MobileWorkshopManager();
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
        public async Task<MobileWorkshopManager> HistoryList(UserBase user, int ServiceAdvisorCode, DateTime PickedDate)
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
        private MobileWorkshopManager HistoryList(DataSet ds)
        {
            MobileWorkshopManager model = new MobileWorkshopManager();


            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileWorkshopManager> list = new List<MobileWorkshopManager>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MobileWorkshopManager();
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
        public async Task<MobileWorkshopManager> HistoryDetails(UserBase user, int JobCardEntryCode)
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
        private MobileWorkshopManager HistoryDetails(DataSet ds)
        {
            MobileWorkshopManager model = new MobileWorkshopManager();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                List<MobileWorkshopManager> list = new List<MobileWorkshopManager>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var item = new MobileWorkshopManager();
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
        public async Task<MobileWorkshopManager> GetNotAssignedList(UserBase user)
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
        private MobileWorkshopManager AssignDriverList(DataSet dataSet)
        {
            MobileWorkshopManager model = new MobileWorkshopManager();
            List<MobileWorkshopManager> List = new List<MobileWorkshopManager>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    MobileWorkshopManager item = new MobileWorkshopManager();


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

        public async Task<MobileWorkshopManager> GetCustomerDetails(UserBase user, int CustomerCode)
        {
            try
            {
                IDbDataParameter[] sqlparameters =
                  {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGuid",user.UserGuid),
                  new SqlParameter("@CustomerCode",CustomerCode),


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_MOBILE_WORSHOP_MANAGER_CUSTOMER_DETAILS]", sqlparameters);
                return PopulateCustomerdetails(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private MobileWorkshopManager PopulateCustomerdetails(DataSet dataSet)
        {
            MobileWorkshopManager model = new MobileWorkshopManager();
            List<MobileWorkshopManager> CustomerList = new List<MobileWorkshopManager>();

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


        public async Task<ResponseEntity> PopupSave(UserBase user, MobileWorkshopManager model, int empcode)
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
        public async Task<MobileWorkshopManager> JobCardList(UserBase user)
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
        private MobileWorkshopManager GetList(DataSet dataSet)
        {
            MobileWorkshopManager model = new MobileWorkshopManager();
            List<MobileWorkshopManager> List = new List<MobileWorkshopManager>();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    var item = new MobileWorkshopManager();

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


        public async Task<MobileWorkshopManager> GetBayDetails(UserBase user, int JobCardCode)
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
        public MobileWorkshopManager PopulateGetBayDetails(DataSet ds)
        {
            MobileWorkshopManager model = new MobileWorkshopManager();
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
        public async Task<ResponseEntity> SaveBay(UserBase user, MobileWorkshopManager model)
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
        public async Task<ResponseEntity> UpdateJobCard(UserBase user, int JobCardPhotoEntryCode, string Type)
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

        public async Task<ResponseEntity> SaveEntry(UserBase user, MobileWorkshopManager input)
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

        public async Task<ResponseEntity> Save(UserBase user, int JobCardPhotoEntryCode)
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
