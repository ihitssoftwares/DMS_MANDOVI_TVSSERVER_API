using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public   class ColdFollowUpReport
    {
            public string LeadNo { get; set; }
            public int Trnno { get; set; }
            public string CustomerName { get; set; }
            public string EnquireDate { get; set; }
            public string EmailId { get; set; }
            public string LeadSts { get; set; }

            public string IntrestedModel { get; set; }

            public string Mobilno { get; set; }
            public string SourceOfEnquiry { get; set; }
            public UserBase User { get; set; }
            public Dropdown SalesExc { get; set; }
            public Dropdown Region { get; set; }
            public Dropdown Statuss { get; set; }
            public Dropdown Branch { get; set; }
        public string SalesExecutive { get; set; }
            public string Status { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
        public string PurchaseTimelines { get; set; }

        public string TestDriveDate { get; set; }

        public List<ColdFollowUpReport> ColdFollowUPList { get; set; }
            public ColdFollowUPItems ColdFollowUPItems { get; set; }
        public int active { get; set; }
        public int totalRecords { get; set; }

    }
        public class ColdFollowUPItems
        {
        public string LeadNo { get; set; }
        public int Trnno { get; set; }
        public string EnquireDate { get; set; }
        public string IntrestedModel { get; set; }
        public string ModelDetails { get; set; }
        public string ModeOfContract { get; set; }
        public string NextDate { get; set; }
        public string SalesExecutive { get; set; }
        public string Remarkss { get; set; }
        public string CustomerName { get; set; }
      
        public string LeadStatus { get; set; }
        public string Status { get; set; }
      
        public List<ColdFollowUPItems> ColdFollowUPDeatilList { get; set; }
        }
    }

