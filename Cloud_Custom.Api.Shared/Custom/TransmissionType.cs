using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
     public class TransmissionType
    {
        public UserBase User { get; set; }
        public int TypeCode { get; set; }
        public int Slno { get; set; }
        public string TypeName { get; set; }
        public string Mode { get; set; }
        public string DMSCode { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public List<TransmissionType> List { get; set; }
    }
}
