using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class IncentiveTargetBranchSettings
    {
        public Dropdown Employee { get; set; }
        public Dropdown Branch { get; set; }
        public Dropdown Incentivess { get; set; }

        public bool IsApplicable { get; set; }
        public int[] Branchs { get; set; }
        public string EmployeeName { get; set; }
        public string RegionName { get; set; }
        public string BranchName { get; set; }
        public int EmployeeCode { get; set; }
        public int BranchCode { get; set; }
        public int RegionCode { get; set; }
        public int IncentiveGroupCode { get; set; }
        public string IncentiveGroupName { get; set; }
        public List<IncentiveTargetBranchSettings> List { get; set; }
        public List<IncentiveTargetBranchSettings> BranchList { get; set; }


    }
}
