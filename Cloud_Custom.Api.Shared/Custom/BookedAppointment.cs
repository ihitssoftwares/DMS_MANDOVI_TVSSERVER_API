using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class BookedAppointment
    {
        public int BookingCode { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string RegistrationNo { get; set; }
        public string ModelName { get; set; }
        public string FuelTypes { get; set; }
        public string ServiceTypes { get; set; }
        public string KM { get; set; }
        public string Feedbacks { get; set; }
        public DateTime? PreferredDate { get; set; }
        public string TimeSlots { get; set; }
        public string BookingSource { get; set; }
        public string BookingNo { get; set; }
        public string ServiceDue { get; set; }
        public string SearchCustomerName { get; set; }
        public string SearchCustomerRegisterNo { get; set; }
        public string SearchPhoneNo { get; set; }
        public string city { get; set; }
       
       
        public string variant { get; set; }
       
        public Dropdown AppoinmentStatus { get; set; }

        public Dropdown FuelType { get; set; }
        public Dropdown ServiceType { get; set; }

        public Dropdown Feedback { get; set; }

        public Dropdown TimeSlot { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Workshop { get; set; }
        public Dropdown ServiceAdvisor { get; set; }
        public List<BookedAppointment> BookedAppointmentList { get; set; }
        public List<BookedAppointmentSearch> SearchList { get; set; }
    }
    public class BookedAppointmentSearch
    {
        public string CustomerName { get; set; }
        public string city { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string Model { get; set; }
        public string variant { get; set; }

        public string RegisterNumber { get; set; }

    }
}