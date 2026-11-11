using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Bay
    {
        public UserBase User { get; set; }
        public int BayCode { get; set; }
        public int SLno { get; set; }
        public string Mode { get; set; }
        public string BayName { get; set; }

        public int BranchCode { get; set; }
        public int BayTypeCode { get; set; }
        public Dropdown BayType { get; set; }
        public List<Bay> List { get; set; }
        public bool Active { get; set; }
        public Dropdown Branch { get; set; }

        public string BranchName { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public string BAYTYPENAME { get; set; }
        public string BayUserCode { get; set; }

    }
}
