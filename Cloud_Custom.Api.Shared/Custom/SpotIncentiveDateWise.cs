using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class SpotIncentiveDateWise
    {
        public Dropdown Month { get; set; }
        public Dropdown Region { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int HDCode { get; set; }
        public decimal DSE { get; set; }
        public decimal TL { get; set; }
        public decimal SM { get; set; }
        public string Mode { get; set; }
        public List<SpotIncentiveDateWise> SpotIncentiveDateWiseList { get; set; }
    }
}
