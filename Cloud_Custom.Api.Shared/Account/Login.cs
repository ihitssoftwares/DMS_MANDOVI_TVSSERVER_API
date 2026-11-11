using Cloud_Custom.Api.Shared.General;
using Cloud_Custom.Api.Shared.Mobile; 

namespace Cloud_Custom.Api.Shared.Account
{
    public class Login
    {
        public AuthUser authUser { get; set; }
        public string CompanyCode { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string CompanyName { get; set; }
        public string MACAddress { get; set; }
        public string INOUT { get; set; }
        public string software { get; set; }
        public MobDeviceData DeviceData { get; set; }
        public int GroupCompanyCode { get; set; }
        public string GroupCompanyName { get; set; }
        public string LoginStatus { get; set; }
        public bool LoginSuccess { get; set; }
        public int SalaryVisibility { get; set; }

    }
    public class CustomSoftware
    {
        public File SoftwareLogo { get; set; }
        public File SoftwareName { get; set; } //ESSP SoftwareName
        public File HRMS_SoftwareName { get; set; }
        public File AbsoluteUri { get; set; }
        public string CompanyLogoBlobUrl { get; set; }
    }
}
