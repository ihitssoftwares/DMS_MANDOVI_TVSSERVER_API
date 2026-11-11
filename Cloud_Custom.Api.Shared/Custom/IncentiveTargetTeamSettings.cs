using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class IncentiveTargetTeamSettings
    {
        public int IncentiveGroupCode { get; set; }
        public bool IsApplicable { get; set; }
        public string BranchName { get; set; }
        public int EmployeeCode { get; set; }
        public int TLEmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public Dropdown Employee { get; set; }
        public string IncentiveGroupName { get; set; }
        public List<TARGETIncentiveItem> ParameterList { get; set; }
        public List<IncentiveTargetTeamSettings> List { get; set; }
    }

    public class TARGETIncentiveItem
    {
        public int EmployeeCode { get; set; }
        public bool IsApplicable { get; set; }
        public int IncentiveGroupCode { get; set; }
    }
}
