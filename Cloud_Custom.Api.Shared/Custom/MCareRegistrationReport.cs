using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MCareRegistrationReport
    {
        public UserBase User { get; set; }
        public Guid RegistrationEntryCode { get; set; }

        public string EntryNo { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string PlanName { get; set; }

        public string PackageDuration { get; set; }

        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public string VehicleRegistrationNumber { get; set; }

        public string Model { get; set; }

        public string Variant { get; set; }

        public string Colour { get; set; }

        public string ChassisNo { get; set; }

        public string EngineNo { get; set; }

        public decimal PlanAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public List<MCareRegistrationReport> List { get; set; }
        public Dropdown Statuso { get; set; }
        public Dropdown Plan { get; set; }
        public int TotalCount { get; set; }
        public string BranchName { get; set; }
        public string RegionName { get; set; }
    }
}
