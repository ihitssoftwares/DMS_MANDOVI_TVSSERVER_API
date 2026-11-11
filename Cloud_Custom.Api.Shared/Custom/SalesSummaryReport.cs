using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class SalesSummaryReport
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int BranchCode { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Date { get; set; }
        public Dropdown Regions { get; set; }
        public Dropdown Channel { get; set; }
        // Common Output
        public int SlNo { get; set; }

        public string Region { get; set; }

        public string Branch { get; set; }

        public string Executive { get; set; }

        public string Model { get; set; }

        public int CarSales { get; set; }

        public decimal SaleValue { get; set; }

        public decimal Percentage { get; set; }
        public List<SalesSummaryReport> List { get; set; }
        public string Name { get; set; }
        public string Types { get; set; }
    }
}
