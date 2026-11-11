using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class DearlerShip 
    {
        public UserBase User { get; set; }
        public int DealerCode { get; set; }
        public int SLno { get; set; }
        public string Mode { get; set; }
        public string Dearlname { get; set; }
        public string DearlType { get; set; }
        public string DMSCode { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public Dropdown Type { get; set; }
        public List<DearlerShip> List { get; set; }

    }
}
