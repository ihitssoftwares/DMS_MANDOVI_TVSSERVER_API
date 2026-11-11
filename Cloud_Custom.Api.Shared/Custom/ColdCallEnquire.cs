using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ColdCallEnquire
    {
        public string ColdCallNo { get; set; }
        public int PhoneNo { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Status { get; set; }
        public string CustomerName { get; set; }
        public string EnquireDate { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        
        public string IntrestedModel { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        
        public string Mobilno { get; set; }
        public string SourceOfEnquiry { get; set; }
        public string Statuss { get; set; }
        public UserBase User { get; set; }

        public Dropdown Modell { get; set; }
        public Dropdown SalesExc { get; set; }
        public Dropdown Variant { get; set; }
        public Dropdown Color { get; set; }
        public Dropdown Remarks { get; set; }
        public Dropdown SourceofENQ { get; set; }
      
        public List<ColdCallEnquire> ColdCallEnquireList { get; set; }
        public ColdCallEnquireItem ColdCallEnquireItem { get; set; }


    }
    public class ColdCallEnquireItem
    {
        public string ColdCallNo { get; set; }
        public int TrnCode { get; set; }
        public string CustomerName { get; set; }
        public string EnquireDate { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string SourceOfEnq { get; set; }
        public string IntrestedModel { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        
        public string Mobilno { get; set; }
        public string SourceOfEnquiry { get; set; }
        public string ModeOfContract { get; set; }
        public string NextDate { get; set; }
        public string LeadSts { get; set; }
        public Dropdown Modell { get; set; }
        public Dropdown SalesExc { get; set; }
        public Dropdown Variant { get; set; }
        public Dropdown PurchaseTime { get; set; }
        public Dropdown Employee { get; set; }
        public string MDMSEnquiryCode { get; set; }
        public string MDMSEnquiryDate { get; set; }
    }
}

