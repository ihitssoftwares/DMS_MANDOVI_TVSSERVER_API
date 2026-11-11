using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class IncentiveTargetRegionSettings
    {
        public Dropdown Employee { get; set; }
        public Dropdown Branch { get; set; }
        public int[] Regions { get; set; }
        public string EmployeeName { get; set; }
        public string RegionName { get; set; }
        public string BranchName { get; set; }
        public int EmployeeCode { get; set; }
        public bool IsApplicable { get; set; }
        public int BranchCode { get; set; }
        public int RegionCode { get; set; }
        public List<IncentiveTargetRegionSettings> List { get; set; }


    }
}
