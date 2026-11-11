using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class VehicleGate
       
    {
        public UserBase User { get; set; }
        public string RegNumber { get; set; }
        public string Model { get; set; }
        public DateTime InDateTime { get; set; }
        public string Variant { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string TotalMinute { get; set; }

        public Dropdown Branch { get; set; }

        public List<VehicleGate> List { get; set; }

    }
}
