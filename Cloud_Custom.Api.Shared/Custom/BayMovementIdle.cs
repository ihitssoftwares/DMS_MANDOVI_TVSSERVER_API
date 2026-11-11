using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class BayMovementIdle
    {
        public int JCEntryCode { get; set; }
        public string JCNo { get; set; }
        public string RegNumber { get; set; }
        public DateTime? JCDateTime { get; set; }
        public int FromBayCode { get; set; }
        public string FromBay { get; set; }
        public int ToBayCode { get; set; }
        public string ToBay { get; set; }
        public DateTime? FromBayOutTime { get; set; }
        public DateTime? ToBayInTime { get; set; }
        public int? IdleMinutes { get; set; }
        public List<BayMovementIdle> List { get; set; }
        public UserBase User { get; set; }
        public Dropdown WorkShop { get; set; }


    }
}
