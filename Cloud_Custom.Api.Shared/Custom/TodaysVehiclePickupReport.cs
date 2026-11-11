using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class TodaysVehiclePickupReport
    {
        public int BookingCode { get; set; }
        public Dropdown WORKSHOPSS { get; set; }
        public int BranchCode { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public List<TodaysVehiclePickupReport> List { get; set; }
        public UserBase user { get; set; }
        public string BookingNumber { get; set; }
        public string MobileNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime VehicleCollectedTime { get; set; }
        public DateTime WorkshopInTime { get; set; }
        public int StartKm { get; set; }
        public int EndKm { get; set; }

        public string PickUpAddress { get; set; }
        public string PickUpStatus { get; set; }

        public string DriverName { get; set; }

        public string ModelName { get; set; }
        public string VariantName { get; set; }

    }
}
