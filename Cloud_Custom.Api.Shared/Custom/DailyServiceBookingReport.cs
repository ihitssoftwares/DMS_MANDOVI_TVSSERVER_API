using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class DailyServiceBookingReport
    {
        public Dropdown WORKSHOP { get; set; }
        public UserBase user { get; set; }
        public int BranchCode { get; set; }
        public List<DailyServiceBookingReport> List { get; set; }

        public string BookingNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string Model { get; set; }
        public string Varient { get; set; }
        public int Odometer { get; set; }
        public string BookingStatus { get; set; }
        public DateTime? PreferredDate { get; set; }
        public Decimal EstimatedCost { get; set; }
        public string VehicleDetails { get; set; }
        public string RegistrationNumber { get; set; }

    }
}
