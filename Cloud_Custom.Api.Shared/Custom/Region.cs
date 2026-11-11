using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class Region
    {
        public UserBase User { get; set; }
        public int RegionCode { get; set; }
        public int SLno { get; set; }
        public string RegionName { get; set; }
        public string Mode { get; set; }
        public string DMSCode { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public List<Region> List { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }
        public bool Applicable { get; set; }
    }
}
