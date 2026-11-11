using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
    public class WorkShopManagerJobStatus
    {
        public int JobCardEntryCode { get; set; }

        public string JobCardNo { get; set; }

        public DateTime JCDateTime { get; set; }

        public string Customer { get; set; }

        public string Phone { get; set; }

        public string VehicleRegistrationNumber { get; set; }

        public string ChassisNo { get; set; }

        public string EngineNo { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

        public List<WorkShopManagerJobStatus> List { get; set; }
    }
}
