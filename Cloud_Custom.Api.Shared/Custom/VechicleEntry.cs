using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class VechicleEntry
    {
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string RegistrationNo { get; set; }
        public string ModelName { get; set; }
        public Dropdown FuelType { get; set; }
        public Dropdown ServiceType { get; set; }
        public string KM { get; set; }
        public Dropdown Feedback { get; set; }
        public DateTime? PreferredDate { get; set; }
        public Dropdown TimeSlot { get; set; }
        public string BookingSource { get; set; }
        public string BookingNo { get; set; }
        public string ServiceDue { get; set; }
        public string Address { get; set; }
        public string Make { get; set; }
        public string Variant { get; set; }
        public string YearofManufacture { get; set; }
        public string KMDriven { get; set; }
        public string Color { get; set; }

        public string ExpectedPrice { get; set; }
        public string EvaluatedPrice { get; set; }
    }
}
