using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Color
    {
        public int ColorCode { get; set; }
        public int SLno { get; set; }
        public string ColorName { get; set; }
        public List<Color> List { get; set; }
        public UserBase user { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public string? DMSCode { get; set; }

    }
}
