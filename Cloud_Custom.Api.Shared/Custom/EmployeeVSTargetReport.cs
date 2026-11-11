using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class EmployeeVSTargetReport
    {
        public Dropdown MonthFrom { get; set; }
        public Dropdown MonthTo { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown NewMonth { get; set; }
        public Dropdown Parameter { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public int ParameterCode { get; set; }
        public string IncentiveGroupName { get; set; }
        public string ParameterName { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string TargetType { get; set; }
        public int RegionCode { get; set; }
        public string RegionName { get; set; }
        public int Targets { get; set; }
        public int PreTarget { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public int PendingCount { get; set; }
        public List<EmployeeVSTargetReport> List { get; set; }
    }
}
