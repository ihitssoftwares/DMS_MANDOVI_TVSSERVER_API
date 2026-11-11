using Microsoft.AspNetCore.Mvc;
using Cloud_Custom.Api.Repository.IRepository.Account;
using Cloud_Custom.Api.Shared.Account;
using Cloud_Custom.Api.Shared.General;
using SAMPLE_API_PLUS.Helper;
using System;
using System.Threading.Tasks;

namespace Hrms.Lite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordSettingsController : ControllerBase
    {
        #region Private properties
        private readonly IPasswordSettingsRepository _repo;
        #endregion
        #region Constructor        
        public PasswordSettingsController(IPasswordSettingsRepository repo)
        {
            _repo = repo;
        }
        #endregion
        #region Get PasswordSettings
        [HttpGet("GetPasswordPolicySettings")]
        public async Task<IActionResult> GetPasswordPolicySettings()
        {
            return Ok(await _repo.GetPasswordPolicySettings(UserHelper.GetUser(User)));
        }
        [HttpGet("GetForgetPasswordPasswordPolicySettings")]
        public async Task<IActionResult> GetForgetPasswordPasswordPolicySettings(string CompanyID)
        {
            return Ok(await _repo.GetForgetPasswordPasswordPolicySettings(CompanyID));
        }
        #endregion
        #region Post
        [HttpPost("ChangePasswordSave")]
        public async Task<IActionResult> ChangePasswordSave(ChangePassword model)
        {
            model.User = UserHelper.GetUser(User);
            return Ok(await _repo.ChangePasswordSave(model));
        }
        [HttpPost("ForgetPasswordSave")]
        public async Task<IActionResult> ForgetPasswordSave(ForgetPassword model)
        {
            return Ok(await _repo.ForgetPasswordSave(model));
        }
        [HttpPost("PasswordPolicySettingsSave")]
        public async Task<IActionResult> PasswordPolicySettingsSave(PasswordPolicySettings model)
        {
            model.User = UserHelper.GetUser(User);
            return Ok(await _repo.PasswordPolicySettingsSave(model));
        }
        [HttpPost("ForgetPasswordVerifyOTP")]
        public async Task<IActionResult> ForgetPasswordVerifyOTP(ForgetPassword model)
        {
            return Ok(await _repo.ForgetPasswordVerifyOTP(model.CompanyID,model.EmployeeID,model.EnterOTP));
        }
        [HttpPost("ForgetPasswordGenerateOTP")]
        public async Task<IActionResult> ForgetPasswordGenerateOTP(ForgetPassword model)
        {
            return Ok(await _repo.ForgetPasswordGenerateOTP(model.CompanyID, model.EmployeeID,  model.MobileNumber));
        }

        [HttpGet("ChangePasswordVerifyOTP")]
        public async Task<IActionResult> ChangePasswordVerifyOTP(string OTP)
        {
            return Ok(await _repo.ChangePasswordVerifyOTP(UserHelper.GetUser(User), OTP));
        }
        [HttpGet("ChangePasswordGenerateOTP")]
        public async Task<IActionResult> ChangePasswordGenerateOTP(string CurrPassword)
        {
            return Ok(await _repo.ChangePasswordGenerateOTP(UserHelper.GetUser(User), CurrPassword));
        }
        #endregion PasswordSettings


        #region GenerateDOB_PasswordForEmployees_Indata Porting

        [HttpGet("Schedule_PasswordGeneneration")]
        
        public async Task<IActionResult> Schedule_PasswordGeneneration(int EmployeeCode,  string DOB)  //Sheduling  hash and Salt geneartion  for employees(dob as password (eg:30021996))
        {
            //SELECT REPLACE(CONVERT(CHAR(10), @dob, 103), '/', '')
            return Ok(await _repo.Schedule_PasswordGeneneration(EmployeeCode, DOB,0));  // usercode=0
        }
        #endregion

        #region RESET PASSWORD

        [HttpPost("ResetPassword")]   //reset password for employees nad non EMployees FROM HRMS

        public async Task<IActionResult> ResetPassword(SchedulePasswordGenertion model)
        {    
        return Ok(await _repo.Schedule_PasswordGeneneration(model.EmployeeCode, model.Password, model.UserCode));
        }
        #endregion
    }
}
