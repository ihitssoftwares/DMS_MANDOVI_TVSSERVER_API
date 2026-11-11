using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
    public class MobileServiceTechDash
    {
        public int TotalJobs { get; set; }

        public int CompletedJobs { get; set; }

        public string WorkedHours { get; set; }

        public string BranchWorkingHours { get; set; }

        public decimal WorkDonePercentage { get; set; }

        public int WorkedMinutes { get; set; }

        public int TechnicianEmpCode { get; set; }

        public string EmployeeName { get; set; }
        public string BayUserCode { get; set; }
        public string BayName { get; set; }
        public DateTime EntryTime { get; set; }
        public string JobsAssigned { get; set; }
        public string JobsCompleted { get; set; }

        // Current In-Progress Vehicles
        public List<MobileTechnicianVehicleModel> VehicleList { get; set; }
    }

    public class MobileTechnicianVehicleModel
    {
        public string RegistrationNumber { get; set; }
        public string JobCardNo { get; set; }
        public int BayCode { get; set; }
        public int TechnicianEmpCode { get; set; }
        public int JobCardEntryCode { get; set; }
        public int ModelCode { get; set; }

        public string Model { get; set; }

        public string Variant { get; set; }

        public DateTime? InTime { get; set; }

        public string Statuse { get; set; }
    }
}
