using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class TeamManagerWiseEnquiryStatusReport 
    {
        public Dropdown Month { get; set; }
        public Dropdown Model { get; set; }
        public Dropdown Enquiry { get; set; }

        public int MonthCode { get; set; }
        public int ModelCode { get; set; }

        public int EnquiryCode { get; set; }

        public List<TeamManagerWiseEnquiryStatusReport> List { get; set; }
        public string Channel { get; set; }
        public string RegionName { get; set; }
        public string TeamLeader { get; set; }
        public int TeamLeaderEmployeeCode { get; set; }
        public string LiveEnquiry { get; set; }
        public string MultipleOutLet { get; set; }
        public string FirstFollowUp { get; set; }
        public string SecondFollowUp { get; set; }
        public string TD { get; set; }
        public string HomeVisit { get; set; }
        public string ZeroFollowUp { get; set; }
        public string FollowPct { get; set; }
        public string HVPct { get; set; }
        public string TDPct { get; set; }
        public string TotalType { get; set; }
        public int SourceCode { get; set; }
        public int TotalCount { get; set; }
    }
}
