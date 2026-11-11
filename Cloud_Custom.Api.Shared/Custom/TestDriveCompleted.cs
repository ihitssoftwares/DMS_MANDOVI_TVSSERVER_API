using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class TestDriveCompleted
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
        public string SchNo { get; set; }

        public string Mode { get; set; }
        public List<TestDriveCompleted> TestDriveCompletedList { get; set; }
        public TestDriveCompletedDetails TestDriveCompletedDetails { get; set; }
    }
    public class TestDriveCompletedDetails
    {
        public string Customer { get; set; }
        public string Model { get; set; }
        public string ScheduleDate { get; set; }
        public string ScheduleTime { get; set; }
        public string ScheduleVehicle { get; set; }
        public string TestDate { get; set; }
        public string Testtime { get; set; }

        public string SchNo { get; set; }
        public int ReqNo { get; set; }
        public Dropdown Vehicle { get; set; }
        public List<TestDriveCompletedDetails> TestDriveCompletedDetailsList { get; set; }
    }
}
