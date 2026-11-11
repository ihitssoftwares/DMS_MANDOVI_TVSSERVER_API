using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
    public class MobilePendingJobs
    {
        public int Slno { get; set; }

        public int JobCardEntryCode { get; set; }

        public string JobCardNo { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime? JCDateTime { get; set; }

        public DateTime? CheckIn { get; set; }

        public string VehicleRegistrationNumber { get; set; }

        public string ChassisNo { get; set; }

        public string EngineNo { get; set; }

        public string ModeName { get; set; }

        public string VariantName { get; set; }

        public string Status { get; set; }
        public int CustomerCode { get; set; }
        public int MCare { get; set; }
        public List<MobilePendingJobs> List { get; set; }
    }
}
