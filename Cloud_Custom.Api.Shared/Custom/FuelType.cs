using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
     public class FuelType
    {
        public UserBase User { get; set; }
        public int TypeCode { get; set; }
        public int Slno { get; set; }
        public string TypeName { get; set; }
        public List<FuelType> List { get; set; }
        public string Mode { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public string DMSCode { get; set; }
    }
}
