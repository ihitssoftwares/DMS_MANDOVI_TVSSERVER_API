using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ColdFollowUP
    {
        public string LeadNo { get; set; }
        public int Trnno { get; set; }
        public string EmployeeName { get; set; }
        public int EmpCode { get; set; }
        public int cCount { get; set; }
        public Guid UserGI { get; set; }
        public string ReportingName { get; set; }
        public string CustomerName { get; set; }
        public string EnquireDate { get; set; }
        public string EmailId { get; set; }
        public string FollowupNextDate { get; set; }
        public string IntrestedModel { get; set; }

        public string EmployeeRole { get; set; }
        public int BranchCode { get; set; }
        public string Mobilno { get; set; }
        public string SourceOfEnquiry { get; set; }
        public UserBase User { get; set; }
        public Dropdown SalesExc { get; set; }
        public string SalesExecutive { get; set; }
        public List<ColdFollowUP> ColdFollowUPList { get; set; }
       
        public ColdFollowUPItem ColdFollowUPItem { get; set; }

        public string Status { get; set; }
        public int active { get; set; }
        public int totalRecords { get; set; }

    }
    public class ColdFollowUPItem
    {
        public string LeadNo { get; set; }
        public int Trnno { get; set; }
        public string CustomerName { get; set; }
        public string EnquireDate { get; set; }
        public string EmailId { get; set; }

        public int IntrestedModel { get; set; }

        public string Mobilno { get; set; }
        public string SourceOfEnquiry { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string ModeOfContract { get; set; }
        public string NextDate { get; set; }
        public string LeadSts { get; set; }
        public int SalesExecutive { get; set; }
        public Dropdown Modell { get; set; }
        public Dropdown SalesExc { get; set; }
        public Dropdown Variant { get; set; }
        public Dropdown Color { get; set; }
        public Dropdown Remarks { get; set; }
        public Dropdown SourceofENQ { get; set; }
        public Dropdown PurchaseTime { get; set; }

        public string ContactDate { get; set; }
        public string ModeofContact { get; set; }
        public string Remarkss { get; set; }
        public string NextFollowupDate { get; set; }
        public string LeadStatus { get; set; }
        public string PurchaseTimes { get; set; }
        public string MDMSEnquiryCode { get; set; }
        public string MDMSEnquiryDate { get; set; }
        public List<ColdFollowUPItem> ColdFollowUPDeatilList { get; set; }
    }

    
}
