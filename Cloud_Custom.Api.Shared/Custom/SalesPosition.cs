using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public   class SalesPosition
    {
        public UserBase User { get; set; }
        public int IncentiveCode { get; set; }
        public int SLno { get; set; }

        public string Incentivename { get; set; }
        public string Mode { get; set; }
        public string? DMSCode { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public Dropdown Department { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public List<SalesPosition> List { get; set; }
    }
}
