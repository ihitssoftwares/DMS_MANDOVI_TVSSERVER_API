using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MCareExpiryReport
    {
        public UserBase User { get; set; }
        public int RegistrationEntryCode { get; set; }

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

        public int RemainingDays { get; set; }
        public List<MCareExpiryReport> List { get; set; }
        public int TotalCount { get; set; }
    }
}
