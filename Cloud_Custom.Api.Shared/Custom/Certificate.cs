using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
     public class Certificate
    {

        public string RegistrationEntryGI { get; set; }
        public int RegEntryCode { get; set; }
        public string EntryNo { get; set; }
        public DateTime? RegDate { get; set; }
        public string PlaneName { get; set; }
        public string PackageDuration { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string VehicleRegNo { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public int PlaneAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string BranchName { get; set; }

        public string Service { get; set; }
        public int Limit { get; set; }
        public int Percentage { get; set; }

        public string Description { get; set; }

        public List<Certificate> List { get; set; }
        public UserBase User { get; set; }
        public Url Url { get; set; }
        public int TotalCount { get; set; }

    }
}
