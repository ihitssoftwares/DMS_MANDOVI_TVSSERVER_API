using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class BayUtilizationReport
    {
        public UserBase User { get; set; }
        public int BayCode { get; set; }

        public string BayUserCode { get; set; }

        public string BayName { get; set; }

        public string BayType { get; set; }

        public decimal AverageServiceTime { get; set; }

        public int TotalVehicles { get; set; }

        public DateTime? FirstVehicleIn { get; set; }

        public DateTime? LastVehicleOut { get; set; }
        public List<BayUtilizationReport> List { get; set; }
        public Dropdown WorkShop { get; set; }
        public DateTime Date { get; set; }
        public string Technician { get; set; }
    }
}
