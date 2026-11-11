using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class TestDriveApproval
    {
        public string ReqDate { get; set; }
        public string ReqNo { get; set; }

        public string LeadNo { get; set; }
        public string Location { get; set; }
        public string PrefLoc { get; set; }
        public string Status { get; set; }
        public string PrefDate { get; set; }
        public string Salesexecutive { get; set; }
        public string Customer { get; set; }
        public string Pretime { get; set; }
        public string ModelDetails { get; set; }
        public string Address { get; set; }
        
        public List<TestDriveApproval> TestDriveApprovalList { get; set; }
        public TestDriveApprovalDetails TestDriveApprovalDetails { get; set; }
    }
    public class TestDriveApprovalDetails
    {
        public string leadNo { get; set; }
        public string Name { get; set; }
        public string interestedModel { get; set; }
        public string Mobilno { get; set; }
        public string EmailId { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string NextFollowDate { get; set; }
        public string LeadStatus { get; set; }
        public string SalesExec { get; set; }
        public string SourceOfEnq { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
      
        public string ModeOfContact { get; set; }
        public string ContactDate { get; set; }
        public string LeadDate { get; set; }
        public string Mode { get; set; }
        public string ReqNo { get; set; }

        public List<TestDriveApprovalDetails> TestDriveApprovalDetailsList { get; set; }
    }
}
