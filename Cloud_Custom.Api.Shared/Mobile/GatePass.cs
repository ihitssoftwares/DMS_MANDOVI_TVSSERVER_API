using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Mobile
{
    public class GatePass
    {
        public File File { get; set; }
        public int GatePassEntryCode { get; set; }
        public string VehicleNumber { get; set; }
        public string AIResponse { get; set; }
        public string Status { get; set; }
        public UserBase User { get; set; }
        public int WorkShopCode { get; set; }
    }
    public class NumberPlateResponse
    {
        public int gatePassEntryCode { get; set; }
        public string status { get; set; }
        public string number { get; set; }
        public decimal confidence { get; set; }
        public string timestamp { get; set; }
        public string error { get; set; }
    }

    public class GatePassResponse
    {
        public int GatePassEntryCode { get; set; }
        public string VehicleNumber { get; set; }
    }
}
