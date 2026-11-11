using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public  class Driver
    {
        public List<Driver> List { get; set; }
        public string CustomerName { get; set; }
        public string DriverName { get; set; }
        public int PendingCount { get; set; }
        public int Completed { get; set; }
        public int TotalCount { get; set; }
        public int Kilometers { get; set; }
        public string Remarks { get; set; }
        public int DriverCode { get; set; }
        public int PickupCode { get; set; }
        public int BookingCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string StartKM { get; set; }
        public string EndKM { get; set; }
        public string Status { get; set; }
        public string AlternateMobileNo { get; set; }
        public string ModelName { get; set; }
        public string VariantName { get; set; }
       public string Mobile { get; set; }
        public string RegistrationNo { get; set; }
        public string PreferredDate { get; set; }
        public string PickupAddress { get; set; }
        public string Address { get; set; }
     
    }
}
