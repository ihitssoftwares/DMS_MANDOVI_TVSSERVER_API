using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class NonServiceVehicle
    {
        public UserBase User { get; set; }
        public string Mode { get; set; }
        public int SLno { get; set; }
        public int NonServiceVehicleCode { get; set; }
        public string RegNo { get; set; }
        public string Remarks { get; set; }
        public List<NonServiceVehicle> List { get; set; }
    }
}
