using Cloud_Custom.Api.Shared.Account;
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cloud_Custom.Api.Repository.IRepository.Account
{
   public interface IPasswordSettingsRepository
    {
        public  Task<PasswordPolicySettings> GetPasswordPolicySettings(UserBase userBase);
        public  Task<PasswordPolicySettings> GetForgetPasswordPasswordPolicySettings(String CompanyID);
        public  Task<ResponseEntity> ChangePasswordSave(ChangePassword model);
        public Task<ResponseEntity> ForgetPasswordSave(ForgetPassword model);
        public  Task<ResponseEntity> PasswordPolicySettingsSave(PasswordPolicySettings model);
        public Task<ResponseEntity> ForgetPasswordVerifyOTP(string CompanyID, string EmployeeID, string OTP);
        public  Task<ResponseEntity> ForgetPasswordGenerateOTP(string CompanyID, string EmployeeID, string MobileNumber);
        public Task<ResponseEntity> ChangePasswordVerifyOTP(UserBase user, string OTP);
        public Task<ResponseEntity> ChangePasswordGenerateOTP(UserBase user,string CurrPassword);
        #region GenerateDOB_PasswordForEmployees_Indata Porting
        public Task<ResponseEntity> Schedule_PasswordGeneneration( int EmployeeCode, string DOB, int UserCode);
        #endregion
    }
}
