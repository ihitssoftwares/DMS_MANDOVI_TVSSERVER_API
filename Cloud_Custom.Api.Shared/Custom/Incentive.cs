using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Incentive
    {
        public UserBase User { get; set; }
        public int IncentiveCode { get; set; }
        public int SLno { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public string Incentivename { get; set; }
        public string Mode { get; set; }
        public string? DMSCode { get; set; }
        public string BasedOnName { get; set; }
        public int BasedOnCode { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public Dropdown Department { get; set; }
        public Dropdown Incentivebasedon { get; set; }
        public List<Incentive> List { get; set; }
        public int DepartmentTypeCode { get; set; }
    }
}
