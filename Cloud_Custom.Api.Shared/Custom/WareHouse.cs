using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class WareHouse
    {
        public UserBase User { get; set; }
        public int WareHouseCode { get; set; }
        public int Slno { get; set; }
        public string WareHouseName { get; set; }
        public string ShortName { get; set; }
        public Dropdown Regionn { get; set; }
        public string Region { get; set; }
        public string Mode { get; set; }
        public string DMSCode { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public List<WareHouse> List { get; set; }
    }
}
