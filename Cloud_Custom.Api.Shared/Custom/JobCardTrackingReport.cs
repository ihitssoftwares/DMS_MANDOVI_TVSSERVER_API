using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class JobCardTrackingReport
    {
        public Dropdown Workshop { get; set; }
        public DateTime JCDateTime { get; set; }
        public DateTime PickedDate { get; set; }
        public string JobCardNo { get; set; }
        public int JobCardEntryCode { get; set; }
        public string CustomerName { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CheckIn { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string CheckOut { get; set; }
        public string Status { get; set; }
        public string Ageing { get; set; }
        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public string BayTimeSpent { get; set; }
        public string Technician { get; set; }
        public string BayUserCode { get; set; }
        public string BayName { get; set; }
        public string BayDuration { get; set; }
       
        public List<JobCardTrackingReport> List { get; set; }
        public List<JobCardTrackingReport> BayList { get; set; }
    }
}
