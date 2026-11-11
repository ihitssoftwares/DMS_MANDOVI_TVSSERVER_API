using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class TestDrive
    {
        public int TestCode { get; set; }
        public Dropdown SalesExec { get; set; }
        public Dropdown CustomerName { get; set; }
        public Dropdown Model { get; set; }
        public Dropdown Variant { get; set; }
        public string ModelDetails { get; set; }
        public string PrefDate { get; set; }
        public Dropdown PrefTime { get; set; }
        public string ReqDate { get; set; }
        public string ReqNo { get; set; }
        public string ReqTime { get; set; }
        public string MobileNo { get; set; }
        public string LeadNo { get; set; }
        public int TrnCode { get; set; }
        public string Location { get; set; }
        public string PrefLoc { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string Salesexecutive { get; set; }
        public string Customer { get; set; }
        public string Pretime { get; set; }
        public List<TestDrive> TestDriveList { get; set; }
        public TestDriveDetails TestDriveDetails { get; set; }
    }
    public class TestDriveDetails
    {
        public string leadNo { get; set; }
  
        public string Name { get; set; }
        public string interestedModel { get; set; }
       
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string NextFollowDate { get; set; }
        public string LeadStatus { get; set; }
        public List<TestDriveDetails> TestDriveDetailsList { get; set; }
    }
}