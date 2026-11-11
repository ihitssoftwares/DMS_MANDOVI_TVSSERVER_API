using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Variant
    {
        public UserBase User { get; set; }
        public string Mode { get; set; }
        public int VariantCode { get; set; }
        public int SLno { get; set; }
        public string VariantName { get; set; }
        public string VariantDescription { get; set; }
        public string DMSCode { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public List<Variant> List { get; set; }
    }
}
