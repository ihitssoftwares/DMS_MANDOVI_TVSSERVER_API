using System;
using System.Collections.Generic;
using System.Text;


namespace Cloud_Custom.Api.Shared.Account
{
   public class LoginAttempt
    {
        public string CompanyCode { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public int GroupCompanyCode { get; set; }
        public int SalaryVisibility { get; set; }

    }
}
