using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ShowroomRent
    {
        public Dropdown Region { get; set; }
        public Dropdown WorkhoporShowroom { get; set; }

        public List<ShowroomRent> List { get; set; }
        public string RegionName { get; set; }
        public int RegionCode { get; set; }
        public string SalesDealerCode { get; set; }
        public Decimal Rent { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
    }
}
