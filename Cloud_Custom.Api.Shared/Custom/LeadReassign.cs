using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public  class LeadReassign
    {
        public string LeadNo { get; set; }
        public int Trnno { get; set; }
        public string CustomerName { get; set; }
        public string EnquireDate { get; set; }
        public string EmailId { get; set; }
        public int UpdatedCount { get; set; }
        public string IntrestedModel { get; set; }
        public string Reason { get; set; }
        public string Mobilno { get; set; }
        public string SourceOfEnquiry { get; set; }
        public UserBase User { get; set; }
        public Dropdown SalesExc { get; set; }
        public string NewExecutive { get; set; }
        public string OldSalesExecutive { get; set; }
        public string SalesExecutive { get; set; }
        public List<LeadReassign> LeadReassignList { get; set; }
        public LeadReassignItem LeadReassignItem { get; set; }
        public int active { get; set; }
        public int totalRecords { get; set; }
    }
    public class LeadReassignItem
    {
        public string LeadNo { get; set; }
        public int Trnno { get; set; }
        public int UpdatedCount { get; set; }
        public string CustomerName { get; set; }
        public string EnquireDate { get; set; }
        public string EmailId { get; set; }

        public string IntrestedModel { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string Mobilno { get; set; }
        public string SourceOfEnquiry { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string ModeOfContract { get; set; }

        
        public string Remarks { get; set; }
        public int SalesExecCode { get; set; }

        public Dropdown SalesExc { get; set; }
        public string OldExecutive { get; set; }
        public string NewExecutive { get; set; }
        public string ContactDate { get; set; }
        public string ModeofContact { get; set; }
        public string Remarkss { get; set; }
        public string NextFollowupDate { get; set; }
        public string LeadStatus { get; set; }
        public string PurchaseTimes { get; set; }
        public string Reason { get; set; }
        public List<LeadReassignItem> LeadReassignItemList { get; set; }

    }
}

