using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceAgeingSummery
    {
        public UserBase User { get; set; }

        public int BookingCode { get; set; }
        public string BookingNo { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingStatus { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string RegistrationNo { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string JobCardNo { get; set; }
        public DateTime? JCDateTime { get; set; }
        
        public DateTime? CHKIN_DT { get; set; }
        public DateTime? CHKOUT_DT { get; set; }
        public string ServiceType { get; set; }
        public string ServiceAdvisor { get; set; }
        public string Technician { get; set; }
        public decimal? BillAmount { get; set; }
        public int? BookingAgeingDays { get; set; }
        public int? WorkshopAgeingDays { get; set; }
        public int? DeliveryDelayDays { get; set; }
        public string VehicleStatus { get; set; }
        public string AgeingBucket { get; set; }
        public List<ServiceAgeingSummery> List { get; set; }
        public Dropdown Age { get; set; }

    }
}
