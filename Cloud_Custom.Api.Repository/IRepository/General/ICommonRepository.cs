using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.General
{
   public interface ICommonRepository
    {
        public Task<ResponseEntity<File>> UploadIformFileToBLOB(UserBase user, File File, string SubFolder);
        Task<EmployeeHeader> GetEmployeeHeader(Guid EmployeeGI, UserBase user);
        Task<ExcelPassword> GetExcelPassword(UserBase user, string ReportName, string Type);
        Task<Url> GetAPIUrl(UserBase user);
        Task<Url> GetReceiptUrl(UserBase user);
        public Task<ResponseEntity> GetMasterInactiveValidation(string Master, int Code, UserBase user);
        Task<ResponseEntity<Int32>> GetCurrentMonthDropdown(UserBase user);
        Task<ResponseEntity<Int32>> GetCurrentLeavePeriod(UserBase user);
        public Task<DateAndMonth> GetAttendanceProcessedLastMonth(UserBase user);
        Task<SoftwareURLs> GetSoftwareURLs(UserBase user);
        Task<Url> GetcertificateActive(UserBase user);
        Task<Url> GetReceipt(UserBase user);
        #region DYNAMIC FILE
        Task<ResponseEntity<string>> GetFileStorageType(UserBase user);
        public Task<FileStoragePath> GetFileStoragePath(UserBase user, string Subfoldername, string StorageType);
        //public Task<ResponseEntity<File>> UploadByteArrayToIIS(UserBase user, File File, string SubFolder);
        //public Task<ResponseEntity<File>> UploadIformFileToIIS(UserBase user, File File, string SubFolder);
        //public Task<ResponseEntity<File>> UploadByteArrayToBLOB(UserBase user, File File, string SubFolder);
        //public Task<ResponseEntity<File>> UploadIformFileToBLOB(UserBase user, File File, string SubFolder);
        //public Task<ResponseEntity<File>> UploadIformFileToAWS(UserBase user, File File, string SubFolder);

        //public Task<ResponseEntity<File>> UploadByteArrayToAWS(UserBase user, File File, string SubFolder);
        #endregion
    }
}
