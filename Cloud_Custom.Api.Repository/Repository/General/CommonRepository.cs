

using Cloud_Custom.Api.Infrastructure.Helpers;
using Cloud_Custom.Api.Infrastrucure.Helpers;
using Cloud_Custom.Api.Repository.IRepository;
using Cloud_Custom.Api.Repository.IRepository.General;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.Repository.General
{
   public class CommonRepository : ICommonRepository
    {
        private readonly ISqlConnectionProvider _sql;
        private readonly IBlob _blob;
        private readonly ICommonRepository _common;
      
        public CommonRepository(ISqlConnectionProvider sql, IBlob blob)
        {
            _sql = sql;
            _blob = blob;
            _sql = sql;
           
            _blob = blob;
            //_storageConfig = settings.Value.Storage;
        }

        async Task<ResponseEntity<File>> ICommonRepository.UploadIformFileToBLOB(UserBase user, File File, string SubFolder)
        {

            try
            {

                var response = await GetFileStoragePath(user, SubFolder, "BLOB");
                var fileobj = await _blob.UploadToAzureAsync(File, user, response.PhysicalPath);
                fileobj.FileData = null;
                return new ResponseEntity<File>("SUCCESS", Convert.ToBoolean(1), fileobj);
            }

            catch (Exception ex)
            {
                string ErrorMessage = ex.Message.ToString();
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message != null)
                    {
                        ErrorMessage = ErrorMessage + ex.InnerException.Message.ToString();
                    }
                }

                return new ResponseEntity<File>(ErrorMessage, Convert.ToBoolean(0), null);
            }
        }
        public async Task<EmployeeHeader> GetEmployeeHeader(Guid EmployeeGI, UserBase user)
        {
            IDbDataParameter[] sqlparameters =
           {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI",user.UserGuid),

                new SqlParameter("@GroupCompanyGI",user.GroupCompanyGI),

                new SqlParameter("@EmployeeGI",EmployeeGI)
            };
            //var ds = await _sql.GetDataSetAsync("[HRMS].[SP_ASSET_GET_ASSET_LOG_LIST]", sqlparameters);
            var ds = await _sql.GetDataSetQueryAsync("SELECT * FROM [HRMS].[FN_GET_EMPLOYEE_BASIC_DETAILS] ('" + user.CompanyGuid + "','" + user.UserGuid + "','" + EmployeeGI + "','" + user.GroupCompanyGI + "')", CommandType.Text);
            return PopulateEmployeeHeader(ds);
        }
        private EmployeeHeader PopulateEmployeeHeader(DataSet ds)
        {
            var item = new EmployeeHeader();
            item.Designation = new Dropdown();
            item.Department = new Dropdown();
            item.Location = new Dropdown();
            item.Category = new Dropdown();
            item.ReportingManagerDesignation = new Dropdown();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                item.EmployeeAbsoluteUri = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["AbsoluteUri"]);
                //item.EmployeeHeader.EmployeeGuid = MakeSafe.ToSafeGuid(ds.Tables[0].Rows[0]["EmployeeGI"]);
                item.EmployeeGuid = MakeSafe.ToSafeGuid(ds.Tables[0].Rows[0]["EMPLOYEEGI"]);
                item.EmployeeId = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["USERCODE"]);
                item.EmployeeCode = MakeSafe.ToSafeInt32(ds.Tables[0].Rows[0]["EMPCODE"]);
                item.EmployeeName = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["FULLNAME"]);
                item.Designation.Name = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["DESIGNATION"]);
                item.Department.Name = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["DEPARTMENT"]);
                item.Location.Name = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["LOCATION"]);
                item.Category.Name = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["CATEGORY"]);
                item.ReportingManager = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["REPORTING_PERSON"]);
                item.ReportingManagerID = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["ReportingManagerID"]);
                item.ReportingManagerDesignation.Name = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["ReportingManagerDesignation"]);
                item.DOJ = MakeSafe.ToSafeDateTime(ds.Tables[0].Rows[0]["DOJ"]);
                item.FileName = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["DocumentName"]);

                return item;
            }
            return null;
        }
        public async Task<ExcelPassword> GetExcelPassword(UserBase user, string ReportName, string Type)
        {
            SqlParameter Password = new SqlParameter { ParameterName = "@Password", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter NeedPassword = new SqlParameter { ParameterName = "@NeedPassword", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@ReportName",ReportName),
                 new SqlParameter("@Type",Type),
                new SqlParameter("@UserGI",user.UserGuid),Password,NeedPassword
            };
            await _sql.GetDataSetAsync("[HRMS].[SP_GET_EXCEL_PASSWORD]", sqlParameters);
            var item = new ExcelPassword();
            item.Password = MakeSafe.ToSafeString(Password.Value.ToString());
            item.NeedPassword = MakeSafe.ToSafeBool(NeedPassword.Value);
            return item;

        }
        private ExcelPassword PopulateExcelPassword(DataSet ds)
        {
            var item = new ExcelPassword();

            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                item.Password = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["Password"]);
                item.NeedPassword = MakeSafe.ToSafeBool(ds.Tables[0].Rows[0]["NeedPassword"]);
                return item;
            }
            return null;
        }
        public async Task<Url> GetAPIUrl(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =

               {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid)


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_URL]", sqlparameters);
                return GetUrl(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Url GetUrl(DataSet dataSet)
        {
            Url model = new Url();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.CompanyCode = MakeSafe.ToSafeInt32(dataSet.Tables[0].Rows[0]["CompanyCode"]);
                model.Urllink = MakeSafe.ToSafeString(dataSet.Tables[0].Rows[0]["LocalLink"]);


            }
            return model;


        }

        public async Task<Url> GetReceiptUrl(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =

               {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid)


            };
                var ds = await _sql.GetDataSetAsync("[MCARE].[SP_GET_RECEIPT_URL]", sqlparameters);
                return GetReceiptUrl(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private Url GetReceiptUrl(DataSet dataSet)
        {
            Url model = new Url();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.CompanyCode = MakeSafe.ToSafeInt32(dataSet.Tables[0].Rows[0]["CompanyCode"]);
                model.Urllink = MakeSafe.ToSafeString(dataSet.Tables[0].Rows[0]["LocalLink"]);


            }
            return model;


        }
        public async Task<ResponseEntity> GetMasterInactiveValidation(string Master, int Code, UserBase user)
        {

            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 250, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {
            new SqlParameter("@master",Master),
             new SqlParameter("@CODE",Code),
            new SqlParameter("@UserGI",user.UserGuid),
            new SqlParameter("@CompanyGI",user.CompanyGuid),
            ResponseKey,ResponseStatus
            };
            await _sql.ExecuteNonQueryAsync("[HRMS].[SP_MASTER_INACTIVE_VALIDATION]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value));
        }
        public async Task<ResponseEntity<Int32>> GetCurrentLeavePeriod(UserBase user)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            SqlParameter LeavePeriod = new SqlParameter { ParameterName = "@LeavePeriod", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {


                new SqlParameter("@UserGI", user.UserGuid),
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                 ResponseKey,ResponseStatus,LeavePeriod
            };
            await _sql.ExecuteNonQueryAsync("[HRMS].[SP_GET_CURRENT_LEAVE_PERIOD]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity<Int32>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), Convert.ToInt32(LeavePeriod.Value));
        }
        public async Task<ResponseEntity<Int32>> GetCurrentMonthDropdown(UserBase user)
        {
            SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
            SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
            SqlParameter Month = new SqlParameter { ParameterName = "@Month", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            IDbDataParameter[] sqlParameters =
            {


                new SqlParameter("@UserGI", user.UserGuid),
                new SqlParameter("@CompanyGI", user.CompanyGuid),
                 ResponseKey,ResponseStatus,Month
            };
            await _sql.ExecuteNonQueryAsync("[HRMS].[SP_GET_CURRENT_MONTH]", sqlParameters, CommandType.StoredProcedure);
            return new ResponseEntity<Int32>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), Convert.ToInt32(Month.Value));
        }
        public async Task<DateAndMonth> GetAttendanceProcessedLastMonth(UserBase user)
        {
            SqlParameter LastProcessedMonth = new SqlParameter { ParameterName = "@LAST_PROCESSED_MONTH", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            IDbDataParameter[] sqlParameters =
           {
                new SqlParameter("@CompanyGI",user.CompanyGuid),
                new SqlParameter("@UserGI", user.UserGuid),
                new SqlParameter("@GroupCompanyGI", user.GroupCompanyGI),
                LastProcessedMonth,
            };
            await _sql.GetDataSetAsync("[HRMS].[SP_ATTENDANCE_PROCESSED_LAST_MONTH_COMBOFILL]", sqlParameters);
            var item = new DateAndMonth();
            item.LastProcessedMonth = MakeSafe.ToSafeInt32(LastProcessedMonth.Value);
            return item;
        }
       
        public async Task<SoftwareURLs> GetSoftwareURLs(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGuid", user.CompanyGuid),
                new SqlParameter("@UserGuid", user.UserGuid),

            };
                var ds = await _sql.GetDataSetAsync("[FIXED].[SP_GET_SOFTWARE_URLS]", sqlParameters);
                return fillURLS(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        private SoftwareURLs fillURLS(DataSet ds)
        {
            var item = new SoftwareURLs();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                item.CustomAppURL = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["CustomAppURL"]);
                item.HRMSAppURL = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["HRMSAppURL"]);
                item.CustomAppApplicability = MakeSafe.ToSafeInt32(ds.Tables[0].Rows[0]["CustomAppApplicability"]);
                item.HRMSAppLoginURL = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["HRMSAppLoginURL"]);
            }
            return item;
        }
        public async Task<Url> GetcertificateActive(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =

               {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid)


            };
                var ds = await _sql.GetDataSetAsync("[DMS].[SP_GET_CERTIFICATE_ACTIVE]", sqlparameters);
                return GetcertificateActive(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }

        }
        private Url GetcertificateActive(DataSet dataSet)
        {
            Url model = new Url();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.CompanyCode = MakeSafe.ToSafeInt32(dataSet.Tables[0].Rows[0]["CompanyCode"]);
                model.Certificate = MakeSafe.ToSafeString(dataSet.Tables[0].Rows[0]["Name"]);


            }
            return model;


        }  
        public async Task<Url> GetReceipt(UserBase user)
        {
            try
            {
                IDbDataParameter[] sqlparameters =

               {
                 new SqlParameter("@CompanyGI",user.CompanyGuid),
                 new SqlParameter("@UserGI",user.UserGuid)


            };
                var ds = await _sql.GetDataSetAsync("MCARE.[SP_GET_RECEIPT_ACTIVE]", sqlparameters);
                return GetReceipt(ds);
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }

        }
        private Url GetReceipt(DataSet dataSet)
        {
            Url model = new Url();

            if ((dataSet.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                model.CompanyCode = MakeSafe.ToSafeInt32(dataSet.Tables[0].Rows[0]["CompanyCode"]);
                model.Receipt = MakeSafe.ToSafeString(dataSet.Tables[0].Rows[0]["Name"]);


            }
            return model;


        }

        #region FILe STorage
        public async Task<ResponseEntity<string>> GetFileStorageType(UserBase user)
        {
            try
            {
                SqlParameter ResponseKey = new SqlParameter { ParameterName = "@ResponseKey", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                SqlParameter ResponseStatus = new SqlParameter { ParameterName = "@ResponseStatus", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };
                SqlParameter StorageType = new SqlParameter { ParameterName = "@StorageType", SqlDbType = SqlDbType.VarChar, Size = 50, Direction = ParameterDirection.Output };
                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGuid", user.CompanyGuid),
                new SqlParameter("@UserGuid",user.UserGuid),
                ResponseKey,ResponseStatus,StorageType
            };
                await _sql.ExecuteNonQueryAsync("[HRMS].[SP_GET_FILE_STORAGE_TYPE]", sqlParameters, CommandType.StoredProcedure);
                return new ResponseEntity<string>(ResponseKey.Value.ToString(), Convert.ToBoolean(ResponseStatus.Value), (StorageType.Value.ToString()));
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }
        public async Task<FileStoragePath> GetFileStoragePath(UserBase user, string Subfoldername, string StorageType)
        {
            try
            {
                IDbDataParameter[] sqlParameters =
                {
                new SqlParameter("@CompanyGuid", user.CompanyGuid),
                 new SqlParameter("@SubFolderName", Subfoldername),
                  new SqlParameter("@StorageType", StorageType),

            };
                var ds = await _sql.GetDataSetAsync("[HRMS].[SP_GET_FILE_STORAGE_PATH]", sqlParameters);
                var data = fillfileStoragePath(ds);
                return data;
            }
            catch (SqlException ex)
            {
                var ErrorMsg = ex.Message.ToString();
                throw new Exception(ErrorMsg, ex);
            }
        }

        private FileStoragePath fillfileStoragePath(DataSet ds)
        {
            var item = new FileStoragePath();
            if ((ds.Tables[0]?.Rows?.Count ?? 0) > 0)
            {
                item.PhysicalPath = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["PhysicalPath"]);
                item.URLPath = MakeSafe.ToSafeString(ds.Tables[0].Rows[0]["URLPath"]);
            }

            return item;
        }       
   
        #endregion
    }
}
