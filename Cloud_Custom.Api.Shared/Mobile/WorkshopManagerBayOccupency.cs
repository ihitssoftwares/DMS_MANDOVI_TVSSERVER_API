using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
    public class WorkshopManagerBayOccupency
    {
        public string BayUserCode { get; set; }

        public string BayStatus { get; set; }

        public string JobCardNo { get; set; }

        public string VehicleRegistrationNumber { get; set; }

        public string EmployeeName { get; set; }

        public int UnitPending { get; set; }
        public List<WorkshopManagerBayOccupency> List { get; set; }
    }
}
