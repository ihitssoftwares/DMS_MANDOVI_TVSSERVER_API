using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceAppointment
    {
        public Dropdown VechicleModel { get; set; }
        public string Address { get; set; }
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
        public Dropdown Region { get; set; }
        public Dropdown Workshop { get; set; }
        public Dropdown ServiceAdvisor { get; set; }
    }
}
