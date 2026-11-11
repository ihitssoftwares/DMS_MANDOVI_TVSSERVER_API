using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class ColdCallEnquireReport
    {
        public string ColdCallNo { get; set; }
        public int PhoneNo { get; set; }
     
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string EnquireDate { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string SourceOfEnq { get; set; }
        public string IntrestedModel { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string Tab { get; set; }

        public string Mobilno { get; set; }
        public string SourceOfEnquiry { get; set; }
        public UserBase User { get; set; }

        public List<ColdCallEnquireReport> ColdCallEnquireList { get; set; }
    }
}
