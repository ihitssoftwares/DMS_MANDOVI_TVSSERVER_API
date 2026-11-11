using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class TestDriveSchedule
    {
        public string ReqDate { get; set; }
        public string ReqNo { get; set; }
        public string Mode { get; set; }
        public string LeadNo { get; set; }
        public string Location { get; set; }
        public string PrefLoc { get; set; }
        public string Status { get; set; }
        public string PrefDate { get; set; }
        public string Salesexecutive { get; set; }
        public string Customer { get; set; }
        public string Pretime { get; set; }
        public string ModelDetails { get; set; }
        
        public List<TestDriveSchedule> TestDriveScheduleList { get; set; }
        public TestDriveScheduleDetails TestDriveScheduleDetails { get; set; }
    }
    public class TestDriveScheduleDetails
    {

        public string Customer { get; set; }
        public string MobileNo { get; set; }
        public string PrefDate { get; set; }
        public string PrefTime { get; set; }
        public string ScheduleDate { get; set; }
        public string ScheduleTime { get; set; }
        public string ScheduleVehicle { get; set; }
        public string Loction { get; set; }
        public string LeadNo { get; set; }
        public string Mode { get; set; }

        public string ModelName { get; set; }
        public string VariantName { get; set; }
        public string Address { get; set; }
        public Dropdown Vehicle { get; set; }
        public Dropdown Time { get; set; }

        public string BranchName { get; set; }
        public int VehicleCode { get; set; }
        public string Name { get; set; }
        public string RegnNo { get; set; }

        public DateTime ScheduledDate { get; set; }

        public string TestTime { get; set; }
        public string TestDate { get; set; }
        public string Availability { get; set; }

        public List<TestDriveScheduleDetails> TestDriveScheduleDetailsList { get; set; }
        

    }
}
