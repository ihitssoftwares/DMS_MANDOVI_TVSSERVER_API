using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class WorkShop
    {
        public int WorkShopCode { get; set; }
        public string WorkShopName { get; set; }
        public UserBase User { get; set; }
        public int Slno { get; set; }
        public string ShortName { get; set; }
        public string Mode { get; set; }
        public Dropdown Regionn { get; set; }
        public Dropdown Type { get; set; }
        public int? Capacity { get; set; }
        public string Region { get; set; }
        public string WsType { get; set; }

        public string DMSCode { get; set; }
        public List<WorkShop> List { get; set; }
    }
}
