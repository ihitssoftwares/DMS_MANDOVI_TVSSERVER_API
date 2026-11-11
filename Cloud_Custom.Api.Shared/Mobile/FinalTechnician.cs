using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
     public class FinalTechnician
    {
        public int TotalJobs { get; set; }

        public string JobsCompleted { get; set; }

        public string WorkedHours { get; set; }

        public string BranchWorkingHours { get; set; }

        public decimal WorkDonePercentage { get; set; }

        public int WorkedMinutes { get; set; }

        public int TechnicianEmpCode { get; set; }
        public int BayCode { get; set; }
        public string EmployeeName { get; set; }
        public string BayUserCode { get; set; }
        public string BayName { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExistTime { get; set; }
        public string JobsAssigned { get; set; }
        public string ServiceHours { get; set; }
        public string ShiftProgress { get; set; }

        public int Slno { get; set; }
        public int JobCardEntryCode { get; set; }
        public string JobCardNo { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string mode { get; set; }
        public DateTime? JCDateTime { get; set; }
        public DateTime? CheckIn { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public string ModeName { get; set; }
        public string VariantName { get; set; }
        public string Status { get; set; }

        public int MCare { get; set; }
        public int CustomerCode { get; set; }

        public string ServiceName { get; set; }
        public int AllowedLimit { get; set; }
        public int Availed { get; set; }
        public int Balance { get; set; }


        public List<FinalTechnician> List { get; set; }
        public List<FinalTechnician> VehicleList { get; set; }
        public UserBase User { get; set; }
        public int ElapsedMinutes { get; set; }
        public decimal TimeElapsedPercentage { get; set; }
        public string RemainingHours { get; set; }
        public int DurationMinutes { get; set; }
    }


   
}
